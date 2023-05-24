using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public AudioClip MeniuMusic; //Audio clips
    public AudioClip DungeonMusic;
    public AudioClip CityMusic;
    public AudioClip ParkMusic;
    public AudioClip BossMusic;
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the reference to the AudioSource component
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

}
