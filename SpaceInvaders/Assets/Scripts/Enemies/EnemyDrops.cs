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
                collision.GetComponent<PlayerShoot>().ammoMax = 40;
                collision.GetComponent<PlayerShoot>().reloadTime = .12f;
                collision.GetComponent<PlayerShoot>().ammoRegenTime = .015f;
                Destroy(gameObject);
            }
            else if (gameObject.name == "ShotgunDrop(Clone)")
            {
                collision.GetComponent<PlayerShoot>().weapon = "shotgun";
                collision.GetComponent<PlayerShoot>().ammoMax = 10;
                collision.GetComponent<PlayerShoot>().reloadTime = .6f;
                collision.GetComponent<PlayerShoot>().ammoRegenTime = .8f;
                Destroy(gameObject);
            }
            else if (gameObject.name == "LaserDrop(Clone)")
            {
                collision.GetComponent<PlayerShoot>().weapon = "laser";
                collision.GetComponent<PlayerShoot>().ammoMax = 15;
                collision.GetComponent<PlayerShoot>().reloadTime = .075f;
                collision.GetComponent<PlayerShoot>().ammoRegenTime = .3f;
                Destroy(gameObject);
            }
            else if (gameObject.name == "RocketDrop(Clone)")
            {
                collision.GetComponent<PlayerShoot>().weapon = "rocket";
                collision.GetComponent<PlayerShoot>().ammoMax = 15;
                collision.GetComponent<PlayerShoot>().reloadTime = .3f;
                collision.GetComponent<PlayerShoot>().ammoRegenTime = .75f;
                Destroy(gameObject);
            }
            else if (gameObject.name == "SniperDrop(Clone)")
            {
                collision.GetComponent<PlayerShoot>().weapon = "sniper";
                collision.GetComponent<PlayerShoot>().ammoMax = 20;
                collision.GetComponent<PlayerShoot>().reloadTime = .3f;
                collision.GetComponent<PlayerShoot>().ammoRegenTime = .4f;
                Destroy(gameObject);
            }
        }
    }
}
