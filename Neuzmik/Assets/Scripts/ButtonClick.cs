using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public GameObject audioObject; // Reference to the GameObject with the AudioSource component

    private Button button;
    private AudioSource audioSource;

    private void Start()
    {
        // Get references to the Button and AudioSource components
        button = GetComponent<Button>();
        audioSource = audioObject.GetComponent<AudioSource>();

        // Assign the sound to play on button click
        button.onClick.AddListener(PlayClickSound);
    }

    private void PlayClickSound()
    {
        // Play the audio clip assigned to the AudioSource
        audioSource.Play();
    }
}
