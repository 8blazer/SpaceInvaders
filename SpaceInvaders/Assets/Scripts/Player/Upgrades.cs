using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject player;
    public Canvas UI_Canvas;

    public bool dmgBought;
    public bool exDmgBought;
    public bool critBought;
    public bool exCritBought;
    public bool deathBought;
    public bool dodgeBought;
    bool speedBought;
    bool exSpeedBought;
    public bool exDodgeBought;
    public bool reflectBought;
    bool superShotBought;
    bool ultraShotBought;
    bool doppelgangerBought;
    bool jamBought;
    bool freezeBought;
    bool invincibilityBought;

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
        if (dmgBought)
        {
            if (!exDmgBought)
            {
                exDMG.GetComponent<Button>().interactable = true;
            }
            if (!player.GetComponent<PlayerShoot>().ammoUpgrade)
            {
                ammo.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            dmg.GetComponent<Button>().interactable = true;
        }

        if (critBought)
        {
            if (!exCritBought)
            {
                exCrit.GetComponent<Button>().interactable = true;
            }
            if (!deathBought)
            {
                death.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            crit.GetComponent<Button>().interactable = true;
        }



        if (dodgeBought)
        {
            if (!exDodgeBought)
            {
                exDodge.GetComponent<Button>().interactable = true;
            }
            if (!player.GetComponent<PlayerAbility>().shieldBought)
            {
                shield.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            dodge.GetComponent<Button>().interactable = true;
        }

        if (speedBought)
        {
            if (!exSpeedBought)
            {
                exSpeed.GetComponent<Button>().interactable = true;
            }
            if (!reflectBought)
            {
                reflect.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            speed.GetComponent<Button>().interactable = true;
        }



        if (superShotBought)
        {
            if (!ultraShotBought)
            {
                ultraShot.GetComponent<Button>().interactable = true;
            }
            if (!doppelgangerBought)
            {
                doppelganger.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            superShot.GetComponent<Button>().interactable = true;
        }

        if (jamBought)
        {
            if (!freezeBought)
            {
                enemyFreeze.GetComponent<Button>().interactable = true;
            }
            if (!invincibilityBought)
            {
                invincibility.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            enemyJam.GetComponent<Button>().interactable = true;
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
        dmgBought = true;
        dmg.GetComponent<Button>().interactable = false;
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
        exDmgBought = true;
        exDMG.GetComponent<Button>().interactable = false;
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
        ammo.GetComponent<Button>().interactable = false;
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
        critBought = true;
        crit.GetComponent<Button>().interactable = false;
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
        exCritBought = true;
        exCrit.GetComponent<Button>().interactable = false;
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
        deathBought = true;
        death.GetComponent<Button>().interactable = false;
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
        dodgeBought = true;
        dodge.GetComponent<Button>().interactable = false;
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
        exDodgeBought = true;
        exDodge.GetComponent<Button>().interactable = false;
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
        player.GetComponent<PlayerAbility>().shieldBought = true;
        shield.GetComponent<Button>().interactable = false;
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
        player.GetComponent<PlayerMovement>().moveSpeed++;
        speed.GetComponent<Button>().interactable = false;
        speedBought = true;
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
        player.GetComponent<PlayerMovement>().moveSpeed++;
        exSpeed.GetComponent<Button>().interactable = false;
        exSpeedBought = true;
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
        reflectBought = true;
        reflect.GetComponent<Button>().interactable = false;
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
        superShotBought = true;
        player.GetComponent<PlayerAbility>().activeAbility = "SuperShot";
        superShot.GetComponent<Button>().interactable = false;
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
        player.GetComponent<PlayerAbility>().activeAbility = "UltraShot";
        ultraShot.GetComponent<Button>().interactable = false;
        ultraShotBought = true;
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
        player.GetComponent<PlayerAbility>().activeAbility = "Doppelganger";
        doppelganger.GetComponent<Button>().interactable = false;
        doppelgangerBought = true;
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
        player.GetComponent<PlayerAbility>().activeAbility = "EnemyJam";
        enemyJam.GetComponent<Button>().interactable = false;
        jamBought = true;
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
        player.GetComponent<PlayerAbility>().activeAbility = "EnemyFreeze";
        enemyFreeze.GetComponent<Button>().interactable = false;
        freezeBought = true;
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
        player.GetComponent<PlayerAbility>().activeAbility = "Invincibility";
        invincibility.GetComponent<Button>().interactable = false;
        invincibilityBought = true;
    }
}
