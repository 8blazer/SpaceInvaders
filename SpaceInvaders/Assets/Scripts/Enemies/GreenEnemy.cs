using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : MonoBehaviour
{
    int health = 3;
    public float moveSpeed;
    public float shootSpeed;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    GameObject gameManager;
    GameObject upgradeCanvas;
    GameObject player;
    float timer;
    bool moveRight;
    bool spawned = false;
    float spawnY;

    public GameObject lifeDrop;
    public GameObject minigunDrop;
    public GameObject laserDrop;
    public GameObject shotgunDrop;
    public GameObject sniperDrop;
    public GameObject rocketDrop;

    // Start is called before the first frame update
    void Start()
    {
        shootSpeed = Random.Range(1.5f, 3.1f);
        upgradeCanvas = GameObject.Find("UpgradeCanvas");
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player");
        gameManager.GetComponent<Game_Manager>().AddEnemy();
        spawnY = Random.Range(3.0f, 4.6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned)
        {
            timer += Time.deltaTime;
            if (timer > shootSpeed)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
                timer = 0;
                shootSpeed = Random.Range(3.0f, 4.6f);
            }
            if (moveRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
                if (transform.position.x > 8.5f)
                {
                    moveRight = false;
                    transform.position += new Vector3(0, -1f, 0);
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
                if (transform.position.x < -8.5f)
                {
                    moveRight = true;
                    transform.position += new Vector3(0, -1f, 0);
                }
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
            if (transform.position.y < spawnY)
            {
                spawned = true;
            }
        }
        if (health < 1 || transform.position.y < -4.5f)
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
        if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 92)
        {
            health -= 3;
        }
        else if (upgradeCanvas.GetComponent<Upgrades>().deathBought && Random.Range(1, 151) == 1)
        {
            health = 0;
        }
        else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 96)
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
            if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 92)
            {
                health -= 3;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().deathBought && Random.Range(1, 151) == 1)
            {
                health = 0;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 96)
            {
                health -= 2;
            }
            if (player.GetComponent<PlayerShoot>().weapon == "sniper")
            {
                health -= 13;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Rocket")
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
            if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 92)
            {
                health -= 3;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().deathBought && Random.Range(1, 151) == 1)
            {
                health = 0;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 96)
            {
                health -= 2;
            }
        }
        else if (collision.gameObject.tag == "Player")
        {
            gameManager.GetComponent<Game_Manager>().KillEnemy();
            Destroy(gameObject);
        }
    }
}
