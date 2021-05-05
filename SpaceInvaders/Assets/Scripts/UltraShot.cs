using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraShot : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        speed += Time.deltaTime;
        if (speed < 10)
        {
            speed += Time.deltaTime / 1.4f;
        }
        if (transform.localScale.x < 14)
        {
            transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * 3f, transform.localScale.y + Time.deltaTime * 3f, 1);
        }
        transform.Rotate(0, 0, -.3f);
        if (transform.position.y > 13)
        {
            Destroy(gameObject);
        }
    }
}

