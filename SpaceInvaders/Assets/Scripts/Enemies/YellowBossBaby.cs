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
    Transform destination;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(2, 4) == 3)
        {
            targetPlayer = true;
        }

        player = GameObject.Find("Player");
        mainBoss = GameObject.Find("YellowBoss");
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
            GetComponent<Rigidbody2D>().velocity = (mainBoss.transform.position - transform.position).normalized * moveSpeed;
        }

        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, health * .02f);
        if (health < 25)
        {
            Destroy(gameObject);
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
        if (collision.gameObject.tag == "Laser")
        {
            health--;
        }
        if (collision.gameObject.tag == "Rocket")
        {
            health = health - 8;
            Destroy(collision.gameObject);
        }
    }
}