using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YellowBoss : MonoBehaviour
{
    float health = 175;
    public List<float> babyHealth = new List<float>();
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

    Slider healthbar;
    Image background;
    Image fill;
    Image handle;
    public Sprite handleSprite;

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

        healthbar = GameObject.Find("BossHealth").GetComponent<Slider>();
        background = GameObject.Find("BossHealth").transform.GetChild(0).GetComponent<Image>();
        fill = GameObject.Find("BossHealth").transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
        handle = GameObject.Find("BossHealth").transform.GetChild(2).transform.GetChild(0).GetComponent<Image>();
        background.enabled = true;
        fill.enabled = true;
        handle.enabled = true;
        handle.sprite = handleSprite;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = health / 175;
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

        if (player.GetComponent<PlayerMovement>().lost)
        {
            background.enabled = false;
            fill.enabled = false;
            handle.enabled = false;
            Destroy(gameObject);
        }

        if (health < 1)
        {
            gameManager.GetComponent<Game_Manager>().BossDeath();
            background.enabled = false;
            fill.enabled = false;
            handle.enabled = false;
            Destroy(gameObject);
        }
    }

    public void Laser()
    {
        health--;
        if (upgradeCanvas.GetComponent<Upgrades>().exDmgBought)
        {
            health--;
        }
        else if (upgradeCanvas.GetComponent<Upgrades>().dmgBought)
        {
            health -= .5f;
        }
        if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 80)
        {
            health -= 5;
        }
        else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 90)
        {
            health -= 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
                    health--;
                }
                else if (upgradeCanvas.GetComponent<Upgrades>().dmgBought)
                {
                    health -= .5f;
                }
                if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 80)
                {
                    health -= 5;
                }
                else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 90)
                {
                    health -= 3;
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
                    health--;
                }
                else if (upgradeCanvas.GetComponent<Upgrades>().dmgBought)
                {
                    health -= .5f;
                }
                if (upgradeCanvas.GetComponent<Upgrades>().exCritBought && Random.Range(1, 101) > 80)
                {
                    health -= 5;
                }
                else if (upgradeCanvas.GetComponent<Upgrades>().critBought && Random.Range(1, 101) > 90)
                {
                    health -= 3;
                }
            }
            else if (collision.gameObject.tag == "SuperShot")
            {
                health -= collision.transform.localScale.x * 2;
            }
        }
    }
}
