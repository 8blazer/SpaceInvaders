using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public int ammo = 100;
    public int ammoMax = 100;
    public float reloadTime = .01f;
    float reloadTimeOriginal;
    float reloadTimer;
    public float ammoRegenTime = .01f;
    float ammoRegenOriginal;
    float ammoRegenTimer;
    public string weapon = "minigun";
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public GameObject laserPrefab;
    public GameObject shellPrefab;
    public float shellSpeed;
    public int shellCount = 10;

    // Start is called before the first frame update
    void Start()
    {
        ammoRegenOriginal = ammoRegenTime;
        reloadTimeOriginal = reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        reloadTimer += Time.deltaTime;
        if (ammo > 0 && Input.GetKey(KeyCode.Space) && reloadTimer > reloadTime)
        {
            ammoRegenTimer = 0;
            reloadTimer = 0;
            Fire();

            if (ammo == 0)
            {
                reloadTime = 3;
                ammoRegenTime = 3;
            }
        }
        else if (!Input.GetKey(KeyCode.Space) && ammo < ammoMax)
        {
            ammoRegenTimer += Time.deltaTime;
            if (ammoRegenTimer > ammoRegenTime)
            {
                ammo++;
                ammoRegenTimer = 0;
                ammoRegenTime = ammoRegenOriginal;
                reloadTime = reloadTimeOriginal;
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
        }
        else if (weapon == "minigun")
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(-.2f, .1f, 0), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed * 1.5f);
            bullet = Instantiate(bulletPrefab, transform.position + new Vector3(.2f, .1f, 0), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed * 1.5f);
        }
        else if (weapon == "shotgun")
        {
            int i = 0;
            while (i < shellCount)
            {
                GameObject shell = Instantiate(shellPrefab, transform.position + new Vector3(0f, .1f, 0), Quaternion.identity);
                shell.transform.Rotate(0, 0, Random.Range(-10, 11));
                shell.GetComponent<Rigidbody2D>().velocity = transform.right * new Vector2(0, shellSpeed + Random.Range(-.5f, .6f));
                i++;
            }
        }
    }
}
