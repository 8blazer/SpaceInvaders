using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEnemy : MonoBehaviour
{
    public float moveSpeed;
    GameObject player;
    GameObject gameManager;
    GameObject upgradeCanvas;
    int health = 50;

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
        if (transform.position.y > -2.5f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
        }
        else if (player.transform.position.x - transform.position.x > .3f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
        }
        else if (player.transform.position.x - transform.position.x < -.3f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        if (health < 1)
        {
            gameManager.GetComponent<Game_Manager>().KillEnemy();
            Destroy(gameObject);
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
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Laser")
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
            Destroy(collision.gameObject);
        }
    }
}
