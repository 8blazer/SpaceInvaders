using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBoss : MonoBehaviour
{
    int health = 175;
    public List<int> babyHealth = new List<int>();
    int size = 9;
    float babyX;
    float babyY;
    float splitTimer;
    public float splitTime;
    float transitionTimer;
    public float transitionTime;
    public RuntimeAnimatorController morph1;
    public RuntimeAnimatorController morph2;
    public GameObject babyPrefab;
    public GameObject mainBossPrefab;
    public Sprite bigBossSprite;
    public Sprite mainBossSprite;
    bool spawned = false;

    bool moveRight = true;
    public float moveSpeed;
    GameObject gameManager;
    public GameObject lifeDrop;
    GameObject player;
    GameObject upgradeCanvas;

    // Start is called before the first frame update
    void Start()
    {
        babyHealth.Add(40);
        babyHealth.Add(40);
        babyHealth.Add(40);
        babyHealth.Add(40);
        babyHealth.Add(40);
        babyHealth.Add(40);
        babyHealth.Add(40);
        babyHealth.Add(40);

        gameManager = GameObject.Find("GameManager");
        upgradeCanvas = GameObject.Find("UpgradeCanvas");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned)
        {
            if (GetComponent<SpriteRenderer>().sprite == bigBossSprite)
            {
                splitTimer += Time.deltaTime;
            }
            if (splitTimer > splitTime)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GetComponent<Animator>().runtimeAnimatorController = morph1;

                transitionTimer += Time.deltaTime;
                if (transitionTimer > transitionTime)
                {
                    int i = 0;
                    babyX = transform.position.x - 1f;
                    babyY = transform.position.y + 1;
                    while (i < size - 1)
                    {
                        GameObject baby = Instantiate(babyPrefab, new Vector3(babyX, babyY, 0), Quaternion.identity);
                        baby.GetComponent<YellowBossBaby>().health = babyHealth[i];
                        if (babyX == transform.position.x + 1f)
                        {
                            babyX = transform.position.x - 1f;
                            babyY -= 1f;
                        }
                        else if (i == 3)
                        {
                            babyX += 2f;
                        }
                        else
                        {
                            babyX += 1f;
                        }
                        i++;
                    }

                    transitionTimer = 0;
                    splitTimer = 0;
                    GetComponent<Animator>().runtimeAnimatorController = null;
                    GetComponent<SpriteRenderer>().sprite = mainBossSprite;
                    transform.localScale = new Vector3(8, 8, 0);
                    size = 1;
                    babyHealth.Clear();
                }
            }
            else if (GetComponent<SpriteRenderer>().sprite == bigBossSprite && moveRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
                if (transform.position.x > 7f)
                {
                    moveRight = false;
                }
            }
            else if (GetComponent<SpriteRenderer>().sprite == bigBossSprite)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
                if (transform.position.x < -7f)
                {
                    moveRight = true;
                }
            }
            else if (moveRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed + 3, 0);
                if (transform.position.x > 7.75f)
                {
                    moveRight = false;
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed - 3, 0);
                if (transform.position.x < -7.75f)
                {
                    moveRight = true;
                }
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
            if (transform.position.y < 3.3f)
            {
                spawned = true;
            }
        }


        if (health < 1)
        {
            gameManager.GetComponent<Game_Manager>().BossDeath();
            //Instantiate(lifeDrop, transform.position, Quaternion.identity);
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "YellowBaby(Clone)" && collision.gameObject.GetComponent<YellowBossBaby>().rejoin)
        {
            size++;
            babyHealth.Add(collision.gameObject.GetComponent<YellowBossBaby>().health);
            GetComponent<SpriteRenderer>().sprite = bigBossSprite;
            if (transform.localScale.x > 6)
            {
                transform.localScale = new Vector3(2, 2, 0);
            }
            transform.localScale += new Vector3(.25f, .25f, 0);
            Destroy(collision.gameObject);
        }

        if (GetComponent<SpriteRenderer>().sprite == mainBossSprite)
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
                    if (Random.Range(1, 3) == 1)
                    {
                        Destroy(collision.gameObject);
                    }
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }
            else if (collision.gameObject.tag == "Rocket")
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
}
