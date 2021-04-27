using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    public float moveSpeed;
    GameObject player;
    GameObject gameManager;
    int health = 1;

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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Rocket")
        {
            health = 0;
        }
        else if (collision.gameObject.tag == "Laser")
        {
            health = 0;
        }
        else if (collision.gameObject.tag == "Player")
        {
            health = 0;
        }
    }
}
