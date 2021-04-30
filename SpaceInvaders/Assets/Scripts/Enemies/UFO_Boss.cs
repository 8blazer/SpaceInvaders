using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_Boss : MonoBehaviour
{
    int health = 300;
    public float moveSpeed;
    public float shootSpeed;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    GameObject laser;
    bool moveRight;
    bool canMove = true;
    GameObject player;
    GameObject gameManager;
    public Sprite firstPhase;
    public Sprite gunPhase;
    float phaseTimer;
    public RuntimeAnimatorController gun;
    public RuntimeAnimatorController laserUp;
    public RuntimeAnimatorController laserDown;
    public float enemyTime;
    float enemyTimer;
    float shootTimer;
    float laserTimer;
    public float laserTime;
    float laserChargeTimer;
    public float laserChargeTime;
    bool laserMovement;
    bool spawned = false;
    GameObject upgradeCanvas;

    public GameObject greenPrefab;
    public GameObject yellowPrefab;
    public GameObject orangePrefab;
    public GameObject redPrefab;
    public GameObject purplePrefab;
    public GameObject cyanPrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        upgradeCanvas = GameObject.Find("UpgradeCanvas");
        gameManager = GameObject.Find("GameManager");
        laser = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned)
        {
            if (canMove)
            {
                if (moveRight)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
                    if (transform.position.x > 7.5f)
                    {
                        moveRight = false;
                    }
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
                    if (transform.position.x < -7.5f)
                    {
                        moveRight = true;
                    }
                }
                if (health < 100)
                {
                    GetComponent<Animator>().runtimeAnimatorController = null;
                    GetComponent<SpriteRenderer>().sprite = gunPhase;
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                phaseTimer += Time.deltaTime;
                if (phaseTimer > 2)
                {
                    canMove = true;
                    if (health < 200)
                    {
                        GetComponent<SpriteRenderer>().sprite = gunPhase;
                    }
                }
                if (health > 100)
                {
                    enemyTimer = 0;
                }
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
            if (transform.position.y < 3.5f)
            {
                spawned = true;
            }
        }

        enemyTimer += Time.deltaTime;
        if (enemyTimer > enemyTime)
        {
            int i = Random.Range(1, 7);
            if (i == 1)
            {
                Instantiate(greenPrefab, transform.position + new Vector3(0, -.4f, 0), Quaternion.identity);
            }
            else if (i == 2)
            {
                Instantiate(yellowPrefab, transform.position + new Vector3(0, -.4f, 0), Quaternion.identity);
            }
            else if (i == 3)
            {
                Instantiate(redPrefab, transform.position + new Vector3(0, -.4f, 0), Quaternion.identity);
            }
            else if (i == 4)
            {
                Instantiate(orangePrefab, transform.position + new Vector3(0, -.4f, 0), Quaternion.identity);
            }
            else if (i == 5)
            {
                Instantiate(purplePrefab, transform.position + new Vector3(0, -.4f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(cyanPrefab, transform.position + new Vector3(0, -.4f, 0), Quaternion.identity);
            }

            enemyTimer = 0;
        }

        if (health < 200 && GetComponent<SpriteRenderer>().sprite == firstPhase)
        {
            canMove = false;
            GetComponent<Animator>().runtimeAnimatorController = gun;
            enemyTime++;
            moveSpeed += 2;
        }
        else if (health < 100 && enemyTime == 6)
        {
            enemyTime++;
            moveSpeed += 2;
        }

        if (health < 100)
        {
            laserTimer += Time.deltaTime;
            if (laserTimer > laserTime)
            {
                GetComponent<Animator>().runtimeAnimatorController = laserUp;
                canMove = false;
                if (moveRight)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * 1.5f, 0);
                    if (transform.position.x > 6.5f)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                        laserChargeTimer += Time.deltaTime;
                        if (laserChargeTimer > laserChargeTime)
                        {
                            laser.GetComponent<BoxCollider2D>().enabled = true;
                            laser.GetComponent<SpriteRenderer>().enabled = true;
                            laserMovement = true;
                        }
                    }
                    if (laserMovement)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * -1.5f, 0);
                        if (transform.position.x < -6.5f)
                        {
                            laser.GetComponent<BoxCollider2D>().enabled = false;
                            laser.GetComponent<SpriteRenderer>().enabled = false;
                            GetComponent<Animator>().runtimeAnimatorController = laserDown;
                            laserTimer = 0;
                            laserChargeTimer = 0;
                            laserMovement = false;
                            canMove = true;
                            laserTime = Random.Range(2, 6);
                        }
                    }
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * -1.5f, 0);
                    if (transform.position.x < -6.5f)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                        laserChargeTimer += Time.deltaTime;
                        if (laserChargeTimer > laserChargeTime)
                        {
                            laser.GetComponent<BoxCollider2D>().enabled = true;
                            laser.GetComponent<SpriteRenderer>().enabled = true;
                            laserMovement = true;
                        }
                    }
                    if (laserMovement)
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * 1.5f, 0);
                        if (transform.position.x > 6.5f)
                        {
                            laser.GetComponent<BoxCollider2D>().enabled = false;
                            laser.GetComponent<SpriteRenderer>().enabled = false;
                            GetComponent<Animator>().runtimeAnimatorController = laserDown;
                            laserTimer = 0;
                            laserChargeTimer = 0;
                            laserMovement = false;
                            canMove = true;
                            laserTime = Random.Range(2, 6);
                        }
                    }
                }
            }
        }
        else if (health < 200)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer > shootSpeed)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(.7f, -.85f, 0), Quaternion.identity);
                bullet.transform.up = (player.transform.position - transform.position);
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;
                bullet = Instantiate(bulletPrefab, transform.position + new Vector3(-.7f, -.85f, 0), Quaternion.identity);
                bullet.transform.up = (player.transform.position - transform.position);
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;
                shootTimer = 0;
            }
        }
        if (health < 1)
        {
            gameManager.GetComponent<Game_Manager>().BossDeath();
            Destroy(gameManager);
            Destroy(gameObject);
        }
    }

    public void Laser()
    {
        health--;
        if (upgradeCanvas.GetComponent<Upgrades>().exDmgBought)
        {
            health -= 2;
        }
        else if (upgradeCanvas.GetComponent<Upgrades>().dmgBought)
        {
            health--;
        }
        if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 92)
        {
            health -= 3;
        }
        else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 96)
        {
            health -= 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            health--;
            if (upgradeCanvas.GetComponent<Upgrades>().exDmgBought)
            {
                health -= 2;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().dmgBought)
            {
                health--;
            }
            if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 92)
            {
                health -= 3;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 96)
            {
                health -= 2;
            }
            if (player.GetComponent<PlayerShoot>().weapon == "sniper")
            {
                health -= 13;
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Rocket")
        {
            health = health - 8;
            if (upgradeCanvas.GetComponent<Upgrades>().exDmgBought)
            {
                health -= 2;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().dmgBought)
            {
                health--;
            }
            if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 92)
            {
                health -= 3;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 96)
            {
                health -= 2;
            }
        }
    }
}
