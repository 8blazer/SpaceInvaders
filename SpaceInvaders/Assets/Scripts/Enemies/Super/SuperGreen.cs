using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperGreen : MonoBehaviour
{
    float health = 450;
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
    float spawnY = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        shootSpeed = Random.Range(3.5f, 5.6f);
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
                GameObject bullet = Instantiate(bulletPrefab, transform.position - new Vector3(0, 1.3f, 0), Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
                bullet.transform.localScale = new Vector3(3, 3, 1);
                timer = 0;
                shootSpeed = Random.Range(1.5f, 2.5f);
            }
            if (moveRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
                if (transform.position.x > 7.5f)
                {
                    moveRight = false;
                    transform.position += new Vector3(0, -.5f, 0);
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
                if (transform.position.x < -7.5f)
                {
                    moveRight = true;
                    transform.position += new Vector3(0, -.5f, 0);
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
        if (health < 1 || transform.position.y < -4.5f || gameManager.GetComponent<Game_Manager>().wave == 13 || player.GetComponent<PlayerMovement>().lost)
        {
            gameManager.GetComponent<Game_Manager>().BossDeath();
            player.GetComponent<PlayerMovement>().kills++;
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
            if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 90)
            {
                health -= 5;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 95)
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
        else if (collision.gameObject.tag == "Rocket")
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
    }
}
