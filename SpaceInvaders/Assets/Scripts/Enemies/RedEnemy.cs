using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    public float moveSpeed;
    GameObject player;
    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<Game_Manager>().enemiesLeft++;
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = (player.transform.position - transform.position) * -1;
        GetComponent<Rigidbody2D>().velocity = transform.up * -moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Rocket")
        {
            gameManager.GetComponent<Game_Manager>().enemiesLeft--;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Laser")
        {
            gameManager.GetComponent<Game_Manager>().enemiesLeft--;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            gameManager.GetComponent<Game_Manager>().enemiesLeft--;
            Destroy(gameObject);
        }
    }
}
