using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeBoss : MonoBehaviour
{
    float health = 300;
    public float moveSpeed;
    public float shootSpeed;
    float shootTimer;
    float bulletTimer;
    float bulletTime = 9999;
    float chargeTimer;
    float chargeTime = 2f;
    float laserTimer;
    float laserTime = 1;
    bool moving = true;
    bool moveRight;
    GameObject player;
    GameObject eye;
    GameObject gameManager;
    public GameObject bulletPrefab;
    RaycastHit2D[] players;
    public RuntimeAnimatorController eyeCharge1;
    public RuntimeAnimatorController eyeCharge2;
    public RuntimeAnimatorController eyeCharge3;
    bool spawned = false;

    GameObject upgradeCanvas;
    public GameObject lifeDrop;

    Slider healthbar;
    Image background;
    Image fill;
    Image handle;
    public Sprite handleSprite;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        upgradeCanvas = GameObject.Find("UpgradeCanvas");
        eye = transform.GetChild(0).gameObject;
        if (PlayerPrefs.GetString("challenge") == "CrazyEnemy")
        {
            eye.transform.GetChild(0).GetComponent<Rainbow>().enabled = true;
            eye.GetComponent<Rainbow>().enabled = true;
        }

        healthbar = GameObject.Find("BossHealth").GetComponent<Slider>();
        background = GameObject.Find("BossHealth").transform.GetChild(0).GetComponent<Image>();
        fill = GameObject.Find("BossHealth").transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
        handle = GameObject.Find("BossHealth").transform.GetChild(2).transform.GetChild(0).GetComponent<Image>();
        background.enabled = true;
        fill.enabled = true;
        handle.enabled = true;
        handle.sprite = handleSprite;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = health / 300;
        shootTimer += Time.deltaTime;
        if (shootTimer > shootSpeed && Mathf.Abs(transform.position.x - player.transform.position.x) < .65f)
        {
            moving = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            if (health < 100)
            {
                eye.GetComponent<Animator>().runtimeAnimatorController = eyeCharge3;
            }
            else if (health < 200)
            {
                eye.GetComponent<Animator>().runtimeAnimatorController = eyeCharge2;
            }
            else
            {
                eye.GetComponent<Animator>().runtimeAnimatorController = eyeCharge1;
            }
        }

        bulletTimer += Time.deltaTime;
        if (bulletTimer > bulletTime)
        {
            int i = 0;
            while (i < 3)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-7.0f, 8.0f), 4, 0);

                i++;
            }
            bulletTimer = 0;
        }

        if (eye.GetComponent<Animator>().runtimeAnimatorController != null)
        {
            chargeTimer += Time.deltaTime;
            if (chargeTimer > chargeTime)
            {
                eye.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                eye.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
                players = Physics2D.RaycastAll(transform.position, -eye.transform.up, 10);
                int i = 0;
                while (i < players.Length)
                {
                    if (players[i].transform.gameObject == player)
                    {
                        player.GetComponent<PlayerMovement>().Death();
                    }
                    i++;
                }
                laserTimer += Time.deltaTime;
                if (health < 100)
                {
                    if (transform.position.x > player.transform.position.x)
                    {
                        eye.transform.Rotate(0, 0, -75 * Time.deltaTime);
                    }
                    else
                    {
                        eye.transform.Rotate(0, 0, 75 * Time.deltaTime);
                    }
                }
                else if (health < 200)
                {
                    if (transform.position.x > player.transform.position.x)
                    {
                        eye.transform.Rotate(0, 0, -50 * Time.deltaTime);
                    }
                    else
                    {
                        eye.transform.Rotate(0, 0, 50 * Time.deltaTime);
                    }
                }
                if (laserTimer > laserTime)
                {
                    eye.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                    eye.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
                    laserTimer = 0;
                    chargeTimer = 0;
                    shootTimer = 0;
                    moving = true;
                    eye.GetComponent<Animator>().runtimeAnimatorController = null;
                    eye.transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
        }

        if (spawned)
        {
            if (moving)
            {
                if (moveRight)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed + ((300 - health) / 10), 0);
                    if (transform.position.x > 7.5f)
                    {
                        moveRight = false;
                    }
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed - ((300 - health) / 10), 0);
                    if (transform.position.x < -7.5f)
                    {
                        moveRight = true;
                    }
                }
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
            shootTimer = 0;
            if (transform.position.y < 2.6f)
            {
                spawned = true;
            }
        }

        if (player.GetComponent<PlayerMovement>().lost)
        {
            background.enabled = false;
            fill.enabled = false;
            handle.enabled = false;
            Destroy(gameObject);
        }

        if (health < 1)
        {
            gameManager.GetComponent<Game_Manager>().BossDeath();
            background.enabled = false;
            fill.enabled = false;
            handle.enabled = false;
            Destroy(gameObject);
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
        if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 90)
        {
            health -= 5;
        }
        else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 95)
        {
            health -= 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 2;
            if (player.GetComponent<PlayerShoot>().weapon == "sniper")
            {
                health -= 13;
            }
            if (upgradeCanvas.GetComponent<Upgrades>().exDmgBought)
            {
                health--;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().dmgBought)
            {
                health -= .5f;
            }
            if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 90)
            {
                health -= 5;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 95)
            {
                health -= 3;
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Rocket")
        {
            health -= 8;
            if (upgradeCanvas.GetComponent<Upgrades>().exDmgBought)
            {
                health--;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().dmgBought)
            {
                health -= .5f;
            }
            if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 90)
            {
                health -= 5;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 95)
            {
                health -= 3;
            }
        }
        else if (collision.gameObject.tag == "SuperShot")
        {
            health -= collision.transform.localScale.x * 2;
        }

        if (health < 100)
        {
            laserTime = .33f;
            chargeTime = .66f;
            bulletTime = 2;
        }
        else if (health < 200)
        {
            laserTime = .66f;
            chargeTime = 1.33f;
            bulletTime = 4;
        }
    }
}
