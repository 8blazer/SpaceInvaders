using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperYellow : MonoBehaviour
{
    public float moveSpeed;
    GameObject player;
    GameObject gameManager;
    float health = 400;
    float dropTimer = 0;
    public float dropTime;

    Slider healthbar;
    Image background;
    Image fill;
    Image handle;
    public Sprite handleSprite;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player");
        healthbar = GameObject.Find("BossHealth").GetComponent<Slider>();
        background = GameObject.Find("BossHealth").transform.GetChild(0).GetComponent<Image>();
        fill = GameObject.Find("BossHealth").transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
        handle = GameObject.Find("BossHealth").transform.GetChild(2).transform.GetChild(0).GetComponent<Image>();
        background.enabled = true;
        fill.enabled = true;
        handle.enabled = true;
        handle.sprite = handleSprite;
        gameManager.GetComponent<Game_Manager>().AddEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = health / 400;
        if (transform.position.y > 0f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed - ((400 - health) / 80));
        }
        else if (dropTimer < dropTime)
        {
            dropTimer += Time.deltaTime;
            if (player.transform.position.x - transform.position.x > .3f)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed + ((400 - health) / 80), 0);
            }
            else if (player.transform.position.x - transform.position.x < -.3f)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed - ((400 - health) / 80), 0);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed - ((400 - health) / 80));
        }
        if (transform.position.y < -7)
        {
            transform.position = new Vector3(player.transform.position.x, 7, 0);
            if (dropTime > .5f)
            {
                dropTime -= .1f;
            }
            dropTimer = 0;
        }
        if (health < 1 || gameManager.GetComponent<Game_Manager>().wave == 13 || player.GetComponent<PlayerMovement>().lost)
        {
            gameManager.GetComponent<Game_Manager>().BossDeath();
            player.GetComponent<PlayerMovement>().kills++;
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
