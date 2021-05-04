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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        upgradeCanvas = GameObject.Find("UpgradeCanvas");
        gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<Game_Manager>().AddEnemy();
    }

    // Update is called once per frame
    void Update()
    {
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
                    GetComponent<Rigidbody2D>().velocity = new Vector2(horizSpeed, tempVertSpeed);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-horizSpeed, tempVertSpeed);
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
                GetComponent<Rigidbody2D>().velocity = new Vector2(horizSpeed, 0);
                if (transform.position.x > 8.5f)
                {
                    moveRight = false;
                }
            }
            else if (!swooping)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-horizSpeed, 0);
                if (transform.position.x < -8.5f)
                {
                    moveRight = true;
                }
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -horizSpeed);
            if (transform.position.y < 3.3f)
            {
                spawned = true;
            }
        }
        if (health < 1)
        {
            gameManager.GetComponent<Game_Manager>().KillEnemy();
            int i = Random.Range(1, 401);
            if (i == 1)
            {
                Instantiate(lifeDrop, transform.position, Quaternion.identity);
            }
            else if (i == 2)
            {
                Instantiate(minigunDrop, transform.position, Quaternion.identity);
            }
            else if (i == 3)
            {
                Instantiate(laserDrop, transform.position, Quaternion.identity);
            }
            else if (i == 4)
            {
                Instantiate(rocketDrop, transform.position, Quaternion.identity);
            }
            else if (i == 5)
            {
                Instantiate(shotgunDrop, transform.position, Quaternion.identity);
            }
            else if (i == 6)
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
            health -= 2;
        }
        else if (upgradeCanvas.GetComponent<Upgrades>().dmgBought)
        {
            health--;
        }
        if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 90)
        {
            health -= 3;
        }
        else if (upgradeCanvas.GetComponent<Upgrades>().deathBought && Random.Range(1, 101) == 1)
        {
            health = 0;
        }
        else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 95)
        {
            health -= 2;
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
                health -= 2;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().dmgBought)
            {
                health--;
            }
            if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 90)
            {
                health -= 3;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().deathBought && Random.Range(1, 101) == 1)
            {
                health = 0;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 95)
            {
                health -= 2;
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
                health -= 2;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().dmgBought)
            {
                health--;
            }
            if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 90)
            {
                health -= 3;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().deathBought && Random.Range(1, 101) == 1)
            {
                health = 0;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 95)
            {
                health -= 2;
            }
        }
        else if (collision.gameObject.tag == "SuperShot")
        {
            health -= collision.transform.localScale.x;
        }
    }
}
