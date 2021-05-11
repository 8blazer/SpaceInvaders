using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6 || player.GetComponent<PlayerMovement>().lost)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > -4.9f && transform.position.y < -3)
        {
            if (Mathf.Abs(transform.position.x - player.transform.position.x) < .8f)
            {
                if (gameObject.name == "LifeDrop(Clone)")
                {
                    player.GetComponent<PlayerMovement>().lives++;
                    Destroy(gameObject);
                }
                else if (gameObject.name == "MinigunDrop(Clone)")
                {
                    player.GetComponent<PlayerShoot>().weapon = "minigun";
                    if (player.GetComponent<PlayerShoot>().ammoUpgrade)
                    {
                        player.GetComponent<PlayerShoot>().ammoMax = 50;
                    }
                    else
                    {
                        player.GetComponent<PlayerShoot>().ammoMax = 30;
                    }
                    player.GetComponent<PlayerShoot>().ammo = player.GetComponent<PlayerShoot>().ammoMax;
                    player.GetComponent<PlayerShoot>().reloadTime = .12f;
                    player.GetComponent<PlayerShoot>().ammoRegenTime = .015f;
                    Destroy(gameObject);
                }
                else if (gameObject.name == "ShotgunDrop(Clone)")
                {
                    player.GetComponent<PlayerShoot>().weapon = "shotgun";
                    if (player.GetComponent<PlayerShoot>().ammoUpgrade)
                    {
                        player.GetComponent<PlayerShoot>().ammoMax = 15;
                    }
                    else
                    {
                        player.GetComponent<PlayerShoot>().ammoMax = 10;
                    }
                    player.GetComponent<PlayerShoot>().ammo = player.GetComponent<PlayerShoot>().ammoMax;
                    player.GetComponent<PlayerShoot>().reloadTime = .6f;
                    player.GetComponent<PlayerShoot>().ammoRegenTime = .8f;
                    Destroy(gameObject);
                }
                else if (gameObject.name == "LaserDrop(Clone)")
                {
                    player.GetComponent<PlayerShoot>().weapon = "laser";
                    if (player.GetComponent<PlayerShoot>().ammoUpgrade)
                    {
                        player.GetComponent<PlayerShoot>().ammoMax = 20;
                    }
                    else
                    {
                        player.GetComponent<PlayerShoot>().ammoMax = 15;
                    }
                    player.GetComponent<PlayerShoot>().ammo = player.GetComponent<PlayerShoot>().ammoMax;
                    player.GetComponent<PlayerShoot>().reloadTime = .075f;
                    player.GetComponent<PlayerShoot>().ammoRegenTime = .3f;
                    Destroy(gameObject);
                }
                else if (gameObject.name == "RocketDrop(Clone)")
                {
                    player.GetComponent<PlayerShoot>().weapon = "rocket";
                    if (player.GetComponent<PlayerShoot>().ammoUpgrade)
                    {
                        player.GetComponent<PlayerShoot>().ammoMax = 20;
                    }
                    else
                    {
                        player.GetComponent<PlayerShoot>().ammoMax = 15;
                    }
                    player.GetComponent<PlayerShoot>().ammo = player.GetComponent<PlayerShoot>().ammoMax;
                    player.GetComponent<PlayerShoot>().reloadTime = .3f;
                    player.GetComponent<PlayerShoot>().ammoRegenTime = .5f;
                    Destroy(gameObject);
                }
                else if (gameObject.name == "SniperDrop(Clone)")
                {
                    player.GetComponent<PlayerShoot>().weapon = "sniper";
                    if (player.GetComponent<PlayerShoot>().ammoUpgrade)
                    {
                        player.GetComponent<PlayerShoot>().ammoMax = 25;
                    }
                    else
                    {
                        player.GetComponent<PlayerShoot>().ammoMax = 20;
                    }
                    player.GetComponent<PlayerShoot>().ammo = player.GetComponent<PlayerShoot>().ammoMax;
                    player.GetComponent<PlayerShoot>().reloadTime = .3f;
                    player.GetComponent<PlayerShoot>().ammoRegenTime = .4f;
                    Destroy(gameObject);
                }
            }
        }
    }
}
