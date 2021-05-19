using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("challenge") == "UpsideDown")
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
