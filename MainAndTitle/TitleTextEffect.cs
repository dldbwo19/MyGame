using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleTextEffect : MonoBehaviour
{
    public Image PressAnyKey;
    bool isHide = true;


    void Update()
    {
        if (isHide)
        {
            Color color = PressAnyKey.color;
            color.a = color.a - Time.deltaTime;
            

            if (color.a < 0)
            {
                color.a = 0.0f;
                isHide = false;
            }
            PressAnyKey.color = color;
        }

        else
        {
            Color color = PressAnyKey.color;
            color.a = color.a + Time.deltaTime;
            

            if (color.a > 1)
            {
                color.a = 1.0f;
                isHide = true;
            }
            PressAnyKey.color = color;
        }
    }
}
