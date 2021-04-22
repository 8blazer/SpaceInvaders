using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public int wave;
    public GameObject greenEnemy;
    public GameObject redEnemy;
    public GameObject yellowEnemy;
    public GameObject orangeEnemy;
    public GameObject purpleEnemy;
    public GameObject cyanEnemy;

    public GameObject eyeBoss;
    public GameObject splitBoss;
    public GameObject UFO_Boss;

    int randomEnemy;
    int enemyCount;
    public int enemyPerWave;
    float enemyTimer;
    public float enemyTime;
    public int initialEnemyCount;
    bool initialSpawned = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (initialSpawned)
        {
            enemyTimer += Time.deltaTime;
            if (enemyCount < enemyPerWave && enemyTimer > enemyTime)
            {
                if (wave == 1)
                {
                    if (Random.Range(1, 19) == 1)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7, 8), 5.5f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7, 8), 5f, 0), Quaternion.identity);
                    }
                }
                if (wave == 2)
                {
                    randomEnemy = Random.Range(1, 20);
                    if (randomEnemy == 17)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7, 8), 5.5f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 17)
                    {
                        Instantiate(redEnemy, new Vector3(Random.Range(-7, 8), 5.5f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7, 8), 5f, 0), Quaternion.identity);
                    }
                }
                enemyCount++;
                enemyTimer = 0;
            }
        }
        else
        {
            if (wave == 1)
            {
                int i = 0;
                while (i < initialEnemyCount)
                {
                    if (Random.Range(1, 19) == 1)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), Random.Range(4.0f, 5.5f), 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.0f), Random.Range(2.5f, 4.6f), 0), Quaternion.identity);
                    }

                    i++;
                }
            }
            else if (wave == 2)
            {
                int i = 0;
                while (i < initialEnemyCount)
                {
                    randomEnemy = Random.Range(1, 20);
                    if (randomEnemy == 17)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), Random.Range(4.0f, 5.5f), 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 17)
                    {
                        Instantiate(redEnemy, new Vector3(Random.Range(-7.0f, 8.0f), Random.Range(4.5f, 6.0f), 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.0f), Random.Range(2.5f, 4.6f), 0), Quaternion.identity);
                    }

                    i++;
                }
            }
            initialSpawned = true;
        }
    }
}
