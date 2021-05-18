using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "E_Bullet") && player.GetComponent<BoxCollider2D>().enabled)
        {
            player.GetComponent<PlayerAbility>().shieldTimer = 0;
            player.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
