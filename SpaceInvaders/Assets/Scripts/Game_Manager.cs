using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public int enemiesLeft;
    public int wavePart = 1;
    bool bossSpawned = false;
    public bool upgrading = false;
    public Canvas upgradeCanvas;
    public Canvas UI_Canvas;
    public Text text;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = enemiesLeft.ToString();
        
        if (initialSpawned)
        {
            enemyTimer += Time.deltaTime;
            if (enemyCount < enemyPerWave && enemyTimer > enemyTime && !bossSpawned && !upgrading)
            {
                if (wave == 1)
                {
                    if (Random.Range(1, 19) == 1)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 2)
                {
                    randomEnemy = Random.Range(1, 20);
                    if (randomEnemy == 17)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 17)
                    {
                        Instantiate(redEnemy, new Vector3(Random.Range(-7, 8), 6.5f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 3)
                {
                    randomEnemy = Random.Range(1, 20);
                    if (randomEnemy > 17)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 14)
                    {
                        Instantiate(redEnemy, new Vector3(Random.Range(-7.0f, 8.0f), Random.Range(5.5f, 6.5f), 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 5)
                {
                    randomEnemy = Random.Range(1, 20);
                    if (randomEnemy > 18)
                    {
                        Instantiate(orangeEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 5.5f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy == 18)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 6)
                {
                    randomEnemy = Random.Range(1, 20);
                    if (randomEnemy > 18)
                    {
                        Instantiate(cyanEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 5.5f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy == 18)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 7)
                {
                    randomEnemy = Random.Range(1, 101);
                    if (randomEnemy > 94)
                    {
                        Instantiate(cyanEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 5.5f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 89)
                    {
                        Instantiate(orangeEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 5.5f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 86)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 9)
                {
                    randomEnemy = Random.Range(1, 20);
                    if (randomEnemy > 18)
                    {
                        Instantiate(purpleEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 5.5f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy == 18)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 10)
                {
                    randomEnemy = Random.Range(1, 101);
                    if (randomEnemy > 94)
                    {
                        Instantiate(purpleEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 5.5f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 89)
                    {
                        Instantiate(cyanEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 84)
                    {
                        Instantiate(orangeEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 11)
                {
                    randomEnemy = Random.Range(1, 101);
                    if (randomEnemy > 96)
                    {
                        Instantiate(purpleEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 5.5f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 92)
                    {
                        Instantiate(cyanEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 88)
                    {
                        Instantiate(orangeEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 84)
                    {
                        Instantiate(redEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 80)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                enemyCount++;
                enemyTimer = 0;
            }

            if (!bossSpawned && !upgrading)
            {
                if (enemiesLeft == 0 && wavePart == 3)
                {
                    if (wave == 2 || wave == 6 || wave == 10)
                    {
                        upgrading = true;
                        UI_Canvas.GetComponent<Canvas>().enabled = false;
                        upgradeCanvas.GetComponent<Canvas>().enabled = true;
                        player.GetComponent<PlayerMovement>().enabled = false;
                        player.GetComponent<PlayerShoot>().enabled = false;
                        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
                        wave++;

                        wavePart = 1;
                        initialSpawned = false;
                        initialEnemyCount++;
                        enemyCount = 0;
                        enemyPerWave++;
                        enemyTime -= .1f;
                    }
                    else
                    {
                        wavePart = 1;
                        initialSpawned = false;
                        enemyCount = 0;
                        enemyPerWave++;
                        wave++;
                    }
                }
                else if (enemiesLeft < 6 && wavePart < 3)
                {
                    initialSpawned = false;
                    initialEnemyCount++;
                    enemyCount = 0;
                    enemyPerWave++;
                    enemyTime -= .1f;
                    wavePart++;
                }
            }
        }
        else if (!upgrading)
        {
            int i = 0;
            while (i < initialEnemyCount && !bossSpawned)
            {
                if (wave == 1)
                {
                    if (Random.Range(1, 19) == 1)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 2)
                {
                    randomEnemy = Random.Range(1, 20);
                    if (randomEnemy == 17)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 17)
                    {
                        Instantiate(redEnemy, new Vector3(Random.Range(-7.0f, 8.0f), Random.Range(5.5f, 6.5f), 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 3)
                {
                    randomEnemy = Random.Range(1, 20);
                    if (randomEnemy > 17)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 14)
                    {
                        Instantiate(redEnemy, new Vector3(Random.Range(-7.0f, 8.0f), Random.Range(5.5f, 6.5f), 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 4)
                {
                    Instantiate(eyeBoss, new Vector3(0, 6, 0), Quaternion.identity);
                    bossSpawned = true;
                }
                else if (wave == 5)
                {
                    randomEnemy = Random.Range(1, 20);
                    if (randomEnemy > 18)
                    {
                        Instantiate(orangeEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 5.5f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy == 18)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 6)
                {
                    randomEnemy = Random.Range(1, 20);
                    if (randomEnemy > 18)
                    {
                        Instantiate(cyanEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 5.5f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy == 18)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 7)
                {
                    randomEnemy = Random.Range(1, 101);
                    if (randomEnemy > 94)
                    {
                        Instantiate(cyanEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 5.5f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 89)
                    {
                        Instantiate(orangeEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 5.5f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 86)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 8)
                {
                    Instantiate(splitBoss, new Vector3(0, 6, 0), Quaternion.identity);
                    bossSpawned = true;
                }
                else if (wave == 9)
                {
                    randomEnemy = Random.Range(1, 20);
                    if (randomEnemy > 18)
                    {
                        Instantiate(purpleEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 5.5f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy == 18)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 10)
                {
                    randomEnemy = Random.Range(1, 101);
                    if (randomEnemy > 97)
                    {
                        Instantiate(purpleEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 5.5f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 94)
                    {
                        Instantiate(cyanEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 91)
                    {
                        Instantiate(orangeEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else if (wave == 11)
                {
                    randomEnemy = Random.Range(1, 101);
                    if (randomEnemy > 97)
                    {
                        Instantiate(purpleEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 5.5f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 94)
                    {
                        Instantiate(cyanEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 91)
                    {
                        Instantiate(orangeEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 87)
                    {
                        Instantiate(redEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else if (randomEnemy > 83)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                }
                else
                {
                    Instantiate(UFO_Boss, new Vector3(0, 6, 0), Quaternion.identity);
                    bossSpawned = true;
                }
                i++;
            }
            initialSpawned = true;
        }
        else
        {
            initialSpawned = true;
        }
    }

    public void BossDeath()
    {
        bossSpawned = false;
        upgrading = true;
        UI_Canvas.GetComponent<Canvas>().enabled = false;
        upgradeCanvas.GetComponent<Canvas>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerShoot>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
        wave++;

        wavePart = 1;
        initialSpawned = false;
        initialEnemyCount++;
        enemyCount = 0;
        enemyPerWave++;
        enemyTime -= .1f;
    }

    public void AddEnemy()
    {
        enemiesLeft++;
    }

    public void KillEnemy()
    {
        enemiesLeft--;
    }
}
