using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    float timer = 0;
    public float lifeTime = 5;
    public Sprite rocketSprite;
    Collider2D[] colliders;
    GameObject enemyDetected;
    public float rocketDetectionRange;
    public float rocketSpeed;
    bool rocketExplode = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifeTime)
        {
            Destroy(gameObject);
        }

        if (rocketExplode && timer < lifeTime - .5f)
        {
            timer = lifeTime - .45f;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (GetComponent<SpriteRenderer>().sprite == rocketSprite)
        {
            if (enemyDetected == null)
            {
                colliders = Physics2D.OverlapCircleAll(transform.position, rocketDetectionRange);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject.tag == "Enemy")
                    {
                        enemyDetected = collider.gameObject;
                    }
                }
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, rocketSpeed);
            }
            else
            {
                float distance;
                distance = Vector2.Distance(transform.position, enemyDetected.transform.position);
                if (distance > rocketDetectionRange)
                {
                    enemyDetected = null;
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    transform.up = (enemyDetected.transform.position - transform.position);
                    GetComponent<Rigidbody2D>().velocity = transform.up * rocketSpeed;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (GetComponent<SpriteRenderer>().sprite == rocketSprite && player.gameObject.tag == "Enemy")
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            rocketExplode = true;
        }
    }
}
