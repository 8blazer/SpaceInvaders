using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemy : MonoBehaviour
{
    float health = 10;
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
            if (!player.GetComponent<PlayerAbility>().jammed && !player.GetComponent<PlayerAbility>().frozen)
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

        if (health < 1 || gameManager.GetComponent<Game_Manager>().wave == 13 || player.GetComponent<PlayerMovement>().lost)
        {
            player.GetComponent<PlayerMovement>().kills++;
            gameManager.GetComponent<Game_Manager>().KillEnemy();
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
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
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
        else if (upgradeCanvas.GetComponent<Upgrades>().deathBought && Random.Range(1, 101) == 1)
        {
            health = 0;
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
            else if (upgradeCanvas.GetComponent<Upgrades>().deathBought && Random.Range(1, 101) == 1)
            {
                health = 0;
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
            if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 90)
            {
                health -= 5;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().deathBought && Random.Range(1, 101) == 1)
            {
                health = 0;
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
