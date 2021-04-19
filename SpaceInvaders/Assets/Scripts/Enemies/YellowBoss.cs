using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBoss : MonoBehaviour
{
    int health = 150;
    public int babyHealth1 = 50;
    public int babyHealth2 = 50;
    public int babyHealth3 = 50;
    public int babyHealth4 = 50;
    public int babyHealth5 = 50;
    public int babyHealth6 = 50;
    public int babyHealth7 = 50;
    public int babyHealth8 = 50;
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
    public Sprite mediumBossSprite;

    bool moveRight = true;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        splitTimer += Time.deltaTime;
        if (splitTimer > splitTime)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            if (size > 6)
            {
                GetComponent<Animator>().runtimeAnimatorController = morph1;
            }
            else
            {
                GetComponent<Animator>().runtimeAnimatorController = morph2;
            }

            transitionTimer += Time.deltaTime;
            if (transitionTimer > transitionTime)
            {
                int i = 0;
                babyX = transform.position.x - 1f;
                babyY = transform.position.y + 1;
                while (i < size - 1)
                {
                    GameObject baby = Instantiate(babyPrefab, new Vector3(babyX, babyY, 0), Quaternion.identity);
                    //baby.GetComponent<YellowBossBaby>().health =      somehow detect which health to give it
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
                GameObject mainBoss = Instantiate(mainBossPrefab, transform.position, Quaternion.identity);
                //mainBoss.GetComponent<MainBoss>().health = health;       need to make this script

                transitionTimer = 0;
                splitTimer = 0;
            }
        }
        else if (moveRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
            if (transform.position.x > 7f)
            {
                moveRight = false;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
            if (transform.position.x < -7f)
            {
                moveRight = true;
            }
        }
    }
}
