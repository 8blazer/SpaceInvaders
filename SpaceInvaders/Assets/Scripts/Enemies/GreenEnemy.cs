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
    GameObject gameManager;
    float timer;
    bool moveRight;
    bool spawned = false;
    float spawnY;
    // Start is called before the first frame update
    void Start()
    {
        shootSpeed = Random.Range(1.5f, 3.1f);
        gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<Game_Manager>().AddEnemy();
        spawnY = Random.Range(3.0f, 4.6f);
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
                shootSpeed = Random.Range(3.0f, 4.6f);
            }
            if (moveRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
                if (transform.position.x > 8.5f)
                {
                    moveRight = false;
                    transform.position += new Vector3(0, -1f, 0);
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
                if (transform.position.x < -8.5f)
                {
                    moveRight = true;
                    transform.position += new Vector3(0, -1f, 0);
                }
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
            if (transform.position.y < spawnY)
            {
                spawned = true;
            }
        }
        if (health < 1 || transform.position.y < -4.5f)
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
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Laser")
        {
            health--;
        }
        else if (collision.gameObject.tag == "Rocket")
        {
            health = health - 8;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            gameManager.GetComponent<Game_Manager>().KillEnemy();
            Destroy(gameObject);
        }
    }
}
