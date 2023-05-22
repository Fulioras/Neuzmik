using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ChooseWeapon : MonoBehaviour
{
    public Image mapImage;
    public TextMeshProUGUI CostText;
    public Button[] ginkluMygtukai;
    public static int pasirinktasGinklas = 0;
    private string[] GinkluPavadinimai = { "Slingshot", "Toy Gun", "Deagle", "AK-47", "AWP", "G36C" };
    private Sprite[] GinkluNuotraukos;
    private int[] GinkluKainos = { 100, 500, 1500, 3500, 10000, 18000 };
    public int DabartinisZaidejoBalansas;
    public int GinkloKaina;
    public TextMeshProUGUI TavoBalansas;
    public Button Play;

    private Color normalButtonColor = Color.white;
    private Color selectedButtonColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);

    private void Start()
    {
        DabartinisZaidejoBalansas = PlayerPrefs.GetInt("ZaidejoBalansas", 0);
        TavoBalansas.text = "Balance: " + DabartinisZaidejoBalansas;

        GinkluNuotraukos = new Sprite[GinkluPavadinimai.Length];
        for (int i = 0; i < GinkluPavadinimai.Length; i++)
        {
            string spritePath = "Sprites/" + GinkluPavadinimai[i];
            GinkluNuotraukos[i] = Resources.Load<Sprite>(spritePath);
        }

        SelectMap(0);
        UpdateMap();
    }

    private void Update()
    {
        if (DabartinisZaidejoBalansas < GinkloKaina)
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
        if (mapIndex >= 0 && mapIndex < GinkluPavadinimai.Length)
        {
            ResetButtonColors();

            pasirinktasGinklas = mapIndex;
            UpdateMap();

            ginkluMygtukai[pasirinktasGinklas].image.color = selectedButtonColor;
        }
    }

    private void ResetButtonColors()
    {
        foreach (Button button in ginkluMygtukai)
        {
            button.image.color = normalButtonColor;
        }
    }

    private void UpdateMap()
    {
        mapImage.sprite = GinkluNuotraukos[pasirinktasGinklas];
        int modifiedRequiredLevel = GinkluKainos[pasirinktasGinklas];
        GinkloKaina = modifiedRequiredLevel;
        CostText.text = "Cost: " + modifiedRequiredLevel.ToString();
    }
}
