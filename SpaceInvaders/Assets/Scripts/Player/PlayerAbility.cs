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
    public GameObject doppelganger;
    public bool jammed;
    public int jamTime;
    float jamTimer;
    public bool frozen;
    public int freezeTime;
    float freezeTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeAbility != "" && !frozen && !jammed)
        {
            abilityCharge.value += Time.deltaTime;
            background.enabled = true;
            fill.enabled = true;
            handle.enabled = true;
        }
        else if (activeAbility == "")
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
                    doppelganger.transform.position = transform.position;
                    doppelganger.GetComponent<BoxCollider2D>().enabled = true;
                    doppelganger.GetComponent<Doppelganger>().enabled = true;
                    doppelganger.GetComponent<SpriteRenderer>().enabled = true;
                }
                else if (activeAbility == "EnemyJam")
                {
                    jammed = true;
                }
                else if (activeAbility == "EnemyFreeze")
                {
                    frozen = true;
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

        if (jammed)
        {
            jamTimer += Time.deltaTime;
            if (jamTimer > jamTime)
            {
                jammed = false;
                jamTimer = 0;
            }
        }
        else if (frozen)
        {
            freezeTimer += Time.deltaTime;
            if (freezeTimer > freezeTime)
            {
                frozen = false;
                freezeTimer = 0;
            }
        }
    }
}
