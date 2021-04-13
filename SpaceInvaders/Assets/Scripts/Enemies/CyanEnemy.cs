using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyanEnemy : MonoBehaviour
{
    public float horizSpeed;
    public float vertSpeed;
    float tempVertSpeed;
    public float vertSpeedChange;
    GameObject player;
    int health = 10;
    bool moveRight;
    bool swooping = false;
    float timer;
    public float swoopTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > swoopTime)
        {
            if (swoopTime < 2)
            {
                swoopTime += Random.Range(0, 3);
            }
            else if (swoopTime > 4)
            {
                swoopTime += Random.Range(-2, 0);
            }
            else
            {
                swoopTime += Random.Range(-1, 2);
            }
            swooping = true;
            tempVertSpeed = vertSpeed;
            timer = 0;
            if (player.transform.position.x > transform.position.x)
            {
                moveRight = true;
            }
            else
            {
                moveRight = false;
            }
        }
        if (swooping)
        {
            if (moveRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(horizSpeed, tempVertSpeed);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-horizSpeed, tempVertSpeed);
            }
            if (-vertSpeed < tempVertSpeed)
            {
                swooping = false;
            }
            tempVertSpeed += vertSpeedChange * Time.deltaTime;
            timer = 0;
        }
        if (moveRight && !swooping)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(horizSpeed, 0);
            if (transform.position.x > 8.5f)
            {
                moveRight = false;
            }
        }
        else if (!swooping)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-horizSpeed, 0);
            if (transform.position.x < -8.5f)
            {
                moveRight = true;
            }
        }
        if (health < 1)
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
