using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trailer : MonoBehaviour
{
    public int TrailerSeen;
    void Start()
    {
        TrailerSeen = PlayerPrefs.GetInt("Trailer", 0);
        if(TrailerSeen == 1){
            SceneManager.LoadScene("Menu");
        }
        else{
            TrailerSeen = 1;
        }
    }

    // Update is called once per frame
    void OnDisable()
    {
        PlayerPrefs.SetInt("Trailer", TrailerSeen);
    }
}
