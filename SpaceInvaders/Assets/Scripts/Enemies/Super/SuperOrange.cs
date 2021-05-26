using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperOrange : MonoBehaviour
{
    float health = 350;
    public float moveSpeed;
    public float shootSpeed;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    float timer;
    bool moveRight;
    int direction = 1; //1 = moving to top-right, 2 is bottom-right, so on
    float swapTimer;
    public float swapTime;
    GameObject player;
    GameObject gameManager;
    bool spawned = false;

    Slider healthbar;
    Image background;
    Image fill;
    Image handle;
    public Sprite handleSprite;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");

        healthbar = GameObject.Find("BossHealth").GetComponent<Slider>();
        background = GameObject.Find("BossHealth").transform.GetChild(0).GetComponent<Image>();
        fill = GameObject.Find("BossHealth").transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
        handle = GameObject.Find("BossHealth").transform.GetChild(2).transform.GetChild(0).GetComponent<Image>();
        background.enabled = true;
        fill.enabled = true;
        handle.enabled = true;
        handle.sprite = handleSprite;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = health / 350;
        if (spawned)
        {
            timer += Time.deltaTime;
            swapTimer += Time.deltaTime;
            if (timer > shootSpeed)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.transform.up = (player.transform.position - transform.position);
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;
                timer = 0;
                shootSpeed = Random.Range(1.0f, 4.0f);
            }
            if (swapTimer > swapTime)
            {
                swapTimer = 0;
                swapTime = Random.Range(.1f, 8.0f);
                if (moveRight)
                {
                    moveRight = false;
                }
                else
                {
                    moveRight = true;
                }
                if (direction == 1)
                {
                    direction = 3;
                }
                else if (direction == 2)
                {
                    direction = 4;
                }
                else if (direction == 3)
                {
                    direction = 1;
                }
                else
                {
                    direction = 2;
                }
            }
            if (direction == 1)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
                if (transform.position.x > 7f)
                {
                    if (moveRight)
                    {
                        direction = 2;
                    }
                    else
                    {
                        direction = 4;
                    }
                }
            }
            else if (direction == 2)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
                if (transform.position.y < 0f)
                {
                    if (moveRight)
                    {
                        direction = 3;
                    }
                    else
                    {
                        direction = 1;
                    }
                }
            }
            else if (direction == 3)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
                if (transform.position.x < -7f)
                {
                    if (moveRight)
                    {
                        direction = 4;
                    }
                    else
                    {
                        direction = 2;
                    }
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveSpeed);
                if (transform.position.y > 3f)
                {
                    if (moveRight)
                    {
                        direction = 1;
                    }
                    else
                    {
                        direction = 3;
                    }
                }
            }
            if (health < 1 || gameManager.GetComponent<Game_Manager>().wave == 13 || player.GetComponent<PlayerMovement>().lost)
            {
                if (!player.GetComponent<PlayerMovement>().lost)
                {
                    gameManager.GetComponent<Game_Manager>().BossDeath();
                    player.GetComponent<PlayerMovement>().kills++;
                }
                background.enabled = false;
                fill.enabled = false;
                handle.enabled = false;
                Destroy(gameObject);
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
            if (transform.position.y < 3.5f)
            {
                spawned = true;
            }
        }
    }

    public void Laser()
    {
        health--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            health--;
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
        }
    }
}
