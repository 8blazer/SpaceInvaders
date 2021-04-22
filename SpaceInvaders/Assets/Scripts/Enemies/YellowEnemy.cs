using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEnemy : MonoBehaviour
{
    public float moveSpeed;
    GameObject player;
    int health = 50;

    void Start()
    {
        player = GameObject.Find("Player");
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
