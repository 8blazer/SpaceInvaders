using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperGreenBullet : MonoBehaviour
{
    public float growthRate;
    public float speedRate;

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(growthRate * Time.deltaTime, growthRate * Time.deltaTime, 0);
        GetComponent<Rigidbody2D>().velocity += new Vector2(0, -speedRate * Time.deltaTime);
    }
}
