using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    float invincTimer;
    public float invincTime;
    float flashTimer;
    public float flashTime;
    float respawnTimer;
    public float respawnTime;
    int health = 3;
    public ParticleSystem deathParticles;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && transform.position.x > -8)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && transform.position.x < 8)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (!canMove)
        {
            respawnTimer += Time.deltaTime;
            if (respawnTimer > respawnTime)
            {
                canMove = true;
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                respawnTimer = 0;
            }
        }

        if (!GetComponent<BoxCollider2D>().enabled && canMove)
        {
            invincTimer += Time.deltaTime;
            flashTimer += Time.deltaTime;
            if (flashTimer > flashTime)
            {
                if (GetComponent<SpriteRenderer>().color.a == 1)
                {
                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                }
                flashTimer = 0;
            }
            if (invincTimer > invincTime)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                invincTimer = 0;
            }
        }
    }

    public void Death()
    {
        if (GetComponent<BoxCollider2D>().enabled)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            deathParticles.Play();
            health--;
            canMove = false;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "E_Bullet")
        {
            Death();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Death();
        }
    }
}
