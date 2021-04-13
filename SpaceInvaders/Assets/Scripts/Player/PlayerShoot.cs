using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public int ammo = 100;
    public int ammoMax = 100;
    public float reloadTime = .02f;
    float reloadTimer;
    public float ammoRegenTime = .01f;
    float ammoRegenTimer;
    public string weapon = "minigun";
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public GameObject laserPrefab;
    public GameObject shellPrefab;
    public float shellSpeed;
    public GameObject rocketPrefab;
    public int shellCount = 10;
    bool canShoot = true;
    float burnoutTimer;
    public Text ammoText;
    
    void Update()
    {
        ammoText.text = "Ammo: " + ammo.ToString();
        reloadTimer += Time.deltaTime;
        if (ammo > ammoMax) //If switched to weapon with less ammo
        {
            ammo = ammoMax;
        }
        if (!canShoot)  //Burnout recharge timer
        {
            burnoutTimer += Time.deltaTime;
            if (burnoutTimer > 3)
            {
                canShoot = true;
                burnoutTimer = 0;
            }
        }
        if (ammo > 0 && Input.GetKey(KeyCode.Space) && reloadTimer > reloadTime && canShoot && (weapon == "machinegun" || weapon == "minigun" || weapon == "missile"))
        {
            ammoRegenTimer = 0;
            reloadTimer = 0;
            Fire();

            if (ammo == 0)
            {
                canShoot = false;
            }
        }
        else if (ammo > 0 && Input.GetKeyDown(KeyCode.Space) && reloadTimer > reloadTime && canShoot)
        {
            ammoRegenTimer = 0;
            reloadTimer = 0;
            Fire();

            if (ammo == 0)
            {
                canShoot = false;
            }
        }
        else if (!Input.GetKey(KeyCode.Space) && ammo < ammoMax)
        {
            ammoRegenTimer += Time.deltaTime;
            if (ammoRegenTimer > ammoRegenTime)
            {
                ammo++;
                ammoRegenTimer = 0;
            }
        }
    }

    void Fire()
    {
        ammo--;
        if (weapon == "machinegun")
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, .1f, 0), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);

            ammoMax = 50;   //These lines of code in each weapon block should be replaced by the pickup script later
            reloadTime = .12f;
            ammoRegenTime = .015f;
        }
        else if (weapon == "minigun")
        {
            ammo--;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(-.2f, .1f, 0), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed * 1.5f);
            bullet = Instantiate(bulletPrefab, transform.position + new Vector3(.2f, .1f, 0), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed * 1.5f);

            ammoMax = 75;
            reloadTime = .08f;
            ammoRegenTime = .015f;
        }
        else if (weapon == "shotgun")
        {
            int i = 0;
            while (i < shellCount)
            {
                GameObject shell = Instantiate(shellPrefab, transform.position + new Vector3(0f, .1f, 0), Quaternion.identity);
                shell.transform.Rotate(0, 0, Random.Range(-30, 31));
                shell.GetComponent<Rigidbody2D>().velocity = shell.transform.up * (shellSpeed + Random.Range(-.5f, .5f)); // new Vector2(0, shellSpeed + Random.Range(-.5f, .6f));
                i++;
            }

            ammoMax = 10;
            reloadTime = .75f;
            ammoRegenTime = 1f;
        }
        else if (weapon == "laser")
        {
            GameObject laser = Instantiate(laserPrefab, transform.position + new Vector3(0, 7.5f, 0), Quaternion.identity);

            ammoMax = 10;
            reloadTime = .075f;
            ammoRegenTime = .2f;
        }
        else if (weapon == "sniper")
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, .1f, 0), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed * 5);

            ammoMax = 10;
            reloadTime = 1f;
            ammoRegenTime = 1.5f;
        }
        else if (weapon == "rocket")
        {
            GameObject rocket = Instantiate(rocketPrefab, transform.position + new Vector3(0, .1f, 0), Quaternion.identity);

            ammoMax = 10;
            reloadTime = .5f;
            ammoRegenTime = 1f;
        }
    }
}
