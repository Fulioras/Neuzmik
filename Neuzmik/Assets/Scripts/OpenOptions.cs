using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenOptions : MonoBehaviour
{
    public GameObject Options;

    public void Open(){
        if(StartGame.etapas == 1){
            Options.SetActive(true);
    }
    else{
        SceneManager.LoadScene("Shopas");
    }
    }
    public void Close(){
        Options.SetActive(false);
    }

}
