using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject SienaPasBosa;
    public static bool Bosas = false;

     private void Update()
    {
        if(Bosas){
            SienaPasBosa.SetActive(false);
        }
    }
}
