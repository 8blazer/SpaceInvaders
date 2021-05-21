using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject saveManager;
    public GameObject player;
    public Canvas mainMenu;
    public Canvas playMenu;
    public Canvas challengeMenu;
    public Canvas unlocksMenu;
    public Button hardButton;
    public Button endlessButton;
    public Text endlessKills;
    public Button weaponButton;
    public Button enemyButton;
    public Button otherButton;
    public GameObject weaponChallengeButtons;
    public GameObject enemyChallengeButtons;
    public GameObject otherChallengeButtons;
    public Image Ship_1;
    public Image Ship_2;
    string mainShip = "Ship_1";
    public string shipPreview = "default";
    int shipNumber = 0;
    List<string> ships = new List<string>();

    public Canvas pauseMenu;
    public Canvas loseMenu;

    private void Start()
    {
        saveManager = GameObject.Find("SaveManager");

        ships.Add("default");
        ships.Add("pink");
        ships.Add("green");
        ships.Add("blue");
        ships.Add("monochrome");
        ships.Add("red");
        ships.Add("doppelganger");
        ships.Add("flame");
        ships.Add("rainbow");
        ships.Add("glitch");
        ships.Add("weapon");
        ships.Add("enemy");
        ships.Add("upsideDown");
        ships.Add("gold");
    }

    private void Update()
    {
        if (saveManager.GetComponent<SaveManager>().normalMode == "unbeaten" && hardButton != null)
        {
            hardButton.interactable = false;
            endlessButton.interactable = false;
            weaponButton.interactable = false;
            enemyButton.interactable = false;
            otherButton.interactable = false;
        }
        else if (hardButton != null)
        {
            hardButton.interactable = true;
            endlessButton.interactable = true;
            weaponButton.interactable = true;
            enemyButton.interactable = true;
            otherButton.interactable = true;
        }
    }

    public void PlayMenu()
    {
        mainMenu.enabled = false;
        challengeMenu.enabled = false;
        playMenu.enabled = true;
        endlessKills.text = "Best: " + saveManager.GetComponent<SaveManager>().endlessKills;
    }

    public void UnlocksMenu()
    {
        mainMenu.enabled = false;
        unlocksMenu.enabled = true;
    }

    public void Settings()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EasyMode()
    {
        PlayerPrefs.SetString("difficulty", "Easy");
        PlayerPrefs.SetString("challenge", "");
        PlayerPrefs.SetString("weapon", "machinegun");
        PlayerPrefs.SetString("managerType", "normal");
        SceneManager.LoadScene("GameScene");
    }

    public void NormalMode()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        PlayerPrefs.SetString("challenge", "");
        PlayerPrefs.SetString("weapon", "machinegun");
        PlayerPrefs.SetString("managerType", "normal");
        SceneManager.LoadScene("GameScene");
    }

    public void HardMode()
    {
        PlayerPrefs.SetString("difficulty", "Hard");
        PlayerPrefs.SetString("challenge", "");
        PlayerPrefs.SetString("weapon", "machinegun");
        PlayerPrefs.SetString("managerType", "normal");
        SceneManager.LoadScene("GameScene");
    }

    public void Endless()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        PlayerPrefs.SetString("challenge", "");
        PlayerPrefs.SetString("weapon", "machinegun");
        PlayerPrefs.SetString("managerType", "endless");
        SceneManager.LoadScene("EndlessScene");
    }

    public void WeaponChallenges()
    {
        playMenu.enabled = false;
        challengeMenu.enabled = true;
        weaponChallengeButtons.SetActive(true);
        enemyChallengeButtons.SetActive(false);
        otherChallengeButtons.SetActive(false);
    }

    public void MachinegunChallenge()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        PlayerPrefs.SetString("challenge", "Weapon");
        PlayerPrefs.SetString("weapon", "machinegun");
        PlayerPrefs.SetString("managerType", "normal");
        SceneManager.LoadScene("GameScene");
    }

    public void MinigunChallenge()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        PlayerPrefs.SetString("challenge", "Weapon");
        PlayerPrefs.SetString("weapon", "minigun");
        PlayerPrefs.SetString("managerType", "normal");
        SceneManager.LoadScene("GameScene");
    }

    public void ShotgunChallenge()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        PlayerPrefs.SetString("challenge", "Weapon");
        PlayerPrefs.SetString("weapon", "shotgun");
        PlayerPrefs.SetString("managerType", "normal");
        SceneManager.LoadScene("GameScene");
    }

    public void LaserChallenge()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        PlayerPrefs.SetString("challenge", "Weapon");
        PlayerPrefs.SetString("weapon", "laser");
        PlayerPrefs.SetString("managerType", "normal");
        SceneManager.LoadScene("GameScene");
    }

    public void SniperChallenge()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        PlayerPrefs.SetString("challenge", "Weapon");
        PlayerPrefs.SetString("weapon", "sniper");
        PlayerPrefs.SetString("managerType", "normal");
        SceneManager.LoadScene("GameScene");
    }

    public void RocketChallenge()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        PlayerPrefs.SetString("challenge", "Weapon");
        PlayerPrefs.SetString("weapon", "rocket");
        PlayerPrefs.SetString("managerType", "normal");
        SceneManager.LoadScene("GameScene");
    }
    public void EnemyChallenges()
    {
        playMenu.enabled = false;
        challengeMenu.enabled = true;
        weaponChallengeButtons.SetActive(false);
        enemyChallengeButtons.SetActive(true);
        otherChallengeButtons.SetActive(false);
    }

    public void GreenChallenge()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        PlayerPrefs.SetString("challenge", "Green");
        PlayerPrefs.SetString("weapon", "machinegun");
        PlayerPrefs.SetString("managerType", "green");
        SceneManager.LoadScene("GameScene");
    }

    public void OtherChallenges()
    {
        playMenu.enabled = false;
        challengeMenu.enabled = true;
        weaponChallengeButtons.SetActive(false);
        enemyChallengeButtons.SetActive(false);
        otherChallengeButtons.SetActive(true);
    }

    public void FastChallenge()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        PlayerPrefs.SetString("challenge", "Fast");
        PlayerPrefs.SetString("weapon", "machinegun");
        PlayerPrefs.SetString("managerType", "normal");
        SceneManager.LoadScene("GameScene");
    }

    public void SlowChallenge()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        PlayerPrefs.SetString("challenge", "Slow");
        PlayerPrefs.SetString("weapon", "machinegun");
        PlayerPrefs.SetString("managerType", "normal");
        SceneManager.LoadScene("GameScene");
    }

    public void AmmoChallenge()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        PlayerPrefs.SetString("challenge", "Ammo");
        PlayerPrefs.SetString("weapon", "machinegun");
        PlayerPrefs.SetString("managerType", "normal");
        SceneManager.LoadScene("GameScene");
    }

    public void UpsideDownChallenge()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        PlayerPrefs.SetString("challenge", "UpsideDown");
        PlayerPrefs.SetString("weapon", "machinegun");
        PlayerPrefs.SetString("managerType", "normal");
        SceneManager.LoadScene("GameScene");
    }

    public void NoAbilityChallenge()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        PlayerPrefs.SetString("challenge", "NoAbility");
        PlayerPrefs.SetString("weapon", "machinegun");
        PlayerPrefs.SetString("managerType", "normal");
        SceneManager.LoadScene("GameScene");
    }

    public void CrazyEnemyChallenge()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        PlayerPrefs.SetString("challenge", "CrazyEnemy");
        PlayerPrefs.SetString("weapon", "machinegun");
        PlayerPrefs.SetString("managerType", "normal");
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            mainMenu.enabled = true;
            playMenu.enabled = false;
            unlocksMenu.enabled = false;
        }
        else
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

    public void Continue()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1;
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UseContinue()
    {
        Time.timeScale = 1;
        gameManager.GetComponent<Game_Manager>().enemiesLeft = 0;
        gameManager.GetComponent<Game_Manager>().wavePart = 1;
        gameManager.GetComponent<Game_Manager>().bossSpawned = false;
        gameManager.GetComponent<Game_Manager>().initialSpawned = false;
        player.GetComponent<PlayerMovement>().continues--;
        player.GetComponent<PlayerMovement>().lives = 3;
        player.GetComponent<PlayerMovement>().lost = false;
        loseMenu.enabled = false;
    }

    public void LeftArrow()
    {
        if (Ship_1.GetComponent<ShipPreview>().direction == "" && Ship_2.GetComponent<ShipPreview>().direction == "")
        {
            if (shipNumber == 13)
            {
                shipNumber = 0;
            }
            else
            {
                shipNumber++;
            }
            shipPreview = ships[shipNumber];
            if (mainShip == "Ship_1")
            {
                Ship_1.GetComponent<ShipPreview>().FadeLeft();
                Ship_2.GetComponent<ShipPreview>().AppearRight();
                mainShip = "Ship_2";
            }
            else
            {
                Ship_2.GetComponent<ShipPreview>().FadeLeft();
                Ship_1.GetComponent<ShipPreview>().AppearRight();
                mainShip = "Ship_1";
            }
        }
    }

    public void RightArrow()
    {
        if (Ship_1.GetComponent<ShipPreview>().direction == "" && Ship_2.GetComponent<ShipPreview>().direction == "")
        {
            if (shipNumber == 0)
            {
                shipNumber = 13;
            }
            else
            {
                shipNumber--;
            }
            shipPreview = ships[shipNumber];
            if (mainShip == "Ship_1")
            {
                Ship_1.GetComponent<ShipPreview>().FadeRight();
                Ship_2.GetComponent<ShipPreview>().AppearLeft();
                mainShip = "Ship_2";
            }
            else
            {
                Ship_2.GetComponent<ShipPreview>().FadeRight();
                Ship_1.GetComponent<ShipPreview>().AppearLeft();
                mainShip = "Ship_1";
            }
        }
    }
}
