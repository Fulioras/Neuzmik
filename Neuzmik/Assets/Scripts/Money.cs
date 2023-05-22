using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public static int PiniguKiekis;
    public TextMeshProUGUI KiekisTekstas;

    void Start()
    {
        PiniguKiekis = PlayerPrefs.GetInt("ZaidejoPinigai", 0);
    }
    void Update()
    {
        KiekisTekstas.text = "$" + PiniguKiekis;
    }
        void OnDisable()
    {
        PlayerPrefs.SetInt("ZaidejoPinigai", PiniguKiekis);
    }
}
