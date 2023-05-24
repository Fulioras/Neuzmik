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
    private int[] requiredLevels = { 1, 20, 30 };
    private int[] difficultyLevels = { 0, 8, 14 };
    private Color normalButtonColor = Color.white;
    private Color selectedButtonColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    public int DabartinisZaidejoLygis;
    public int ReikiamasZaidejoLygis;
    public TextMeshProUGUI yourLevelText;
    public Button Play;
    public static int SelectedMap = 0;
    public static int SelectedDifficulty = 0;
  
    public static bool HardcoreRezimas = false;
    public Image hardcoreButtonImage; // Reference to the Hardcore button's Image component
    
    public GameObject hearts;

    public static int GyvybiuKiekis = 3;

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
        SelectedMap = selectedMapIndex;
        SelectedDifficulty = selectedDifficultyIndex;
    }

    public void Hardcore()
    {
        if(HardcoreRezimas){
            GyvybiuKiekis = 3;
            HardcoreRezimas = false;
            hearts.SetActive(true);
            hardcoreButtonImage.color = Color.white;
        }
        else{
            GyvybiuKiekis = 1;
            HardcoreRezimas = true;
            hearts.SetActive(false);
            hardcoreButtonImage.color = selectedButtonColor;
        }
    }
}
