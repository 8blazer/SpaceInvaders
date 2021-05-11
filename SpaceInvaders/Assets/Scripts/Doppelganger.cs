using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doppelganger : MonoBehaviour
{
    public float moveSpeed = 5;
    public bool canMove = true;
    public ParticleSystem deathParticles;

    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float reloadTime = .12f;
    float reloadTimer;

    public float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer += Time.deltaTime;
        if (canMove)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && transform.position.x < 8)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && transform.position.x > -8)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
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

        reloadTimer += Time.deltaTime;
        if (reloadTimer > reloadTime && canMove)
        {
            reloadTimer = 0;
            Shoot();
        }
    }

    public void Death()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        deathParticles.Play();
        canMove = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Doppelganger>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (lifeTimer > 2)
        {
            if (player.gameObject.tag == "E_Bullet")
            {
                Death();
                if (player.gameObject.name != "UFO_Laser")
                {
                    Destroy(player.gameObject);
                }
            }
            else if (player.gameObject.tag == "Enemy")
            {
                Death();
            }
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, .1f, 0), Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
    }
}
