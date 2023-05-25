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
    float currentHealth = (float)Health.BosoCurrentHealth; // Convert to float
float maxHealth = (float)Health.BosoMaxHealth;
    if (healthText != null)
    {
        healthText.text = "BOSS HEALTH: " + Health.BosoCurrentHealth + " / " + Health.BosoMaxHealth;
    }
    Debug.Log(Health.BosoCurrentHealth);

    // Ensure that health slider value is updated correctly
    if (healthSlider != null)
    {
        float targetValue = currentHealth / maxHealth;
        healthSlider.value = Mathf.Lerp(healthSlider.value, targetValue, Time.deltaTime * fillSpeed);
    }

    if (Health.BosoCurrentHealth <= 0)
    {
        Destroy(gameObject);
    }
}

}
