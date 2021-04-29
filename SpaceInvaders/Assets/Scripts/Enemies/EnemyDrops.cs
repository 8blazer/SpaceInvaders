using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "LifeDrop(Clone)")
            {
                collision.GetComponent<PlayerMovement>().lives++;
                Destroy(gameObject);
            }
            else if (gameObject.name == "MinigunDrop(Clone)")
            {
                collision.GetComponent<PlayerShoot>().weapon = "minigun";
                Destroy(gameObject);
            }
            else if (gameObject.name == "ShotgunDrop(Clone)")
            {
                collision.GetComponent<PlayerShoot>().weapon = "shotgun";
                Destroy(gameObject);
            }
            else if (gameObject.name == "LaserDrop(Clone)")
            {
                collision.GetComponent<PlayerShoot>().weapon = "laser";
                Destroy(gameObject);
            }
            else if (gameObject.name == "RocketDrop(Clone)")
            {
                collision.GetComponent<PlayerShoot>().weapon = "rocket";
                Destroy(gameObject);
            }
            else if (gameObject.name == "SniperDrop(Clone)")
            {
                collision.GetComponent<PlayerShoot>().weapon = "sniper";
                Destroy(gameObject);
            }
        }
    }
}
