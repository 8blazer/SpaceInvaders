using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEnemy : MonoBehaviour
{
    public float moveSpeed;
    GameObject player;
    GameObject gameManager;
    GameObject upgradeCanvas;
    float health = 50;
    float dropTimer = 0;
    public float dropTime;
	public Sprite spike;

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
            jitterVelocity = new Vector2(Random.Range(-7.0f, 7.0f), 0);
            jitterTimer = 0;
        }
		if (dropTimer > dropTime * .85f)
		{
			GetComponent<SpriteRenderer>().sprite = spike;
		}
        if (transform.position.y > -2.0f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed) + jitterVelocity;
        }
        else if (dropTimer < dropTime)
        {
            dropTimer += Time.deltaTime;
            if (player.transform.position.x - transform.position.x > .3f)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0) + jitterVelocity;
            }
            else if (player.transform.position.x - transform.position.x < -.3f)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0) + jitterVelocity;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0) + jitterVelocity;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed) + jitterVelocity;
        }
        if (health < 1 || gameManager.GetComponent<Game_Manager>().wave == 13 || player.GetComponent<PlayerMovement>().lost || transform.position.y < -4.5f)
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
            health -= collision.transform.localScale.x * 2;
        }
    }
}
