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
    public Button hardButton;
    public Button endlessButton;
    public Button weaponButton;
    public Button enemyButton;
    public Button otherButton;
    public GameObject weaponChallengeButtons;
    public GameObject enemyChallengeButtons;
    public GameObject otherChallengeButtons;

    public Canvas pauseMenu;
    public Canvas loseMenu;

    private void Start()
    {
        saveManager = GameObject.Find("SaveManager");
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
        SceneManager.LoadScene("GameScene");
    }

    public void NormalMode()
    {
        PlayerPrefs.SetString("difficulty", "Normal");
        SceneManager.LoadScene("GameScene");
    }

    public void HardMode()
    {
        PlayerPrefs.SetString("difficulty", "Hard");
        SceneManager.LoadScene("GameScene");
    }

    public void Endless()
    {

    }

    public void WeaponChallenges()
    {
        playMenu.enabled = false;
        challengeMenu.enabled = true;
        weaponChallengeButtons.SetActive(true);
        enemyChallengeButtons.SetActive(false);
        otherChallengeButtons.SetActive(false);
    }

    public void EnemyChallenges()
    {
        playMenu.enabled = false;
        challengeMenu.enabled = true;
        weaponChallengeButtons.SetActive(false);
        enemyChallengeButtons.SetActive(true);
        otherChallengeButtons.SetActive(false);
    }

    public void OtherChallenges()
    {
        playMenu.enabled = false;
        challengeMenu.enabled = true;
        weaponChallengeButtons.SetActive(false);
        enemyChallengeButtons.SetActive(false);
        otherChallengeButtons.SetActive(true);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            mainMenu.enabled = true;
            playMenu.enabled = false;
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
        SceneManager.LoadScene("GameScene");
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
}
