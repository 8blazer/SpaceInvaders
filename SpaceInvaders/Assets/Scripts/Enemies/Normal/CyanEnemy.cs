using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyanEnemy : MonoBehaviour
{
    public float horizSpeed;
    public float vertSpeed;
    float tempVertSpeed;
    public float vertSpeedChange;
    GameObject player;
    GameObject gameManager;
    GameObject upgradeCanvas;
    float health = 10;
    bool moveRight;
    bool swooping = false;
    float timer;
    public float swoopTime;
    bool spawned = false;
    public Vector2 savedVelocity = new Vector2(0, 0);

    public GameObject lifeDrop;
    public GameObject minigunDrop;
    public GameObject laserDrop;
    public GameObject shotgunDrop;
    public GameObject sniperDrop;
    public GameObject rocketDrop;

    public float jitterTimer;
    float jitterTime;
    public Sprite crazy;
    Vector2 jitterVelocity;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        upgradeCanvas = GameObject.Find("UpgradeCanvas");
        gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<Game_Manager>().AddEnemy();
        if (PlayerPrefs.GetString("challenge") == "CrazyEnemy")
        {
            GetComponent<SpriteRenderer>().sprite = crazy;
        }
    }

    // Update is called once per frame
    void Update()
    {
        jitterTimer += Time.deltaTime;
        if (PlayerPrefs.GetString("challenge") == "CrazyEnemy" && jitterTimer > jitterTime)
        {
            jitterVelocity = new Vector2(Random.Range(-7.0f, 7.1f), 0);
            jitterTimer = 0;
        }
        if (spawned)
        {
            if (!player.GetComponent<PlayerAbility>().frozen)
            {
                timer += Time.deltaTime;
            }
            if (timer > swoopTime)
            {
                if (swoopTime < 3)
                {
                    swoopTime += Random.Range(0, 3);
                }
                else if (swoopTime > 5)
                {
                    swoopTime += Random.Range(-2, 0);
                }
                else
                {
                    swoopTime += Random.Range(-1, 2);
                }
                swooping = true;
                tempVertSpeed = vertSpeed;
                timer = 0;
                if (player.transform.position.x > transform.position.x)
                {
                    moveRight = true;
                }
                else
                {
                    moveRight = false;
                }
            }
            if (swooping && !player.GetComponent<PlayerAbility>().frozen)
            {
                if (moveRight)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(horizSpeed, tempVertSpeed) + jitterVelocity;
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-horizSpeed, tempVertSpeed) + jitterVelocity;
                }
                if (-vertSpeed < tempVertSpeed)
                {
                    swooping = false;
                }
                tempVertSpeed += vertSpeedChange * Time.deltaTime;
                timer = 0;
            }
            if (moveRight && !swooping)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(horizSpeed, 0) + jitterVelocity;
                if (transform.position.x > 8.5f)
                {
                    moveRight = false;
                }
            }
            else if (!swooping)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-horizSpeed, 0) + jitterVelocity;
                if (transform.position.x < -8.5f)
                {
                    moveRight = true;
                }
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -horizSpeed) + jitterVelocity;
            if (transform.position.y < 3.3f)
            {
                spawned = true;
            }
        }
        if (health < 1 || gameManager.GetComponent<Game_Manager>().wave == 13 || player.GetComponent<PlayerMovement>().lost)
        {
            gameManager.GetComponent<Game_Manager>().KillEnemy();
            player.GetComponent<PlayerMovement>().kills++;
            int i = Random.Range(1, 401);
            if (i == 1)
            {
                Instantiate(lifeDrop, transform.position, Quaternion.identity);
            }
            else if (i == 2 && PlayerPrefs.GetString("challenge") != "Weapon")
            {
                Instantiate(minigunDrop, transform.position, Quaternion.identity);
            }
            else if (i == 3 && PlayerPrefs.GetString("challenge") != "Weapon")
            {
                Instantiate(laserDrop, transform.position, Quaternion.identity);
            }
            else if (i == 4 && PlayerPrefs.GetString("challenge") != "Weapon")
            {
                Instantiate(rocketDrop, transform.position, Quaternion.identity);
            }
            else if (i == 5 && PlayerPrefs.GetString("challenge") != "Weapon")
            {
                Instantiate(shotgunDrop, transform.position, Quaternion.identity);
            }
            else if (i == 6 && PlayerPrefs.GetString("challenge") != "Weapon")
            {
                Instantiate(sniperDrop, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

        if (player.GetComponent<PlayerAbility>().frozen)
        {
            if (savedVelocity.x == 0 && savedVelocity.y == 0)
            {
                savedVelocity = GetComponent<Rigidbody2D>().velocity;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        if (!player.GetComponent<PlayerAbility>().frozen && savedVelocity.x != 0)
        {
            GetComponent<Rigidbody2D>().velocity = savedVelocity;
            savedVelocity = new Vector2(0, 0);
        }
    }

    public void Laser()
    {
        health--;
        if (upgradeCanvas.GetComponent<Upgrades>().exDmgBought)
        {
            health--;
        }
        else if (upgradeCanvas.GetComponent<Upgrades>().dmgBought)
        {
            health -= .5f;
        }
        if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 80)
        {
            health -= 5;
        }
        else if (upgradeCanvas.GetComponent<Upgrades>().deathBought && Random.Range(1, 101) == 1)
        {
            health = 0;
        }
        else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 90)
        {
            health -= 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            health--;
            if (upgradeCanvas.GetComponent<Upgrades>().exDmgBought)
            {
                health--;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().dmgBought)
            {
                health -= .5f;
            }
            if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 80)
            {
                health -= 5;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().deathBought && Random.Range(1, 101) == 1)
            {
                health = 0;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 90)
            {
                health -= 3;
            }
            if (player.GetComponent<PlayerShoot>().weapon == "sniper")
            {
                health -= 13;
                if (Random.Range(1, 3) == 1)
                {
                    Destroy(collision.gameObject);
                }
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Rocket")
        {
            health = health - 8;
            if (upgradeCanvas.GetComponent<Upgrades>().exDmgBought)
            {
                health--;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().dmgBought)
            {
                health -= .5f;
            }
            if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 80)
            {
                health -= 5;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().deathBought && Random.Range(1, 101) == 1)
            {
                health = 0;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 90)
            {
                health -= 3;
            }
        }
        else if (collision.gameObject.tag == "SuperShot")
        {
            health -= player.transform.localScale.x;
        }
    }
}
