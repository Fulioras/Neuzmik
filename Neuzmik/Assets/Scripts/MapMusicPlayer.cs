using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMusicPlayer : MonoBehaviour
{
    public GameObject mainMusicPlayer;

    private void Awake()
    {
            Destroy(mainMusicPlayer); 
    }
}
