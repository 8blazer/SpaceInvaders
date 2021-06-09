using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public int ammo = 50;
    public int ammoMax = 50;
    public bool ammoUpgrade = false;
    public float reloadTime = .12f;
    float reloadTimer;
    public float ammoRegenTime = .015f;
    float ammoRegenTimer;
    public string weapon = "machinegun";
    public string superWeapon = "";
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public GameObject laserPrefab;
    public GameObject shellPrefab;
    public float shellSpeed;
    public GameObject rocketPrefab;
    public GameObject superShot;
    public GameObject ultraShot;
    public int shellCount = 10;
    public bool canShoot = true;
    float burnoutTimer;
    public Text ammoText;
    RaycastHit2D[] collisions;
    public ParticleSystem smoke;
	public AudioClip machinegunSound;
	public AudioClip laserSound;
	public AudioClip rocketSound;
	GameObject saveManager;

    private void Start()
    {
		saveManager = GameObject.Find("SaveManager");

		weapon = PlayerPrefs.GetString("weapon");
        if (weapon == "minigun")
        {
            ammo = 30;
            ammoMax = 30;
            reloadTime = .12f;
            ammoRegenTime = .015f;
        }
        else if (weapon == "shotgun")
        {
            ammo = 10;
            ammoMax = 10;
            reloadTime = .6f;
            ammoRegenTime = .8f;
        }
        else if (weapon == "laser")
        {
            ammo = 15;
            ammoMax = 15;
            reloadTime = .075f;
            ammoRegenTime = .3f;
        }
        else if (weapon == "sniper")
        {
            ammo = 20;
            ammoMax = 20;
            reloadTime = .3f;
            ammoRegenTime = .4f;
        }
        else if (weapon == "rocket")
        {
            ammo = 15;
            ammoMax = 15;
            reloadTime = .3f;
            ammoRegenTime = .5f;
        }
    }

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
            if (smoke.isStopped)
            {
                smoke.Play();
            }
            if (burnoutTimer > 3.5f)
            {
                canShoot = true;
                burnoutTimer = 0;
                smoke.Stop();
            }
        }
        if (ammo > 0 && Input.GetKey(KeyCode.Space) && reloadTimer > reloadTime && canShoot && (weapon == "machinegun" || weapon == "minigun") && GetComponent<PlayerMovement>().canMove && Time.timeScale == 1)
        {
            ammoRegenTimer = 0;
            reloadTimer = 0;
            Fire();

            if (ammo < 1)
            {
                canShoot = false;
            }
        }
        else if (ammo > 0 && Input.GetKeyDown(KeyCode.Space) && reloadTimer > reloadTime && canShoot && GetComponent<PlayerMovement>().canMove && Time.timeScale == 1)
        {
            ammoRegenTimer = 0;
            reloadTimer = 0;
            Fire();

            if (ammo == 0)
            {
                canShoot = false;
            }
        }
        else if ((!Input.GetKey(KeyCode.Space) || !canShoot) && ammo < ammoMax)
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
        if (PlayerPrefs.GetString("challenge") == "Ammo")
        {
            ammo--;
            ammo--;
        }
        if (superWeapon == "")
        {
            if (weapon == "machinegun")
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, .1f, 0), Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
				if (saveManager.GetComponent<SaveManager>().sound)
				{
					GetComponent<AudioSource>().clip = machinegunSound;
					GetComponent<AudioSource>().Play();
				}
            }
            else if (weapon == "minigun")
            {
                ammo--;
                GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(-.2f, .1f, 0), Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed * 1.5f);
                bullet = Instantiate(bulletPrefab, transform.position + new Vector3(.2f, .1f, 0), Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed * 1.5f);
				if (saveManager.GetComponent<SaveManager>().sound)
				{
					GetComponent<AudioSource>().clip = machinegunSound;
					GetComponent<AudioSource>().Play();
				}
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
				if (saveManager.GetComponent<SaveManager>().sound)
				{
					GetComponent<AudioSource>().clip = rocketSound;
					GetComponent<AudioSource>().Play();
				}
			}
            else if (weapon == "laser")
            {
                GameObject laser = Instantiate(laserPrefab, transform.position + new Vector3(0, 7.5f, 0), Quaternion.identity);
                float xOffset = -.06f;
                while (xOffset < .06f)
                {
                    collisions = Physics2D.RaycastAll(transform.position, transform.up, 10);
                    int i = 0;
                    while (i < collisions.Length)
                    {
                        if (collisions[i].transform.gameObject.name == "GreenEnemy(Clone)")
                        {
                            collisions[i].transform.GetComponent<GreenEnemy>().Laser();
                        }
                        else if (collisions[i].transform.gameObject.name == "YellowEnemy(Clone)")
                        {
                            collisions[i].transform.GetComponent<YellowEnemy>().Laser();
                        }
                        else if (collisions[i].transform.gameObject.name == "RedEnemy(Clone)")
                        {
                            collisions[i].transform.GetComponent<RedEnemy>().health = 0;
                        }
                        else if (collisions[i].transform.gameObject.name == "CyanEnemy(Clone)")
                        {
                            collisions[i].transform.GetComponent<CyanEnemy>().Laser();
                        }
                        else if (collisions[i].transform.gameObject.name == "PurpleEnemy(Clone)")
                        {
                            collisions[i].transform.GetComponent<PurpleEnemy>().Laser();
                        }
                        else if (collisions[i].transform.gameObject.name == "OrangeEnemy(Clone)")
                        {
                            collisions[i].transform.GetComponent<OrangeEnemy>().Laser();
                        }
                        else if (collisions[i].transform.gameObject.name == "EyeBoss(Clone)")
                        {
                            collisions[i].transform.GetComponent<EyeBoss>().Laser();
                        }
                        else if (collisions[i].transform.gameObject.name == "YellowBoss(Clone)")
                        {
                            collisions[i].transform.GetComponent<YellowBoss>().Laser();
                        }
                        else if (collisions[i].transform.gameObject.name == "FinalBoss(Clone)")
                        {
                            collisions[i].transform.GetComponent<UFO_Boss>().Laser();
                        }
                        else if (collisions[i].transform.gameObject.name == "YellowBaby(Clone)")
                        {
                            collisions[i].transform.GetComponent<YellowBossBaby>().Laser();
                        }
                        else if (collisions[i].transform.gameObject.name == "YellowBossMini(Clone)")
                        {
                            collisions[i].transform.GetComponent<YellowBossMini>().Laser();
                        }
                        else if (collisions[i].transform.gameObject.name == "SuperGreen(Clone)")
                        {
                            collisions[i].transform.GetComponent<SuperGreen>().Laser();
                        }
                        else if (collisions[i].transform.gameObject.name == "SuperYellow(Clone)")
                        {
                            collisions[i].transform.GetComponent<SuperYellow>().Laser();
                        }
                        else if (collisions[i].transform.gameObject.name == "SuperRed(Clone)")
                        {
                            collisions[i].transform.GetComponent<SuperRed>().Laser();
                        }
                        else if (collisions[i].transform.gameObject.name == "SuperCyan(Clone)")
                        {
                            collisions[i].transform.GetComponent<SuperCyan>().Laser();
                        }
                        else if (collisions[i].transform.gameObject.name == "SuperOrange(Clone)")
                        {
                            collisions[i].transform.GetComponent<SuperOrange>().Laser();
                        }
                        else if (collisions[i].transform.gameObject.name == "SuperPurple(Clone)")
                        {
                            collisions[i].transform.GetComponent<SuperPurple>().Laser();
                        }
                        i++;
                    }
                    xOffset += .02f;
                }
				if (saveManager.GetComponent<SaveManager>().sound)
				{
					GetComponent<AudioSource>().clip = laserSound;
					GetComponent<AudioSource>().Play();
				}
			}
            else if (weapon == "sniper")
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, .1f, 0), Quaternion.identity);
                bullet.transform.localScale = new Vector3(1.5f, 1.5f, 1);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed * 4f);
				if (saveManager.GetComponent<SaveManager>().sound)
				{
					GetComponent<AudioSource>().clip = rocketSound;
					GetComponent<AudioSource>().Play();
				}
			}
            else if (weapon == "rocket")
            {
                GameObject rocket = Instantiate(rocketPrefab, transform.position + new Vector3(0, .1f, 0), Quaternion.identity);
				if (saveManager.GetComponent<SaveManager>().sound)
				{
					GetComponent<AudioSource>().clip = rocketSound;
					GetComponent<AudioSource>().Play();
				}
			}
        }
        else if (superWeapon == "super")
        {
            Instantiate(superShot, transform.position + new Vector3(0, .1f, 0), Quaternion.identity);
            superWeapon = "";
			if (saveManager.GetComponent<SaveManager>().sound)
			{
				GetComponent<AudioSource>().clip = rocketSound;
				GetComponent<AudioSource>().Play();
			}
		}
        else
        {
            Instantiate(ultraShot, transform.position + new Vector3(0, .1f, 0), Quaternion.identity);
            superWeapon = "";
			if (saveManager.GetComponent<SaveManager>().sound)
			{
				GetComponent<AudioSource>().clip = rocketSound;
				GetComponent<AudioSource>().Play();
			}
		}
    }
}
