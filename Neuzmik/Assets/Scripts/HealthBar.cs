using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Slider healthSlider;
    public float fillSpeed = 5f;

    public void Start()
    {
        PlayerHealth.currentPlayerHealth = PlayerHealth.maxPlayerHealth;
    }

    private void Update()
    {
        // Ensure that health text is updated correctly
        if (healthText != null)
        {
            healthText.text = "" + PlayerHealth.currentPlayerHealth + " / " + PlayerHealth.maxPlayerHealth;
        }

        // Ensure that health slider value is updated correctly
        if (healthSlider != null && PlayerHealth.maxPlayerHealth > 0)
        {
            float targetSliderValue = (float)PlayerHealth.currentPlayerHealth / (float)PlayerHealth.maxPlayerHealth;
            healthSlider.value = Mathf.Lerp(healthSlider.value, targetSliderValue, Time.deltaTime * fillSpeed);
        }
    }
}
