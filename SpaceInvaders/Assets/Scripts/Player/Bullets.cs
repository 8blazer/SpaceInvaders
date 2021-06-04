using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    float timer = 0;
    public float lifeTime = 5;
    public Sprite rocketSprite;
    public Sprite enemyBullet;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    Collider2D[] colliders;
    GameObject enemyDetected;
    public float rocketDetectionRange;
    public float rocketSpeed;
    GameObject gameManager;

    public float jitterTimer;
    float jitterTime;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        jitterTimer += Time.deltaTime;
        if (PlayerPrefs.GetString("challenge") == "CrazyEnemy" && jitterTimer > jitterTime && GetComponent<SpriteRenderer>().sprite == enemyBullet)
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2(Random.Range(-.1f, .1f), 0);
            jitterTimer = 0;
        }
        timer += Time.deltaTime;
        if (timer > lifeTime || gameManager.GetComponent<Game_Manager>().upgrading || transform.position.y > 10)
        {
            Destroy(gameObject);
        }
        if (timer > .78f && GetComponent<Animator>() != null)
        {
            if (GetComponent<Animator>().enabled)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
                bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
                bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
                Destroy(gameObject);
            }
        }

        if (GetComponent<SpriteRenderer>().sprite == rocketSprite)
        {
            if (enemyDetected == null)
            {
                colliders = Physics2D.OverlapCircleAll(transform.position, rocketDetectionRange);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject.tag == "Enemy")
                    {
                        enemyDetected = collider.gameObject;
                    }
                }
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, rocketSpeed);
            }
            else
            {
                float distance;
                distance = Vector2.Distance(transform.position, enemyDetected.transform.position);
                if (distance > rocketDetectionRange)
                {
                    enemyDetected = null;
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    transform.up = (enemyDetected.transform.position - transform.position);
                    GetComponent<Rigidbody2D>().velocity = transform.up * rocketSpeed;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<SpriteRenderer>().sprite == rocketSprite && collision.gameObject.tag == "Enemy")
        {
            if (!GetComponent<Animator>().enabled)
            {
                timer = 0;
                lifeTime = .8f;
            }
            GetComponent<Animator>().enabled = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
