using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;

    void Start()
    {
        // Set the slider value to the current audio source volume
        slider.value = audioSource.volume;

        // Add a listener to the slider to detect changes in value
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        // Set the audio source volume to the new slider value
        audioSource.volume = value;
    }
}
