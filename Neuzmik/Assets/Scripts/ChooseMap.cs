using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ChooseMap : MonoBehaviour
{
    public Image mapImage;
    public TextMeshProUGUI requiredLevelText;
    public Button[] mapButtons;
    public Button[] difficultyButtons;
    public static int selectedMapIndex = 0;
    public static int selectedDifficultyIndex = 0;
    private string[] mapNames = { "Dungeon", "City", "Park" };
    private Sprite[] mapSprites;
    private int[] requiredLevels = { 1, 15, 30 };
    private int[] difficultyLevels = { 0, 5, 10 };
    private Color normalButtonColor = Color.white;
    private Color selectedButtonColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    public int DabartinisZaidejoLygis;
    public int ReikiamasZaidejoLygis;
    public TextMeshProUGUI yourLevelText;
    public Button Play;

    public TextMeshProUGUI xpMultiplierText;
    public TextMeshProUGUI lootMultiplierText;
    public bool HardcoreRezimas = false;
    public Image hardcoreButtonImage; // Reference to the Hardcore button's Image component
    
    public GameObject hearts;

    // Multiplier values
    private float xpMultiplier = 1f;
    private float lootMultiplier = 1f;

    private void Start()
    {
        DabartinisZaidejoLygis = PlayerPrefs.GetInt("DabartinisZaidejoLygis", 0);
        yourLevelText.text = "Your level: " + DabartinisZaidejoLygis;
        mapSprites = new Sprite[mapNames.Length];
        for (int i = 0; i < mapNames.Length; i++)
        {
            string spritePath = "Sprites/" + mapNames[i];
            mapSprites[i] = Resources.Load<Sprite>(spritePath);
        }

        SelectMap(0);
        SelectDifficulty(0);
        UpdateMap();

        for (int i = 0; i < difficultyButtons.Length; i++)
        {
            int index = i;
            difficultyButtons[i].onClick.AddListener(() => SelectDifficulty(index));
        }
    }

    private void Update()
    {
        xpMultiplierText.text = "Experience Multiplier: " + GetExperienceMultiplier() + "x";
        lootMultiplierText.text = "Loot Multiplier: " + GetLootMultiplier() + "x";
        if (DabartinisZaidejoLygis < ReikiamasZaidejoLygis)
        {
            Play.interactable = false;
        }
        else
        {
            Play.interactable = true;
        }
    }

    public void SelectMap(int mapIndex)
    {
        if (mapIndex >= 0 && mapIndex < mapNames.Length)
        {
            ResetButtonColors();

            selectedMapIndex = mapIndex;
            UpdateMap();

            mapButtons[selectedMapIndex].image.color = selectedButtonColor;
        }
    }

    public void SelectDifficulty(int difficultyIndex)
    {
        if (difficultyIndex >= 0 && difficultyIndex <= 2)
        {
            ResetDifficultyButtonColors();

            selectedDifficultyIndex = difficultyIndex;
            UpdateMap();

            difficultyButtons[selectedDifficultyIndex].image.color = selectedButtonColor;

            // Set XP and Loot multipliers based on difficulty
            if (selectedDifficultyIndex == 1)
            {
                xpMultiplier = 1.4f;
                lootMultiplier = 1.4f;
            }
            else if (selectedDifficultyIndex == 2)
            {
                xpMultiplier = 2f;
                lootMultiplier = 2f;
            }
            else
            {
                xpMultiplier = 1f;
                lootMultiplier = 1f;
            }

            // Apply hardcore mode if enabled
            if (HardcoreRezimas)
            {
                xpMultiplier *= 2f;
                lootMultiplier *= 2f;
            }
        }
    }

    private void ResetButtonColors()
    {
        foreach (Button button in mapButtons)
        {
            button.image.color = normalButtonColor;
        }
    }

    private void ResetDifficultyButtonColors()
    {
        foreach (Button button in difficultyButtons)
        {
            button.image.color = normalButtonColor;
        }
    }

    private void UpdateMap()
    {
        mapImage.sprite = mapSprites[selectedMapIndex];
        int modifiedRequiredLevel = requiredLevels[selectedMapIndex] + difficultyLevels[selectedDifficultyIndex];
        ReikiamasZaidejoLygis = modifiedRequiredLevel;
        requiredLevelText.text = "Required Level: " + modifiedRequiredLevel.ToString();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(mapNames[selectedMapIndex]);
    }

    public void Hardcore()
    {
        if(HardcoreRezimas){
            HardcoreRezimas = false;
            hearts.SetActive(true);
            hardcoreButtonImage.color = Color.white;
        }
        else{
            HardcoreRezimas = true;
            hearts.SetActive(false);
            hardcoreButtonImage.color = selectedButtonColor;
        }
    }

    private float GetExperienceMultiplier()
    {
        if (HardcoreRezimas)
        {
            return xpMultiplier * 2f;
        }
        else
        {
            return xpMultiplier;
        }
    }

    private float GetLootMultiplier()
    {
        if (HardcoreRezimas)
        {
            return lootMultiplier * 2f;
        }
        else
        {
            return lootMultiplier;
        }
    }
}
