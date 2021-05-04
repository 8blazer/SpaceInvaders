using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject player;
    public Canvas UI_Canvas;

    bool offenseOneBought;
    bool offenseTwoBought;
    bool defenseOneBought;
    bool defenseTwoBought;
    bool abilityOneBought;
    bool abilityTwoBought;

    public bool dmgBought;
    public bool exDmgBought;
    public bool critBought;
    public bool exCritBought;
    public bool deathBought;
    public bool dodgeBought;
    public bool exDodgeBought;
    public bool reflectBought;
    bool superShotBought;

    public Button dmg;
    public Button exDMG;
    public Button ammo;
    public Button crit;
    public Button exCrit;
    public Button death;
    public Button dodge;
    public Button exDodge;
    public Button shield;
    public Button speed;
    public Button exSpeed;
    public Button reflect;
    public Button superShot;
    public Button ultraShot;
    public Button doppelganger;
    public Button enemyJam;
    public Button enemyFreeze;
    public Button invincibility;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (offenseTwoBought)
        {
            dmg.GetComponent<Button>().interactable = false;
            exDMG.GetComponent<Button>().interactable = false;
            ammo.GetComponent<Button>().interactable = false;
            crit.GetComponent<Button>().interactable = false;
            exCrit.GetComponent<Button>().interactable = false;
            death.GetComponent<Button>().interactable = false;
        }
        else if (offenseOneBought)
        {
            if (dmgBought)
            {
                ammo.GetComponent<Button>().interactable = true;
                exDMG.GetComponent<Button>().interactable = true;
                exCrit.GetComponent<Button>().interactable = false;
                death.GetComponent<Button>().interactable = false;
            }
            else
            {
                ammo.GetComponent<Button>().interactable = false;
                exDMG.GetComponent<Button>().interactable = false;
                exCrit.GetComponent<Button>().interactable = true;
                death.GetComponent<Button>().interactable = true;
            }
            dmg.GetComponent<Button>().interactable = false;
            crit.GetComponent<Button>().interactable = false;
        }
        else
        {
            dmg.GetComponent<Button>().interactable = true;
            crit.GetComponent<Button>().interactable = true;
            ammo.GetComponent<Button>().interactable = false;
            exDMG.GetComponent<Button>().interactable = false;
            exCrit.GetComponent<Button>().interactable = false;
            death.GetComponent<Button>().interactable = false;
        }

        if (defenseTwoBought)
        {
            dodge.GetComponent<Button>().interactable = false;
            exDodge.GetComponent<Button>().interactable = false;
            shield.GetComponent<Button>().interactable = false;
            speed.GetComponent<Button>().interactable = false;
            exSpeed.GetComponent<Button>().interactable = false;
            reflect.GetComponent<Button>().interactable = false;
        }
        else if (defenseOneBought)
        {
            if (dodgeBought)
            {
                exDodge.GetComponent<Button>().interactable = true;
                shield.GetComponent<Button>().interactable = true;
                exSpeed.GetComponent<Button>().interactable = false;
                reflect.GetComponent<Button>().interactable = false;
            }
            else
            {
                exDodge.GetComponent<Button>().interactable = false;
                shield.GetComponent<Button>().interactable = false;
                exSpeed.GetComponent<Button>().interactable = true;
                reflect.GetComponent<Button>().interactable = true;
            }
            dodge.GetComponent<Button>().interactable = false;
            speed.GetComponent<Button>().interactable = false;
        }
        else
        {
            dodge.GetComponent<Button>().interactable = true;
            speed.GetComponent<Button>().interactable = true;
            exSpeed.GetComponent<Button>().interactable = false;
            exDodge.GetComponent<Button>().interactable = false;
            shield.GetComponent<Button>().interactable = false;
            reflect.GetComponent<Button>().interactable = false;
        }

        if (abilityTwoBought)
        {
            superShot.GetComponent<Button>().interactable = false;
            enemyJam.GetComponent<Button>().interactable = false;
            ultraShot.GetComponent<Button>().interactable = false;
            enemyFreeze.GetComponent<Button>().interactable = false;
            doppelganger.GetComponent<Button>().interactable = false;
            invincibility.GetComponent<Button>().interactable = false;
        }
        else if (abilityOneBought)
        {
            if (superShotBought)
            {
                ultraShot.GetComponent<Button>().interactable = true;
                enemyFreeze.GetComponent<Button>().interactable = false;
                doppelganger.GetComponent<Button>().interactable = true;
                invincibility.GetComponent<Button>().interactable = false;
            }
            else
            {
                ultraShot.GetComponent<Button>().interactable = false;
                enemyFreeze.GetComponent<Button>().interactable = true;
                doppelganger.GetComponent<Button>().interactable = false;
                invincibility.GetComponent<Button>().interactable = true;
            }
            superShot.GetComponent<Button>().interactable = false;
            enemyJam.GetComponent<Button>().interactable = false;
        }
        else
        {
            superShot.GetComponent<Button>().interactable = true;
            enemyJam.GetComponent<Button>().interactable = true;
            ultraShot.GetComponent<Button>().interactable = false;
            enemyFreeze.GetComponent<Button>().interactable = false;
            doppelganger.GetComponent<Button>().interactable = false;
            invincibility.GetComponent<Button>().interactable = false;
        }
    }

    public void DMG()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        offenseOneBought = true;
        dmgBought = true;
    }

    public void ExDMG()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        offenseTwoBought = true;
        exDmgBought = true;
    }

    public void Ammo()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        player.GetComponent<PlayerShoot>().ammoUpgrade = true;
        if (player.GetComponent<PlayerShoot>().weapon == "machinegun")
        {
            player.GetComponent<PlayerShoot>().ammoMax = 75;
        }
        else if (player.GetComponent<PlayerShoot>().weapon == "minigun")
        {
            player.GetComponent<PlayerShoot>().ammoMax = 60;
        }
        else if (player.GetComponent<PlayerShoot>().weapon == "shotgun")
        {
            player.GetComponent<PlayerShoot>().ammoMax = 15;
        }
        else if (player.GetComponent<PlayerShoot>().weapon == "sniper")
        {
            player.GetComponent<PlayerShoot>().ammoMax = 25;
        }
        else if (player.GetComponent<PlayerShoot>().weapon == "rocket")
        {
            player.GetComponent<PlayerShoot>().ammoMax = 20;
        }
        else
        {
            player.GetComponent<PlayerShoot>().ammoMax = 20;
        }
        player.GetComponent<PlayerShoot>().ammo = player.GetComponent<PlayerShoot>().ammoMax;
        offenseTwoBought = true;
    }

    public void Crit()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        offenseOneBought = true;
        critBought = true;
    }

    public void ExCrit()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        offenseTwoBought = true;
        exCritBought = true;
    }

    public void Death()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        offenseTwoBought = true;
        deathBought = true;
    }

    public void Dodge()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        defenseOneBought = true;
        dodgeBought = true;
    }

    public void ExDodge()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        defenseTwoBought = true;
        exDodgeBought = true;
    }

    public void Shield()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        defenseTwoBought = true;
        player.GetComponent<PlayerAbility>().shieldBought = true;
    }

    public void Speed()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        defenseOneBought = true;
        player.GetComponent<PlayerMovement>().moveSpeed++;
    }

    public void ExSpeed()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        defenseTwoBought = true;
        player.GetComponent<PlayerMovement>().moveSpeed++;
    }

    public void Reflect()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        defenseTwoBought = true;
        reflectBought = true;
    }

    public void SuperShot()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        abilityOneBought = true;
        superShotBought = true;
        player.GetComponent<PlayerAbility>().activeAbility = "SuperShot";
    }

    public void UltraShot()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        abilityTwoBought = true;
        player.GetComponent<PlayerAbility>().activeAbility = "UltraShot";
    }

    public void Doppelganger()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        abilityTwoBought = true;
        player.GetComponent<PlayerAbility>().activeAbility = "Doppelganger";
    }

    public void EnemyJam()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        abilityOneBought = true;
        player.GetComponent<PlayerAbility>().activeAbility = "EnemyJam";
    }

    public void EnemyFreeze()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        abilityTwoBought = true;
        player.GetComponent<PlayerAbility>().activeAbility = "EnemyFreeze";
    }

    public void Invincibility()
    {
        gameManager.GetComponent<Game_Manager>().upgrading = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.transform.position = new Vector3(0, -4, 0);
        UI_Canvas.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        abilityTwoBought = true;
        player.GetComponent<PlayerAbility>().activeAbility = "Invincibility";
    }
}
