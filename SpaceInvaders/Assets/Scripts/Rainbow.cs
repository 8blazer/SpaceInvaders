using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    Color color;
    string colorShift = "greenUp";
    float changeTimer;
    // Start is called before the first frame update
    void Start()
    {
        color = new Color(1, 0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        changeTimer += Time.deltaTime;
        if (changeTimer > .025f)
        {
            if (colorShift == "redUp")
            {
                color += new Color(.05f, 0, 0, 1);
                if (color.r > .95f)
                {
                    colorShift = "blueDown";
                }
            }
            else if (colorShift == "blueDown")
            {
                color += new Color(0, 0, -.05f, 1);
                if (color.b < .05f)
                {
                    colorShift = "greenUp";
                }
            }
            else if (colorShift == "greenUp")
            {
                color += new Color(0, .05f, 0, 1);
                if (color.g > .95f)
                {
                    colorShift = "redDown";
                }
            }
            else if (colorShift == "redDown")
            {
                color += new Color(-.05f, 0, 0, 1);
                if (color.r < .05f)
                {
                    colorShift = "blueUp";
                }
            }
            else if (colorShift == "blueUp")
            {
                color += new Color(0, 0, .05f, 1);
                if (color.b > .95f)
                {
                    colorShift = "greenDown";
                }
            }
            else if (colorShift == "greenDown")
            {
                color += new Color(0, -.05f, 0, 1);
                if (color.g < .05f)
                {
                    colorShift = "redUp";
                }
            }
            changeTimer = 0;
            GetComponent<SpriteRenderer>().color = color;
        }
    }
}
