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

    bool moveRight = true;
    public float moveSpeed;

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
    }

    // Update is called once per frame
    void Update()
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

        if (health < 1)
        {
            Destroy(gameObject);
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
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "Laser")
            {
                health--;
            }
            else if (collision.gameObject.tag == "Rocket")
            {
                health = health - 8;
                Destroy(collision.gameObject);
            }
        }
    }
}
