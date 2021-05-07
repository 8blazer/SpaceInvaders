using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject saveManager;
    public Canvas mainMenu;
    public Canvas playMenu;
    public Button hardButton;
    public Button endlessButton;
    public Button weaponButton;
    public Button enemyButton;
    public Button otherButton;

    public Canvas pauseMenu;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
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
        gameManager.GetComponent<Game_Manager>().initialEnemyCount = 15;
        gameManager.GetComponent<Game_Manager>().enemyPerWave = 5;
        SceneManager.LoadScene("GameScene");
    }

    public void NormalMode()
    {
        gameManager.GetComponent<Game_Manager>().initialEnemyCount = 20;
        gameManager.GetComponent<Game_Manager>().enemyPerWave = 7;
        SceneManager.LoadScene("GameScene");
    }

    public void HardMode()
    {
        gameManager.GetComponent<Game_Manager>().initialEnemyCount = 25;
        gameManager.GetComponent<Game_Manager>().enemyPerWave = 10;
        SceneManager.LoadScene("GameScene");
    }

    public void Endless()
    {

    }

    public void WeaponChallenges()
    {

    }

    public void EnemyChallenges()
    {

    }

    public void OtherChallenges()
    {

    }

    public void Back()
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
        gameManager.GetComponent<Game_Manager>().wave = 1;
        gameManager.GetComponent<Game_Manager>().enemyTime = 1.5f;
        gameManager.GetComponent<Game_Manager>().initialSpawned = false;
        gameManager.GetComponent<Game_Manager>().wavePart = 1;
        gameManager.GetComponent<Game_Manager>().enemyPerWave = 10;
        SceneManager.LoadScene("GameScene");
    }
}
