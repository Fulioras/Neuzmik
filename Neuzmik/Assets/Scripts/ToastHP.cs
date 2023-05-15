using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastHP : MonoBehaviour
{
    public Sprite[] Toast;
    int[] suvalgymas = new int[12];
    // Update is called once per frame

    void start()
    {
        int gyvybes = PlayerHealth.maxPlayerHealth;
        int likoGyvybiu = PlayerHealth.currentPlayerHealth;
    }
    void Update()
    {
        
    }
}
