using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string parameterName = "Muzika";
    public Slider slider;

    // Define the minimum and maximum volume values in dB
    public float minVolume = -70f;
    public float maxVolume = 20f;
    public string volumePrefKey = "MusicVolume";

    private void Start()
    {
        // Initialize the slider value based on the current volume level or player preference
        float volume;
        bool result = audioMixer.GetFloat(parameterName, out volume);

        if (!result)
        {
            // If the audio mixer doesn't have the parameter, try loading the volume preference
            if (PlayerPrefs.HasKey(volumePrefKey))
            {
                volume = PlayerPrefs.GetFloat(volumePrefKey);
                result = true;
            }
        }

        if (result)
        {
            // Convert the volume range from dB to a normalized value between 0 and 1
            float normalizedValue = Mathf.InverseLerp(minVolume, maxVolume, volume);
            slider.value = normalizedValue;
        }

        // Add a listener to the slider value change
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float normalizedValue)
    {
        // Convert the normalized value to the volume range in dB
        float volume = Mathf.Lerp(minVolume, maxVolume, normalizedValue);

        // Update the volume parameter in the audio mixer
        audioMixer.SetFloat(parameterName, volume);

        // Save the volume preference
        PlayerPrefs.SetFloat(volumePrefKey, volume);
        PlayerPrefs.Save();
    }

    private void OnDestroy()
    {
        // Save the volume preference when the script is destroyed
        PlayerPrefs.Save();
    }
}
