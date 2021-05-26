using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperCyan : MonoBehaviour
{
    public float horizSpeed;
    public float vertSpeed;
    float tempVertSpeed;
    public float vertSpeedChange;
    GameObject player;
    GameObject gameManager;
    float health = 350;
    bool moveRight;
    public bool swooping = false;
    public bool diving = false;
    int diveDown = 0;
    Vector3 divePosition;
    public float diveSpeed;
    public float timer;
    public float swoopTime;
    bool spawned = false;
    public Vector2 savedVelocity = new Vector2(0, 0);

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
            if (!swooping && !diving)
            {
                timer += Time.deltaTime;
            }
            if (timer > swoopTime)
            {
                if (swoopTime < 3)
                {
                    swoopTime += Random.Range(0, 3);
                }
                else if (swoopTime > 5)
                {
                    swoopTime += Random.Range(-2, 0);
                }
                else
                {
                    swoopTime += Random.Range(-1, 2);
                }
                if (Random.Range(1, 3) == 1)
                {
                    Debug.Log("swoop");
                    swooping = true;
                    tempVertSpeed = vertSpeed;
                    if (player.transform.position.x > transform.position.x)
                    {
                        moveRight = true;
                    }
                    else
                    {
                        moveRight = false;
                    }
                }
                else
                {
                    Debug.Log("dive");
                    diving = true;
                }
                timer = 0;
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
            }
            else if (diving)
            {
                if (diveDown == 0)
                {
                    divePosition = transform.position;
                    transform.up = player.transform.position - transform.position;
                    GetComponent<Rigidbody2D>().velocity = transform.up * diveSpeed;
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    diveDown = 1;
                }
                else if (diveDown == 1)
                {
                    if (transform.position.y < -9)
                    {
                        GetComponent<Rigidbody2D>().velocity *= new Vector2(1, -1);
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        diveDown = 2;
                    }
                }
                else
                {
                    if (transform.position.y > divePosition.y)
                    {
                        diving = false;
                        diveDown = 0;
                        GetComponent<Rigidbody2D>().velocity = new Vector2(horizSpeed, 0);
                    }
                }
            }
            else if (moveRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(horizSpeed, 0);
                if (transform.position.x > 7f)
                {
                    moveRight = false;
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-horizSpeed, 0);
                if (transform.position.x < -7f)
                {
                    moveRight = true;
                }
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -horizSpeed);
            if (transform.position.y < 3.3f)
            {
                spawned = true;
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
