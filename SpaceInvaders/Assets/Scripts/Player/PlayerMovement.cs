using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public ParticleSystem deathParticles;
    public bool canMove = true;
    GameObject gameManager;
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
    public bool lost = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
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
            if (flightTimer > 4)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 7);
            }
        }
        else if (direction == "left" && transform.position.x < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            transform.position = new Vector3(0, transform.position.y, 0);
        }
        else if (direction == "right" && transform.position.x > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            transform.position = new Vector3(0, transform.position.y, 0);
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
        }
    }

    public void Death()
    {
        if (GetComponent<BoxCollider2D>().enabled)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            deathParticles.Play();
            lives--;
            canMove = false;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            if (lives == 0)
            {
                Time.timeScale = 0;
                loseMenu.enabled = true;
                continuesText.text = "Continues: " + continues;
                lost = true;
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
