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
        transform.up = (player.transform.position - transform.position) * -1;
        GetComponent<Rigidbody2D>().velocity = transform.up * -moveSpeed;
        if (health < 1)
        {
            gameManager.GetComponent<Game_Manager>().KillEnemy();
            int i = Random.Range(1, 401);
            if (i == 1)
            {
                Instantiate(lifeDrop, transform.position, Quaternion.identity);
            }
            else if (i == 2)
            {
                Instantiate(minigunDrop, transform.position, Quaternion.identity);
            }
            else if (i == 3)
            {
                Instantiate(laserDrop, transform.position, Quaternion.identity);
            }
            else if (i == 4)
            {
                Instantiate(rocketDrop, transform.position, Quaternion.identity);
            }
            else if (i == 5)
            {
                Instantiate(shotgunDrop, transform.position, Quaternion.identity);
            }
            else if (i == 6)
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
