using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOptions : MonoBehaviour
{
    public GameObject Options;

    public void Open(){
        Options.SetActive(true);
    }
    public void Close(){
        Options.SetActive(false);
    }

}
