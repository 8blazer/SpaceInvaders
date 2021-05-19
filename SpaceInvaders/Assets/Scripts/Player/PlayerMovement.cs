using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float invincTimer;
    public float invincTime;
    float flashTimer;
    public float flashTime;
    float respawnTimer;
    public float respawnTime;
    public int lives = 3;
    public int continues = 3;
    public int kills = 0;
    public ParticleSystem deathParticles;
    public bool canMove = true;
    GameObject gameManager;
    GameObject saveManager;
    public Canvas upgradeCanvas;
    public Text livesText;
    public GameObject bulletPrefab;
    public GameObject doppelganger;
    string direction = "";
    float flightTimer;
    public Canvas pauseMenu;
    public Canvas winMenu;
    public Canvas loseMenu;
    public Text continuesText;
    public Button continueButton;
    public bool lost = false;
    public bool usedLives = false;

    public Sprite defaultShip;
    public Sprite pinkShip;
    public Sprite greenShip;
    public Sprite blueShip;
    public Sprite monochromeShip;
    public Sprite redShip;
    public Sprite doppelgangerShip;
    public Sprite flameShip;
    public Sprite rainbowShip;
    public Sprite glitchShip;
    public Sprite weaponShip;
    public Sprite enemyShip;
    public Sprite goldShip;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        saveManager = GameObject.Find("SaveManager");

        if (PlayerPrefs.GetString("challenge") == "Fast")
        {
            moveSpeed *= 5;
        }
        else if (PlayerPrefs.GetString("challenge") == "Slow")
        {
            moveSpeed /= 1.5f;
        }

        switch (PlayerPrefs.GetString("ship"))
        {
            case "default":
                GetComponent<SpriteRenderer>().sprite = defaultShip;
                break;
            case "pink":
                GetComponent<SpriteRenderer>().sprite = pinkShip;
                break;
            case "green":
                GetComponent<SpriteRenderer>().sprite = greenShip;
                break;
            case "blue":
                GetComponent<SpriteRenderer>().sprite = blueShip;
                break;
            case "monochrome":
                GetComponent<SpriteRenderer>().sprite = monochromeShip;
                break;
            case "red":
                GetComponent<SpriteRenderer>().sprite = redShip;
                break;
            case "doppelganger":
                GetComponent<SpriteRenderer>().sprite = doppelgangerShip;
                break;
            case "flame":
                GetComponent<SpriteRenderer>().sprite = flameShip;
                break;
            case "rainbow":
                GetComponent<SpriteRenderer>().sprite = rainbowShip;
                break;
            case "glitch":
                GetComponent<SpriteRenderer>().sprite = glitchShip;
                break;
            case "weapon":
                GetComponent<SpriteRenderer>().sprite = weaponShip;
                break;
            case "enemy":
                GetComponent<SpriteRenderer>().sprite = enemyShip;
                break;
            case "upsideDown":
                transform.eulerAngles = new Vector3(0, 0, 180);
                break;
            case "gold":
                GetComponent<SpriteRenderer>().sprite = goldShip;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = lives.ToString();

        if (canMove)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && transform.position.x > -8)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && transform.position.x < 8)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
        else if (direction == "")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (!canMove && gameManager.GetComponent<Game_Manager>().wave < 13)
        {
            doppelganger.GetComponent<Doppelganger>().canMove = false;
            respawnTimer += Time.deltaTime;
            if (respawnTimer > respawnTime)
            {
                canMove = true;
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                respawnTimer = 0;
            }
        }

        if (!GetComponent<BoxCollider2D>().enabled && canMove)
        {
            doppelganger.GetComponent<Doppelganger>().canMove = true;
            invincTimer += Time.deltaTime;
            flashTimer += Time.deltaTime;
            if (flashTimer > flashTime)
            {
                if (GetComponent<SpriteRenderer>().color.a == 1)
                {
                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                }
                flashTimer = 0;
            }
            if (invincTimer > invincTime)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                invincTimer = 0;
            }
        }

        if (direction != "" && transform.position.x == 0)
        {
            flightTimer += Time.deltaTime;
            GetComponent<SpriteRenderer>().enabled = true;
            if (flightTimer > 4)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 7);
            }
        }
        else if (direction == "left" && transform.position.x < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            transform.position = new Vector3(0, transform.position.y, 0);
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (direction == "right" && transform.position.x > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            transform.position = new Vector3(0, transform.position.y, 0);
            GetComponent<SpriteRenderer>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.enabled)
            {
                pauseMenu.enabled = false;
                Time.timeScale = 1;
            }
            else
            {
                pauseMenu.enabled = true;
                Time.timeScale = 0;
            }
        }

        if (transform.position.y > 12)
        {
            winMenu.enabled = true;
            if (PlayerPrefs.GetString("challenge") == "")
            {
                if (PlayerPrefs.GetString("difficulty") == "Easy")
                {
                    if (usedLives)
                    {
                        saveManager.GetComponent<SaveManager>().easyMode = "noLives";
                    }
                    else if (continues == 3 && saveManager.GetComponent<SaveManager>().easyMode != "noLives")
                    {
                        saveManager.GetComponent<SaveManager>().easyMode = "noContinues";
                    }
                    else if (saveManager.GetComponent<SaveManager>().easyMode == "unbeaten")
                    {
                        saveManager.GetComponent<SaveManager>().easyMode = "beaten";
                    }
                }
                else if (PlayerPrefs.GetString("difficulty") == "Normal")
                {
                    if (usedLives)
                    {
                        saveManager.GetComponent<SaveManager>().normalMode = "noLives";
                    }
                    else if (continues == 3 && saveManager.GetComponent<SaveManager>().normalMode != "noLives")
                    {
                        saveManager.GetComponent<SaveManager>().normalMode = "noContinues";
                    }
                    else if (saveManager.GetComponent<SaveManager>().normalMode == "unbeaten")
                    {
                        saveManager.GetComponent<SaveManager>().normalMode = "beaten";
                    }
                }
                else
                {
                    if (usedLives)
                    {
                        saveManager.GetComponent<SaveManager>().hardMode = "noLives";
                    }
                    else if (continues == 3 && saveManager.GetComponent<SaveManager>().hardMode != "noLives")
                    {
                        saveManager.GetComponent<SaveManager>().hardMode = "noContinues";
                    }
                    else if (saveManager.GetComponent<SaveManager>().hardMode == "unbeaten")
                    {
                        saveManager.GetComponent<SaveManager>().hardMode = "beaten";
                    }
                }
            }
            else if (PlayerPrefs.GetString("challenge") == "Weapon")
            {
                if (GetComponent<PlayerShoot>().weapon == "machinegun" && !saveManager.GetComponent<SaveManager>().machinegunChallenge)
                {
                    saveManager.GetComponent<SaveManager>().machinegunChallenge = true;
                    saveManager.GetComponent<SaveManager>().weaponChallenges++;
                }
                else if (GetComponent<PlayerShoot>().weapon == "minigun" && !saveManager.GetComponent<SaveManager>().minigunChallenge)
                {
                    saveManager.GetComponent<SaveManager>().minigunChallenge = true;
                    saveManager.GetComponent<SaveManager>().weaponChallenges++;
                }
                else if (GetComponent<PlayerShoot>().weapon == "shotgun" && !saveManager.GetComponent<SaveManager>().shotgunChallenge)
                {
                    saveManager.GetComponent<SaveManager>().shotgunChallenge = true;
                    saveManager.GetComponent<SaveManager>().weaponChallenges++;
                }
                else if (GetComponent<PlayerShoot>().weapon == "laser" && !saveManager.GetComponent<SaveManager>().laserChallenge)
                {
                    saveManager.GetComponent<SaveManager>().laserChallenge = true;
                    saveManager.GetComponent<SaveManager>().weaponChallenges++;
                }
                else if (GetComponent<PlayerShoot>().weapon == "sniper" && !saveManager.GetComponent<SaveManager>().sniperChallenge)
                {
                    saveManager.GetComponent<SaveManager>().sniperChallenge = true;
                    saveManager.GetComponent<SaveManager>().weaponChallenges++;
                }
                else if (GetComponent<PlayerShoot>().weapon == "rocket" && !saveManager.GetComponent<SaveManager>().rocketChallenge)
                {
                    saveManager.GetComponent<SaveManager>().rocketChallenge = true;
                    saveManager.GetComponent<SaveManager>().weaponChallenges++;
                }
            }
            else if (PlayerPrefs.GetString("challenge") == "Fast" && !saveManager.GetComponent<SaveManager>().fastChallenge)
            {
                saveManager.GetComponent<SaveManager>().fastChallenge = true;
                saveManager.GetComponent<SaveManager>().otherChallenges++;
            }
            else if (PlayerPrefs.GetString("challenge") == "Slow" && !saveManager.GetComponent<SaveManager>().slowChallenge)
            {
                saveManager.GetComponent<SaveManager>().slowChallenge = true;
                saveManager.GetComponent<SaveManager>().otherChallenges++;
            }
            else if (PlayerPrefs.GetString("challenge") == "UpsideDown" && !saveManager.GetComponent<SaveManager>().upsideDownChallenge)
            {
                saveManager.GetComponent<SaveManager>().upsideDownChallenge = true;
                saveManager.GetComponent<SaveManager>().otherChallenges++;
            }
            saveManager.GetComponent<SaveManager>().ToJson();
        }
    }

    public void Death()
    {
        if (GetComponent<BoxCollider2D>().enabled)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            usedLives = true;
            lives--;
            canMove = false;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            if (lives == 0)
            {
                Time.timeScale = 0;
                if (continues == 0)
                {
                    continueButton.interactable = false;
                }
                loseMenu.enabled = true;
                lost = true;
                if (SceneManager.GetActiveScene().name == "GameScene")
                {
                    continuesText.text = "Continues: " + continues;
                }
                else
                {
                    continuesText.text = "Kills: " + kills;
                    if (kills > saveManager.GetComponent<SaveManager>().endlessKills)
                    {
                        saveManager.GetComponent<SaveManager>().endlessKills = kills;
                        saveManager.GetComponent<SaveManager>().ToJson();
                    }
                }
            }
            else
            {
                deathParticles.Play();
            }
        }
    }

    public void GameEnd()
    {
        canMove = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = true;
        if (transform.position.x > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
            direction = "left";
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
            direction = "right";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int i = Random.Range(1, 101);
        if (collision.gameObject.tag == "E_Bullet")
        {
            if (upgradeCanvas.GetComponent<Upgrades>().exDodgeBought && i > 50)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().dodgeBought && i > 75)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().reflectBought && i > 40)
            {
                GameObject bullet = Instantiate(bulletPrefab, collision.transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = collision.GetComponent<Rigidbody2D>().velocity * -1;
            }
            else
            {
                Death();
            }
            if (collision.gameObject.name != "UFO_Laser")
            {
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            if (upgradeCanvas.GetComponent<Upgrades>().exDodgeBought && i > 50)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (upgradeCanvas.GetComponent<Upgrades>().dodgeBought && i > 75)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                Death();
            }
        }
    }
}
