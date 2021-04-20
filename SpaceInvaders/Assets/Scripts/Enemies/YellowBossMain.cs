using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBossMain : MonoBehaviour
{
    public int health;
    bool moveRight;
    float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
            if (transform.position.x > 7.5f)
            {
                moveRight = false;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
            if (transform.position.x < -7.5f)
            {
                moveRight = true;
            }
        }
    }
}
