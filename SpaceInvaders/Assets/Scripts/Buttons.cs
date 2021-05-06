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

    private void Update()
    {
        if (saveManager.GetComponent<SaveManager>().normalMode == "unbeaten")
        {
            hardButton.interactable = false;
            endlessButton.interactable = false;
            weaponButton.interactable = false;
            enemyButton.interactable = false;
            otherButton.interactable = false;
        }
        else
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
        mainMenu.enabled = true;
        playMenu.enabled = false;
    }
}
