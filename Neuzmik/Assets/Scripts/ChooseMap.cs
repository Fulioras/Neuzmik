using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseMap : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject[] whiteObjects;
    public int[] levels;
    public GameObject[] MapPicture;
    public TextMeshProUGUI levelText;
    public static int MapoID = 0;

    private int selectedButtonIndex = -1;

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Needed to capture the current value of i for the lambda expression below
            buttons[i].GetComponent<Button>().onClick.AddListener(() => OnButtonClicked(index));
        }
    }

    private void OnButtonClicked(int index)
    {
        // If the clicked button is already selected, do nothing
        if (selectedButtonIndex == index)
        {
            return;
        }

        // Deselect the previously selected button (if there was one)
        if (selectedButtonIndex != -1)
        {
            whiteObjects[selectedButtonIndex].GetComponent<RawImage>().color = Color.white;
            MapPicture[selectedButtonIndex].SetActive(false);
        }

        // Select the clicked button
        selectedButtonIndex = index;
        MapoID = selectedButtonIndex;
        whiteObjects[selectedButtonIndex].GetComponent<RawImage>().color = Color.red;
         MapPicture[selectedButtonIndex].SetActive(true);

        // Update the level text to display the level value of the selected button
        int level = levels[selectedButtonIndex];
        levelText.text = "Privalomas lygis: " + level.ToString();
    }
}

