using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperPurple : MonoBehaviour
{
    float health = 250;
    public float moveSpeed;
    public float shootSpeed;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    GameObject player;
    GameObject gameManager;
    float shootTimer;
    public float poofPower;
    public float poofLoss;
    bool poof;
    float poofTimer;

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
        healthbar.value = health / 250;
        shootTimer += Time.deltaTime;
        poofTimer += Time.deltaTime;
        if (poof)
        {
            if (GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                GetComponent<Rigidbody2D>().velocity -= new Vector2(poofLoss * .7f, poofLoss) * Time.deltaTime;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity -= new Vector2(-poofLoss * .7f, poofLoss) * Time.deltaTime;
            }
            if (GetComponent<Rigidbody2D>().velocity.y < .1f)
            {
                poof = false;
            }
        }

        if ((shootTimer > shootSpeed || transform.position.y < 2 || (transform.position.y < 2 && Mathf.Abs(transform.position.x - player.transform.position.x) < 1)) && !poof)
        {
            int i = 0;
            if (transform.position.x > player.transform.position.x)
            {
                poof = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, poofPower);
            }
            else
            {
                poof = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, poofPower);
            }
            if (!player.GetComponent<PlayerAbility>().jammed && !player.GetComponent<PlayerAbility>().frozen)
            {
                while (i < 5)
                {
                    GameObject shell = Instantiate(bulletPrefab, transform.position + new Vector3(0f, .1f, 0), Quaternion.identity);
                    shell.transform.Rotate(0, 0, Random.Range(-30, 31));
                    shell.GetComponent<Rigidbody2D>().velocity = shell.transform.up * -(bulletSpeed + Random.Range(-.5f, .5f)); // new Vector2(0, shellSpeed + Random.Range(-.5f, .6f));
                    i++;
                }
            }
            shootTimer = 0;
            poofTimer = 0;
        }
        else if (!poof)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
        }

        if (health < 1 || gameManager.GetComponent<Game_Manager>().wave == 13 || player.GetComponent<PlayerMovement>().lost)
        {
            if (!player.GetComponent<PlayerMovement>().lost)
            {
                gameManager.GetComponent<Game_Manager>().BossDeath();
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
