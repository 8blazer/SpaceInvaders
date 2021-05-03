using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemy : MonoBehaviour
{
    int health = 10;
    public float moveSpeed;
    public float shootSpeed;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    GameObject player;
    GameObject gameManager;
    GameObject upgradeCanvas;
    float shootTimer;
    public float poofPower;
    public float poofLoss;
    bool poof;
    float poofTimer;

    public GameObject lifeDrop;
    public GameObject minigunDrop;
    public GameObject laserDrop;
    public GameObject shotgunDrop;
    public GameObject sniperDrop;
    public GameObject rocketDrop;

    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        upgradeCanvas = GameObject.Find("UpgradeCanvas");
        gameManager.GetComponent<Game_Manager>().AddEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        poofTimer += Time.deltaTime;
        if (poof)
        {
            if (GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                GetComponent<Rigidbody2D>().velocity -= new Vector2(poofLoss * .7f, poofLoss) * Time.deltaTime;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity -= new Vector2(-poofLoss * .7f, poofLoss) * Time.deltaTime;
            }
            if (GetComponent<Rigidbody2D>().velocity.y < .1f)
            {
                poof = false;
            }
        }

        if ((shootTimer > shootSpeed || transform.position.y < -3 || (transform.position.y < 2 && Mathf.Abs(transform.position.x - player.transform.position.x) < 1)) && !poof)
        {
            int i = 0;
            if (transform.position.x > player.transform.position.x)
            {
                poof = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, poofPower);
            }
            else
            {
                poof = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, poofPower);
            }
            if (!player.GetComponent<PlayerAbility>().jammed)
            {
                while (i < 5)
                {
                    GameObject shell = Instantiate(bulletPrefab, transform.position + new Vector3(0f, .1f, 0), Quaternion.identity);
                    shell.transform.Rotate(0, 0, Random.Range(-30, 31));
                    shell.GetComponent<Rigidbody2D>().velocity = shell.transform.up * -(bulletSpeed + Random.Range(-.5f, .5f)); // new Vector2(0, shellSpeed + Random.Range(-.5f, .6f));
                    i++;
                }
            }
            shootTimer = 0;
            poofTimer = 0;
        }
        else if (!poof)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
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
            else if (upgradeCanvas.GetComponent<Upgrades>().deathBought && Random.Range(1,151) == 1)
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
    }
}
