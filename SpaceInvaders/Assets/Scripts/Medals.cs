using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medals : MonoBehaviour
{
    public Image easySkull;
    public Image normalSkull;
    public Image hardSkull;
    public Image weaponCheckmark;
    public Image enemyCheckmark;
    public Image otherCheckmark;

    public Image machinegunCheckmark;
    public Image minigunCheckmark;
    public Image shotgunCheckmark;
    public Image laserCheckmark;
    public Image sniperCheckmark;
    public Image rocketCheckmark;

    public Image gEnemyCheckmark;
    public Image rEnemyCheckmark;
    public Image yEnemyCheckmark;
    public Image pEnemyCheckmark;
    public Image cEnemyCheckmark;
    public Image oEnemyCheckmark;

    public Image slowCheckmark;
    public Image fastCheckmark;
    public Image noAbilityCheckmark;
    public Image ammoCheckmark;
    public Image crazyEnemyCheckmark;
    public Image upsideDownCheckmark;

    public Image machinegunChallenge;
    public Image minigunChallenge;
    public Image shotgunChallenge;
    public Image laserChallenge;
    public Image sniperChallenge;
    public Image rocketChallenge;

    public Image gEnemyChallenge;
    public Image rEnemyChallenge;
    public Image yEnemyChallenge;
    public Image pEnemyChallenge;
    public Image cEnemyChallenge;
    public Image oEnemyChallenge;

    public Image slowChallenge;
    public Image fastChallenge;
    public Image noAbilityChallenge;
    public Image ammoChallenge;
    public Image crazyEnemyChallenge;
    public Image upsideDownChallenge;

    public Sprite whiteSkull;
    public Sprite yellowSkull;
    public Sprite redSkull;
    public Sprite checkmark;

    public Canvas playMenu;
    public GameObject weaponChallenges;
    public GameObject enemyChallenges;
    public GameObject otherChallenges;

    GameObject saveManager;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.Find("SaveManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (playMenu.enabled)
        {
            if (saveManager.GetComponent<SaveManager>().easyMode != "unbeaten")
            {
                easySkull.enabled = true;
                if (saveManager.GetComponent<SaveManager>().easyMode == "beaten")
                {
                    easySkull.sprite = whiteSkull;
                }
                else if (saveManager.GetComponent<SaveManager>().easyMode == "noContinues")
                {
                    easySkull.sprite = yellowSkull;
                }
                else
                {
                    easySkull.sprite = redSkull;
                }
            }
            if (saveManager.GetComponent<SaveManager>().normalMode != "unbeaten")
            {
                normalSkull.enabled = true;
                if (saveManager.GetComponent<SaveManager>().normalMode == "beaten")
                {
                    normalSkull.sprite = whiteSkull;
                }
                else if (saveManager.GetComponent<SaveManager>().normalMode == "noContinues")
                {
                    normalSkull.sprite = yellowSkull;
                }
                else
                {
                    normalSkull.sprite = redSkull;
                }
            }
            if (saveManager.GetComponent<SaveManager>().hardMode != "unbeaten")
            {
                hardSkull.enabled = true;
                if (saveManager.GetComponent<SaveManager>().hardMode == "beaten")
                {
                    hardSkull.sprite = whiteSkull;
                }
                else if (saveManager.GetComponent<SaveManager>().hardMode == "noContinues")
                {
                    hardSkull.sprite = yellowSkull;
                }
                else
                {
                    hardSkull.sprite = redSkull;
                }
            }
            if (saveManager.GetComponent<SaveManager>().weaponChallenges == 6)
            {
                weaponCheckmark.enabled = true;
            }
            if (saveManager.GetComponent<SaveManager>().enemyChallenges == 6)
            {
                enemyCheckmark.enabled = true;
            }
            if (saveManager.GetComponent<SaveManager>().otherChallenges == 6)
            {
                otherCheckmark.enabled = true;
            }
        }
        else if (weaponChallenges.gameObject.activeSelf)
        {
            if (saveManager.GetComponent<SaveManager>().machinegunChallenge)
            {
                machinegunCheckmark.enabled = true;
                machinegunChallenge.color = new Color(1, 1, 1, .5f);
            }
            if (saveManager.GetComponent<SaveManager>().minigunChallenge)
            {
                minigunCheckmark.enabled = true;
                minigunChallenge.color = new Color(1, 1, 1, .5f);
            }
            if (saveManager.GetComponent<SaveManager>().shotgunChallenge)
            {
                shotgunCheckmark.enabled = true;
                shotgunChallenge.color = new Color(1, 1, 1, .5f);
            }
            if (saveManager.GetComponent<SaveManager>().laserChallenge)
            {
                laserCheckmark.enabled = true;
                laserChallenge.color = new Color(1, 1, 1, .5f);
            }
            if (saveManager.GetComponent<SaveManager>().sniperChallenge)
            {
                sniperCheckmark.enabled = true;
                sniperChallenge.color = new Color(1, 1, 1, .5f);
            }
            if (saveManager.GetComponent<SaveManager>().rocketChallenge)
            {
                rocketCheckmark.enabled = true;
                rocketChallenge.color = new Color(1, 1, 1, .5f);
            }
        }
        else if (enemyChallenges.gameObject.activeSelf)
        {
            if (saveManager.GetComponent<SaveManager>().gEnemyChallenge)
            {
                gEnemyCheckmark.enabled = true;
                gEnemyChallenge.color = new Color(1, 1, 1, .5f);
            }
            if (saveManager.GetComponent<SaveManager>().yEnemyChallenge)
            {
                yEnemyCheckmark.enabled = true;
                yEnemyChallenge.color = new Color(1, 1, 1, .5f);
            }
            if (saveManager.GetComponent<SaveManager>().rEnemyChallenge)
            {
                rEnemyCheckmark.enabled = true;
                rEnemyChallenge.color = new Color(1, 1, 1, .5f);
            }
            if (saveManager.GetComponent<SaveManager>().cEnemyChallenge)
            {
                cEnemyCheckmark.enabled = true;
                cEnemyChallenge.color = new Color(1, 1, 1, .5f);
            }
            if (saveManager.GetComponent<SaveManager>().oEnemyChallenge)
            {
                oEnemyCheckmark.enabled = true;
                oEnemyChallenge.color = new Color(1, 1, 1, .5f);
            }
            if (saveManager.GetComponent<SaveManager>().pEnemyChallenge)
            {
                pEnemyCheckmark.enabled = true;
                pEnemyChallenge.color = new Color(1, 1, 1, .5f);
            }
        }
        else if (otherChallenges.gameObject.activeSelf)
        {
            if (saveManager.GetComponent<SaveManager>().fastChallenge)
            {
                fastCheckmark.enabled = true;
                fastChallenge.color = new Color(1, 1, 1, .5f);
            }
            if (saveManager.GetComponent<SaveManager>().slowChallenge)
            {
                slowCheckmark.enabled = true;
                slowChallenge.color = new Color(1, 1, 1, .5f);
            }
            if (saveManager.GetComponent<SaveManager>().ammoChallenge)
            {
                ammoCheckmark.enabled = true;
                ammoChallenge.color = new Color(1, 1, 1, .5f);
            }
            if (saveManager.GetComponent<SaveManager>().noAbilityChallenge)
            {
                noAbilityCheckmark.enabled = true;
                noAbilityChallenge.color = new Color(1, 1, 1, .5f);
            }
            if (saveManager.GetComponent<SaveManager>().upsideDownChallenge)
            {
                upsideDownCheckmark.enabled = true;
                upsideDownChallenge.color = new Color(1, 1, 1, .5f);
            }
            if (saveManager.GetComponent<SaveManager>().crazyEnemyChallenge)
            {
                crazyEnemyCheckmark.enabled = true;
                crazyEnemyChallenge.color = new Color(1, 1, 1, .5f);
            }
        }
    }
}
