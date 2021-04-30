using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBossBaby : MonoBehaviour
{
    public int health;
    bool up = true;
    bool down = false;
    public bool rejoin = false;
    bool targetPlayer;
    public float waitTime;
    float waitTimer;
    GameObject player;
    GameObject mainBoss;
    public GameObject miniPrefab;
    Transform destination;
    public float moveSpeed;
    GameObject upgradeCanvas;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(2, 4) == 3)
        {
            targetPlayer = true;
        }

        player = GameObject.Find("Player");
        mainBoss = GameObject.Find("YellowBoss(Clone)");
        upgradeCanvas = GameObject.Find("UpgradeCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            if (GetComponent<Rigidbody2D>().velocity.y == 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5, 6), 4);
            }
            if (transform.position.y > 8)
            {
                waitTimer += Time.deltaTime;
                if (waitTimer > waitTime)
                {
                    up = false;
                    transform.position = new Vector3(Random.Range(-7.5f, 7.6f), 8, 0);
                }
            }
        }
        else if (!down)
        {
            if (targetPlayer)
            {
                GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * moveSpeed;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = (new Vector3(Random.Range(-7.5f, 7.5f), -4, 0) - transform.position).normalized * moveSpeed;
            }
            down = true;
        }

        if (transform.position.y < -11)
        {
            rejoin = true;
            transform.position = new Vector3(transform.position.x, 8, 0);
        }

        if (rejoin)
        {
            if (mainBoss == null)
            {
                Destroy(gameObject);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = (mainBoss.transform.position - transform.position).normalized * moveSpeed;
            }
        }

        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, health * .025f);
        if (health < 20)
        {
            GameObject mini = Instantiate(miniPrefab, transform.position + new Vector3(.5f, 0, 0), Quaternion.identity);
            mini.GetComponent<YellowBossMini>().moveSpeed = Random.Range(5.0f, 10.0f);
            mini.GetComponent<YellowBossMini>().shootSpeed = Random.Range(2.0f, 5.0f);
            mini = Instantiate(miniPrefab, transform.position + new Vector3(-.5f, 0, 0), Quaternion.identity);
            mini.GetComponent<YellowBossMini>().moveSpeed = Random.Range(5.0f, 10.0f);
            mini.GetComponent<YellowBossMini>().shootSpeed = Random.Range(2.0f, 5.0f);
            Destroy(gameObject);
        }
        if (mainBoss == null) //maybe deleted after upgrade menu fades in?
        {
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
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Rocket")
        {
            health = health - 8;
            Destroy(collision.gameObject);
        }
    }
}
