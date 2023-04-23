using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Image healthBar;
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

        // Ensure that health bar fill amount is updated correctly
        if (healthBar != null && PlayerHealth.maxPlayerHealth > 0)
        {
            float targetFillAmount = (float)PlayerHealth.currentPlayerHealth / (float)PlayerHealth.maxPlayerHealth;
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, targetFillAmount, Time.deltaTime * fillSpeed);
        }
    }
}
