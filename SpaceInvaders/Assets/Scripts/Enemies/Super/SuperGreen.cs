using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperGreen : MonoBehaviour
{
    float health = 325;
    public float moveSpeed;
    public float shootSpeed;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    GameObject gameManager;
    GameObject upgradeCanvas;
    GameObject player;
    float timer;
    bool moveRight;
    bool spawned = false;
    float spawnY = 3.5f;
    Slider healthbar;
    Image background;
    Image fill;
    Image handle;
    public Sprite handleSprite;

    // Start is called before the first frame update
    void Start()
    {
        shootSpeed = Random.Range(3.5f, 5.6f);
        upgradeCanvas = GameObject.Find("UpgradeCanvas");
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
        spawnY = Random.Range(3.0f, 4.6f);
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = health / 325;
        if (spawned)
        {
            timer += Time.deltaTime;
            if (timer > shootSpeed)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position - new Vector3(0, 1.3f, 0), Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
                bullet.transform.localScale = new Vector3(3, 3, 1);
                timer = 0;
                shootSpeed = Random.Range(1.5f, 2.5f);
            }
            if (moveRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed + ((400 - health) / 50), 0);
                if (transform.position.x > 7.5f)
                {
                    moveRight = false;
                    transform.position += new Vector3(0, -.5f, 0);
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed - ((400 - health) / 50), 0);
                if (transform.position.x < -7.5f)
                {
                    moveRight = true;
                    transform.position += new Vector3(0, -.5f, 0);
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
        if (health < 1 || transform.position.y < -4.5f || gameManager.GetComponent<Game_Manager>().wave == 13 || player.GetComponent<PlayerMovement>().lost)
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
