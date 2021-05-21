using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    public float moveSpeed;
    GameObject player;
    GameObject gameManager;
    public int health = 1;

    public GameObject lifeDrop;
    public GameObject minigunDrop;
    public GameObject laserDrop;
    public GameObject shotgunDrop;
    public GameObject sniperDrop;
    public GameObject rocketDrop;

    public float jitterTimer;
    float jitterTime;
    public Sprite crazy;
    Vector2 jitterVelocity;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<Game_Manager>().AddEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        jitterTimer += Time.deltaTime;
        if (PlayerPrefs.GetString("challenge") == "CrazyEnemy" && jitterTimer > jitterTime)
        {
            jitterVelocity = new Vector2(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
            jitterTimer = 0;
        }
        transform.up = (player.transform.position - transform.position) * -1;
        GetComponent<Rigidbody2D>().velocity = transform.up * -moveSpeed;
        GetComponent<Rigidbody2D>().velocity += jitterVelocity;
        if (health < 1 || gameManager.GetComponent<Game_Manager>().wave == 13 || player.GetComponent<PlayerMovement>().lost)
        {
            gameManager.GetComponent<Game_Manager>().KillEnemy();
            player.GetComponent<PlayerMovement>().kills++;
            int i = Random.Range(1, 401);
            if (i == 1)
            {
                Instantiate(lifeDrop, transform.position, Quaternion.identity);
            }
            else if (i == 2 && PlayerPrefs.GetString("challenge") != "Weapon")
            {
                Instantiate(minigunDrop, transform.position, Quaternion.identity);
            }
            else if (i == 3 && PlayerPrefs.GetString("challenge") != "Weapon")
            {
                Instantiate(laserDrop, transform.position, Quaternion.identity);
            }
            else if (i == 4 && PlayerPrefs.GetString("challenge") != "Weapon")
            {
                Instantiate(rocketDrop, transform.position, Quaternion.identity);
            }
            else if (i == 5 && PlayerPrefs.GetString("challenge") != "Weapon")
            {
                Instantiate(shotgunDrop, transform.position, Quaternion.identity);
            }
            else if (i == 6 && PlayerPrefs.GetString("challenge") != "Weapon")
            {
                Instantiate(sniperDrop, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

        if (player.GetComponent<PlayerAbility>().frozen)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Rocket" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "SuperShot")
        {
            health = 0;
            if (collision.gameObject.tag == "Bullet")
            {
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
        }
    }
}
