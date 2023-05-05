using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMeniu : MonoBehaviour
{
    public GameObject Options;
    public static bool openedOptions = false;
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && openedOptions == true)
        {
            Back();
        }
    }
    public void OpenOptions(){
        Options.SetActive(true);
        openedOptions = true;
    }
    public void Back(){
        Options.SetActive(false);
        openedOptions = false;
    }
}
