using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public GameObject shield;
    public bool shieldBought = false;
    public float shieldTimer;
    public float shieldTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
