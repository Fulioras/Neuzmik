using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicChanger : MonoBehaviour
{
    public AudioClip MeniuMusic; //Audio clips
    public AudioClip DungeonMusic;
    public AudioClip CityMusic;
    public AudioClip ParkMusic;
    public AudioClip BossMusic;
    public AudioClip CasinoMusic;
    private AudioSource audioSource; // Reference to the AudioSource component
    private string oldSceneName = "";
    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the reference to the AudioSource component
        
    }
    public void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(sceneName);
        if(sceneName == oldSceneName)
        {

        }
        else if (sceneName == "Dungeon" && oldSceneName != "Dungeon")
        {
            PlayDungeon();
            oldSceneName = "Dungeon";
        }
        else if (sceneName == "City" && oldSceneName != "City")
        {
            PlayCity();
            oldSceneName = "City";
        }
        else if (sceneName == "Park" && oldSceneName != "Park")
        {
            PlayPark();
            oldSceneName = "Park";
        }
        else if (sceneName == "BlackJack" && oldSceneName != "BlackJack")
        {
            PlayCasino();
            oldSceneName = "BlackJack";
        }
        else if(oldSceneName == "City" || oldSceneName == "Park" || oldSceneName == "Dungeon" || oldSceneName == "BlackJack")
        {
            PlayMeniu();
            oldSceneName = "";
        }
    }

    public void PlayMeniu()
    {
        audioSource.clip = MeniuMusic;
        audioSource.Play();
    }

    public void PlayDungeon()
    {
        audioSource.clip = DungeonMusic;
        audioSource.Play();
    }
    public void PlayCity()
    {
        audioSource.clip = CityMusic;
        audioSource.Play();
    }
    public void PlayPark()
    {
        audioSource.clip = ParkMusic;
        audioSource.Play();
    }
    public void PlayBoss()
    {
        audioSource.clip = BossMusic;
        audioSource.Play();
    }
    public void PlayCasino()
    {
        audioSource.clip = CasinoMusic;
        audioSource.Play();
    }

}
