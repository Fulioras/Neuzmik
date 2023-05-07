using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class XP : MonoBehaviour
{
 public TextMeshProUGUI ZaidejoXP;
 public TextMeshProUGUI ZaidejoLygis;
 public static float DabartinisZaidejoXP;
 public int reikiamasXpKiekis = 100;
 public int DabartinisZaidejoLygis;
 public float fillSpeed = 5f;
public Slider xpSlider;

 void Start()
 {
    DabartinisZaidejoXP = PlayerPrefs.GetFloat("DabartinisZaidejoXP", 0); 
    DabartinisZaidejoLygis = PlayerPrefs.GetInt("DabartinisZaidejoLygis", 0); 
    UpdateLevel();
    ZaidejoLygis.text = DabartinisZaidejoLygis + " Lygis";
 }
    void Update()
    {
        ZaidejoXP.text = "XP " + DabartinisZaidejoXP + " / " + reikiamasXpKiekis + " [" + Mathf.RoundToInt((DabartinisZaidejoXP/reikiamasXpKiekis)*100) + "%]";
        if(DabartinisZaidejoXP >= reikiamasXpKiekis){
            DabartinisZaidejoXP -= reikiamasXpKiekis;
            DabartinisZaidejoLygis++;
            UpdateLevel();
            ZaidejoLygis.text = DabartinisZaidejoLygis + " Lygis";
        }
        if (xpSlider != null && DabartinisZaidejoXP > 0)
        {
            float targetSliderValue = (float)DabartinisZaidejoXP / (float)reikiamasXpKiekis;
            xpSlider.value = Mathf.Lerp(xpSlider.value, targetSliderValue, Time.deltaTime * fillSpeed);
        }
    }
    void OnDisable()
    {
        PlayerPrefs.SetFloat("DabartinisZaidejoXP", DabartinisZaidejoXP);
        PlayerPrefs.SetInt("DabartinisZaidejoLygis", DabartinisZaidejoLygis);
    }
    void UpdateLevel()
    {
        if(DabartinisZaidejoLygis == 1){
            reikiamasXpKiekis = 100;
        }
        else if(DabartinisZaidejoLygis == 2){
            reikiamasXpKiekis = 220;
        }
        else if(DabartinisZaidejoLygis == 3){
            reikiamasXpKiekis = 480;
        }
        else if(DabartinisZaidejoLygis == 4){
            reikiamasXpKiekis = 680;
        }
        else if(DabartinisZaidejoLygis == 5){
            reikiamasXpKiekis = 950;
        }
        else if(DabartinisZaidejoLygis == 6){
            reikiamasXpKiekis = 1120;
        }
        else if(DabartinisZaidejoLygis == 7){
            reikiamasXpKiekis = 1400;
        }
        else if(DabartinisZaidejoLygis == 8){
            reikiamasXpKiekis = 1860;
        }
        else if(DabartinisZaidejoLygis == 9){
            reikiamasXpKiekis = 2130;
        }
        else if(DabartinisZaidejoLygis == 10){
            reikiamasXpKiekis = 2470;
        }
    }
}
