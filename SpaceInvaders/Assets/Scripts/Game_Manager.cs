using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public GameObject greenBoss;
    public GameObject yellowBoss;
    public GameObject redBoss;
    public GameObject cyanBoss;
    public GameObject orangeBoss;
    public GameObject purpleBoss;

    int randomEnemy;
    int enemyCount;
    public int enemyPerWave;
    float enemyTimer;
    public float enemyTime;
    public int initialEnemyCount;
    public bool initialSpawned = false;
    public int enemiesLeft;
    public int wavePart = 1;
    public bool bossSpawned = false;
    public bool upgrading = false;
    GameObject upgradeCanvas;
    GameObject saveManager;
    GameObject UI_Canvas;
    GameObject player;
    public Text winMode;

    int yellowProbability = 15;
    int redProbability = 30;
    int orangeProbability = 60;
    int cyanProbability = 120;
    int purpleProbability = 240;
    int waveSize = 10;
    public int upgradeNumber = 5;

    private void Start()
    {
        player = GameObject.Find("Player");
        UI_Canvas = GameObject.Find("UI_Canvas");
        upgradeCanvas = GameObject.Find("UpgradeCanvas");
        saveManager = GameObject.Find("SaveManager");

        if (PlayerPrefs.GetString("difficulty") == "Easy")
        {
            initialEnemyCount = 12;
            enemyPerWave = 5;
            winMode.text = "Easy Mode";
        }
        else if (PlayerPrefs.GetString("difficulty") == "Normal")
        {
            initialEnemyCount = 15;
            enemyPerWave = 5;
            winMode.text = "Normal Mode";
        }
        else
        {
            initialEnemyCount = 22;
            enemyPerWave = 7;
            winMode.text = "Hard Mode";
        }
        if (PlayerPrefs.GetString("challenge") != "")
        {
            winMode.text = "Challenge";
            if (PlayerPrefs.GetString("managerType") == "green" ||
                PlayerPrefs.GetString("managerType") == "red" ||
                PlayerPrefs.GetString("managerType") == "yellow" ||
                PlayerPrefs.GetString("managerType") == "cyan" ||
                PlayerPrefs.GetString("managerType") == "orange" ||
                PlayerPrefs.GetString("managerType") == "purple")
            {
                wave = 12;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("managerType") == "normal")
        {
            if (initialSpawned && SceneManager.GetActiveScene().name == "GameScene")
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

                if (!bossSpawned && !upgrading && !player.GetComponent<PlayerMovement>().lost)
                {
                    if (enemiesLeft == 0 && wavePart == 3)
                    {
                        if (wave == 2 || wave == 6 || wave == 10)
                        {
                            if (PlayerPrefs.GetString("challenge") != "NoAbility")
                            {
                                upgrading = true;
                                UI_Canvas.GetComponent<Canvas>().enabled = false;
                                upgradeCanvas.GetComponent<Canvas>().enabled = true;
                                player.GetComponent<PlayerMovement>().enabled = false;
                                player.GetComponent<PlayerShoot>().enabled = false;
                                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
                                player.GetComponent<PlayerShoot>().ammo = player.GetComponent<PlayerShoot>().ammoMax;
                                player.GetComponent<BoxCollider2D>().enabled = false;
                            }

                            wave++;
                            wavePart = 1;
                            initialSpawned = false;
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
                        enemyCount = 0;
                        enemyPerWave++;
                        enemyTime -= .1f;
                        wavePart++;
                    }
                }
            }
            else if (!upgrading && SceneManager.GetActiveScene().name == "GameScene")
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
        }
        else if (PlayerPrefs.GetString("managerType") == "endless" && upgradeNumber == 0)
        {
            if (enemiesLeft == 0)
            {
                if (yellowProbability > 5)
                {
                    yellowProbability--;
                }
                if (redProbability > 6)
                {
                    redProbability -= 2;
                }
                if (orangeProbability > 8)
                {
                    orangeProbability -= 4;
                }
                if (cyanProbability > 10)
                {
                    cyanProbability -= 8;
                }
                if (purpleProbability > 11)
                {
                    purpleProbability -= 10;
                }
                waveSize++;

                int i = 0;
                while (i < waveSize)
                {
                    if (Random.Range(1, purpleProbability) == 1)
                    {
                        Instantiate(purpleEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 5.5f, 0), Quaternion.identity);
                    }
                    else if (Random.Range(1, cyanProbability) == 1)
                    {
                        Instantiate(cyanEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else if (Random.Range(1, orangeProbability) == 1)
                    {
                        Instantiate(orangeEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else if (Random.Range(1, redProbability) == 1)
                    {
                        Instantiate(redEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else if (Random.Range(1, yellowProbability) == 1)
                    {
                        Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                    }
                    i++;
                }
            }
        }
        else if (PlayerPrefs.GetString("managerType") == "endless")
        {
            UI_Canvas.GetComponent<Canvas>().enabled = false;
            upgradeCanvas.GetComponent<Canvas>().enabled = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerShoot>().enabled = false;
            player.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (PlayerPrefs.GetString("managerType") == "green" && !initialSpawned)
        {
            int i = 0;
            while (i < 30)
            {
                Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                i++;
            }
            Instantiate(greenBoss, new Vector3(0, 6, 0), Quaternion.identity);
            initialSpawned = true;
            enemyTime = 1;
        }
        else if (PlayerPrefs.GetString("managerType") == "green")
        {
            enemyTimer += Time.deltaTime;
            if (enemyTimer > enemyTime)
            {
                Instantiate(greenEnemy, new Vector3(Random.Range(-7.0f, 8.1f), Random.Range(5.0f, 7.1f), 0), Quaternion.identity);
                enemyTimer = 0;
            }
        }
        else if (PlayerPrefs.GetString("managerType") == "yellow" && !initialSpawned)
        {
            int i = 0;
            while (i < 3)
            {
                Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                i++;
            }
            Instantiate(yellowBoss, new Vector3(0, 6, 0), Quaternion.identity);
            initialSpawned = true;
            enemyTime = 3f;
        }
        else if (PlayerPrefs.GetString("managerType") == "yellow")
        {
            enemyTimer += Time.deltaTime;
            if (enemyTimer > enemyTime)
            {
                Instantiate(yellowEnemy, new Vector3(Random.Range(-7.0f, 8.0f), 6f, 0), Quaternion.identity);
                enemyTimer = 0;
            }
        }
    }

    public void BossDeath()
    {
        if (wave != 12)
        {
            if (PlayerPrefs.GetString("challenge") != "NoAbility")
            {
                upgrading = true;
                UI_Canvas.GetComponent<Canvas>().enabled = false;
                upgradeCanvas.GetComponent<Canvas>().enabled = true;
                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<PlayerShoot>().enabled = false;
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
            }

            wave++;
            wavePart = 1;
            initialSpawned = false;
            bossSpawned = false;
            enemyCount = 0;
            enemyPerWave++;
            enemyTime -= .1f;
        }
        else
        {
            wave = 13;
            player.GetComponent<PlayerMovement>().GameEnd();
        }
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
