using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XP : MonoBehaviour
{
 public TextMeshProUGUI ZaidejoXP;
 public static int DabartinisZaidejoXP;
 void Start()
 {
    DabartinisZaidejoXP = PlayerPrefs.GetInt("DabartinisZaidejoXP", 0); 
 }
    void Update()
    {
        ZaidejoXP.text = "Tavo XP: " + DabartinisZaidejoXP;
    }
    void OnDisable()
    {
        PlayerPrefs.SetInt("DabartinisZaidejoXP", DabartinisZaidejoXP);
    }
}
