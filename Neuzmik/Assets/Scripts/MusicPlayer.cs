using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour{
    private static MusicPlayer instance;

    private void Awake()
    {
        // Check if an instance of the MusicPlayer already exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy this instance if another one exists
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Persist this game object across scene changes
    }
}
