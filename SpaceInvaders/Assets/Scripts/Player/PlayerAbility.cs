using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbility : MonoBehaviour
{
    public GameObject shield;
    public bool shieldBought = false;
    public float shieldTimer;
    public float shieldTime;
    public bool ability = false;
    public string activeAbility;
    public Slider abilityCharge;
    public Image fill;
    public Color abilityEmpty;
    public Color abilityFull;
    public Image handle;
    public Sprite handleEmpty;
    public Sprite handleFull;
    public Image background;
    public Sprite backgroundSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ability)
        {
            abilityCharge.value += Time.deltaTime;
            background.enabled = true;
            fill.enabled = true;
            handle.enabled = true;
        }
        else
        {
            background.enabled = false;
            fill.enabled = false;
            handle.enabled = false;
        }
        if (abilityCharge.value == 8)
        {
            fill.color = abilityFull;
            handle.sprite = handleFull;
            if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.E))
            {
                abilityCharge.value = 0;
                if (activeAbility == "SuperShot")
                {

                }
                else if (activeAbility == "UltraShot")
                {

                }
                else if (activeAbility == "Doppelganger")
                {

                }
                else if (activeAbility == "EnemyJam")
                {

                }
                else if (activeAbility == "EnemyFreeze")
                {

                }
                else
                {

                }
            }
        }
        else
        {
            fill.color = abilityEmpty;
            handle.sprite = handleEmpty;
        }
        if (shieldBought)
        {
            shieldTimer += Time.deltaTime;
        }
        if (shieldTimer > shieldTime)
        {
            shield.GetComponent<SpriteRenderer>().enabled = true;
            shield.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            shield.GetComponent<SpriteRenderer>().enabled = false;
            shield.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
