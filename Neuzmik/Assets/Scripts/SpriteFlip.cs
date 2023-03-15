using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlip : MonoBehaviour
{
 void Update()
    {
        Vector2 zaidejas = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0)
        {
            zaidejas.x = -1;
        }else if (Input.GetAxis("Horizontal") > 0)
        {
            zaidejas.x = 1;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            zaidejas.y = -1;
        }else if (Input.GetAxis("Vertical") > 0)
        {
            zaidejas.y = 1;
        }
        transform.localScale = zaidejas;
    }
}
