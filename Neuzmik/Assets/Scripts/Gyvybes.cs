using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gyvybes : MonoBehaviour
{
    int ZaidejoGyvybes = ChooseMap.GyvybiuKiekis - 1;
    public TextMeshProUGUI MygtukoTekstas;
    public Button PrisikelimoMygtukas;
    public GameObject MirtiesMeniu;
    public GameObject TreciaSirdele;
    public GameObject AntraSirdele;

    void Start()
    {
        
        if (ChooseMap.HardcoreRezimas)
        {
            PrisikelimoMygtukas.interactable = false;
            TreciaSirdele.SetActive(false);
            AntraSirdele.SetActive(false);
        }
    }
    void Update(){
        MygtukoTekstas.text = "Revive (" + ZaidejoGyvybes + ")";
    }

    public void Prisikelimas()
    {
        Time.timeScale = 1f;
        MirtiesMeniu.SetActive(false);
        PlayerHealth.currentPlayerHealth = PlayerHealth.maxPlayerHealth;
        EnergyBar.currentEnergy += 100;

        PushObjects();
        if (ZaidejoGyvybes == 2)
        {
            TreciaSirdele.SetActive(false);
        }
        else if (ZaidejoGyvybes == 1)
        {
            AntraSirdele.SetActive(false);
            PrisikelimoMygtukas.interactable = false;
        }
        ZaidejoGyvybes -= 1;
    }

    private void PushObjects()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f); // Adjust the sphere radius as needed

        foreach (Collider collider in colliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                Vector3 direction = (collider.transform.position - transform.position).normalized;
                rigidbody.AddForce(direction * 500f, ForceMode.Impulse); // Adjust the force as needed
            }
        }
    }
}
