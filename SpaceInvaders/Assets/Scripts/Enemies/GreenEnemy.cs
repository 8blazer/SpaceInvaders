using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : MonoBehaviour
{
    int health = 3;
    public float moveSpeed;
    public float shootSpeed;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    float timer;
    bool moveRight;
    bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        shootSpeed = Random.Range(1.5f, 3.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned)
        {
            timer += Time.deltaTime;
            if (timer > shootSpeed)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
                timer = 0;
                shootSpeed = Random.Range(1.5f, 3.1f);
            }
            if (moveRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
                if (transform.position.x > 8.5f)
                {
                    moveRight = false;
                    transform.position += new Vector3(0, -.5f, 0);
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
                if (transform.position.x < -8.5f)
                {
                    moveRight = true;
                    transform.position += new Vector3(0, -.5f, 0);
                }
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
            if (transform.position.y < 4)
            {
                spawned = true;
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
