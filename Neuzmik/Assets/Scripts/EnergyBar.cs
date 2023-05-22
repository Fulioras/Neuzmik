using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyBar : MonoBehaviour
{
    public float maxEnergy = 100f; // Maximum energy value
    public float decreaseRateNormal = 2f; // Rate at which energy decreases per second normally
    public float decreaseRateDisabled = 1f; // Rate at which energy decreases per second when decrease is disabled
    public static bool decreaseEnabled = true; // Toggle for enabling/disabling energy decrease

    public static float currentEnergy; // Current energy value
    private Slider energySlider; // Reference to the energy bar slider
    public TextMeshProUGUI energyText; // Reference to the text component
    public GameObject MirtiesZenklas;
    public TextMeshProUGUI MirtiesPranesimas;

    private void Start()
    {
        currentEnergy = maxEnergy;
        energySlider = GetComponent<Slider>();
        energySlider.maxValue = maxEnergy;
        energySlider.value = maxEnergy;
        UpdateEnergyText();
    }

    private void Update()
    {
        float decreaseAmount = decreaseEnabled ? decreaseRateNormal : decreaseRateDisabled;
        DecreaseEnergy(decreaseAmount * Time.deltaTime);

        UpdateEnergyBar();
        UpdateEnergyText();
        if(currentEnergy <= 0){
            Time.timeScale = 0f;
            Die();
        }
    }

    private void DecreaseEnergy(float amount)
    {
        currentEnergy -= amount;
        currentEnergy = Mathf.Clamp(currentEnergy, 0f, maxEnergy); // Ensure energy value stays within 0 and maxEnergy
    }

    private void UpdateEnergyBar()
    {
        energySlider.value = currentEnergy;
    }

    private void UpdateEnergyText()
    {
        int roundedEnergy = Mathf.RoundToInt(currentEnergy);
        energyText.text = "Energy: " + roundedEnergy.ToString() + " / 100";
    }
        private void Die()
    {
        MirtiesZenklas.SetActive(true);
        MirtiesPranesimas.text = "Tu užmigai...zzz";
    }
}
