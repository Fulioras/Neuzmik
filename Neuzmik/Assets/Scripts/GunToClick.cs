using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunToClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) /// kairys mygtukas
        {
            Vector2 paspaudimoVieta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            //kampas kuriuo pasisuks
            float kampas = Mathf.Atan2(paspaudimoVieta.y, paspaudimoVieta.x) * Mathf.Rad2Deg;

            //pasisuka pagal z asi
            Quaternion posukis = Quaternion.AngleAxis(kampas, Vector3.forward);
            
            transform.rotation = posukis;
        }
    }
}
