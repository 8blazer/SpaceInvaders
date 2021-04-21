using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBossMini : MonoBehaviour
{
    int health = 25;
    public float moveSpeed;
    public float shootSpeed;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    float timer;
    float decayTimer;
    bool moveRight;
    GameObject player;
    GameObject mainBoss;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        mainBoss = GameObject.Find("YellowBoss");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (transform.position.y > 3 && transform.position.y < 4)
        {
            if (timer > shootSpeed)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.transform.up = (player.transform.position - transform.position);
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;
                timer = 0;
            }
            if (moveRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
                if (transform.position.x > 8.5f)
                {
                    moveRight = false;
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
                if (transform.position.x < -8.5f)
                {
                    moveRight = true;
                }
            }
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (transform.position.y > -6 && transform.position.y < 3)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
        }
        else if (transform.position.y < -6)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            transform.position += new Vector3(0, 14, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
        }
        if (health < 1)
        {
            Destroy(gameObject);
        }
        if (mainBoss == null)
        {
            decayTimer += Time.deltaTime;
            if (decayTimer > .1f)
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, GetComponent<SpriteRenderer>().color.a - .1f);
                decayTimer = 0;
            }
            if (GetComponent<SpriteRenderer>().color.a < .1f)
            {
                Destroy(gameObject);
            }
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
