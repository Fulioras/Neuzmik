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
    int maxXP = 100000;

    void Start()
    {
        DabartinisZaidejoXP = PlayerPrefs.GetFloat("DabartinisZaidejoXP", 0);
        DabartinisZaidejoLygis = PlayerPrefs.GetInt("DabartinisZaidejoLygis", 1);
        UpdateLevel();
        ZaidejoLygis.text = DabartinisZaidejoLygis + " Level";
    }
    //pushas

    void Update()
    {
        if(DabartinisZaidejoLygis == 50){
            ZaidejoXP.text = "MAX";
            ZaidejoLygis.text = DabartinisZaidejoLygis + " Level [MAX]";
        }
        else{
            ZaidejoXP.text = "XP " + DabartinisZaidejoXP + " / " + reikiamasXpKiekis + " [" + Mathf.RoundToInt((DabartinisZaidejoXP / reikiamasXpKiekis) * 100) + "%]";
        }
        if (DabartinisZaidejoXP >= reikiamasXpKiekis && DabartinisZaidejoLygis != 50)
        {
            DabartinisZaidejoXP -= reikiamasXpKiekis;
            DabartinisZaidejoLygis++;
            UpdateLevel();
            if(DabartinisZaidejoXP < 0){
                DabartinisZaidejoXP = 0;
            }
            ZaidejoLygis.text = DabartinisZaidejoLygis + " Level";
        }

        if (xpSlider != null & DabartinisZaidejoLygis != 50)
        {
            float targetSliderValue = (float)DabartinisZaidejoXP / (float)reikiamasXpKiekis;
            xpSlider.value = Mathf.Lerp(xpSlider.value, targetSliderValue, Time.deltaTime * fillSpeed);
        }
        else if(DabartinisZaidejoLygis == 50){
            xpSlider.value = 1;
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("DabartinisZaidejoXP", DabartinisZaidejoXP);
        PlayerPrefs.SetInt("DabartinisZaidejoLygis", DabartinisZaidejoLygis);
    }

    void UpdateLevel()
    {
        reikiamasXpKiekis = Mathf.RoundToInt(maxXP * Mathf.Pow(DabartinisZaidejoLygis, 2) / Mathf.Pow(49, 2));
    }
}
