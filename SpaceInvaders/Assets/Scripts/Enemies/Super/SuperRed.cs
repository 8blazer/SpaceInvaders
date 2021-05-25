using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperRed : MonoBehaviour
{
    public float moveSpeed;
    GameObject player;
    GameObject gameManager;
    float health = 300;
    float lockOnTimer;
    public float lockOnTime;

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
        healthbar.value = health / 300;
        if (transform.position.y > 6)
        {
            transform.up = (player.transform.position - transform.position) * -1;
        }
        else
        {
            if (lockOnTimer < lockOnTime)
            {
                transform.up = (player.transform.position - transform.position) * -1;
                lockOnTimer += Time.deltaTime;
            }
        }
        GetComponent<Rigidbody2D>().velocity = transform.up * -moveSpeed;
        if (transform.position.y < -7)
        {
            transform.position += new Vector3(0, 14, 0);
            lockOnTime += .2f;
            lockOnTimer = 0;
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
