using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossExplosion : MonoBehaviour
{
    public Color color;
    bool moveRight = true;
    public float moveSpeed;
    float xStart;
    public GameObject explosion;
    float explosionTimer;

    float testTimer;
    // Start is called before the first frame update
    void Start()
    {
        xStart = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        testTimer += Time.deltaTime;
        if (testTimer > 2)
        {
            color += new Color(-.5f * Time.deltaTime, -.5f * Time.deltaTime, -.5f * Time.deltaTime, .5f * Time.deltaTime);
            GetComponent<SpriteRenderer>().color = color;

            if (moveRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
                if (transform.position.x > xStart + .15f)
                {
                    moveRight = false;
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
                if (transform.position.x < xStart - .15f)
                {
                    moveRight = true;
                }
            }

            explosionTimer += Time.deltaTime;
            if (explosionTimer > .3f)
            {
                explosionTimer = 0;
                Instantiate(explosion, transform.position += new Vector3(Random.Range(-1f, 1.1f), Random.Range(-.6f, .7f), 0), Quaternion.identity);
            }
        }
    }
}
