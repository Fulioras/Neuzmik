using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHP : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Slider healthSlider;
    public float fillSpeed = 5f;


  private void Update()
{
    // Ensure that health text is updated correctly
    if (healthText != null)
    {
        healthText.text = "BOSS HEALTH: " + Health.BosoCurrentHealth + " / " + Health.BosoMaxHealth;
    }
    Debug.Log(Health.BosoCurrentHealth);

    // Ensure that health slider value is updated correctly
    if (healthSlider != null)
    {
        float targetValue = Health.BosoCurrentHealth / Health.BosoMaxHealth; // Calculate the target fill value
        healthSlider.value = Mathf.Lerp(healthSlider.value, targetValue, Time.deltaTime * fillSpeed); // Smoothly update the slider value towards the target
    }

    if (Health.BosoCurrentHealth <= 0)
    {
        Destroy(gameObject);
    }
}

}
