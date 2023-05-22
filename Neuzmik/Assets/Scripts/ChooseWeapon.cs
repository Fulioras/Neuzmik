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
    public Button Pirkti;
    public TextMeshProUGUI PirkimoMygtukoTekstas;

    private Color normalButtonColor = Color.white;
    private Color selectedButtonColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    public static int SlingshotData; // (0 - nenupirktas, 1 - nupirktas)
    public static int ToyGunData; // (0 - nenupirktas, 1 - nupirktas)
    public static int DeagleData; // (0 - nenupirktas, 1 - nupirktas)
    public static int AK47Data; // (0 - nenupirktas, 1 - nupirktas)
    public static int AWPData; // (0 - nenupirktas, 1 - nupirktas)
    public static int G36CData; // (0 - nenupirktas, 1 - nupirktas)
    public static int EquippedWeapon;

    private void Start()
    {
        DabartinisZaidejoBalansas = PlayerPrefs.GetInt("ZaidejoPinigai", 0);
        EquippedWeapon = PlayerPrefs.GetInt("Equipped", -1);

        TavoBalansas.text = "Balance: " + DabartinisZaidejoBalansas;

        GinkluNuotraukos = new Sprite[GinkluPavadinimai.Length];
        for (int i = 0; i < GinkluPavadinimai.Length; i++)
        {
            string spritePath = "Sprites/" + GinkluPavadinimai[i];
            GinkluNuotraukos[i] = Resources.Load<Sprite>(spritePath);
        }

        if(EquippedWeapon > -1){
            SelectMap(EquippedWeapon);
            UpdateMap();
            CostText.text = "";
        }
        else{
        SelectMap(0);
        UpdateMap();
        }
    }

    private void Update()
    {
    
        SlingshotData = PlayerPrefs.GetInt("Slingshot", 0);
        ToyGunData = PlayerPrefs.GetInt("Toy Gun", 0);
        DeagleData = PlayerPrefs.GetInt("Deagle", 0);
        AK47Data = PlayerPrefs.GetInt("AK-47", 0);
        AWPData = PlayerPrefs.GetInt("AWP", 0);
        G36CData = PlayerPrefs.GetInt("G36C", 0);
        if(SlingshotData == 0){
            ginkluMygtukai[0].GetComponent<Image>().color = Color.red;
        }
        else{
            ginkluMygtukai[0].GetComponent<Image>().color = Color.green;
        }
        if(ToyGunData == 0){
            ginkluMygtukai[1].GetComponent<Image>().color = Color.red;
        }
        else{
            ginkluMygtukai[1].GetComponent<Image>().color = Color.green;
        }
        if(DeagleData == 0){
            ginkluMygtukai[2].GetComponent<Image>().color = Color.red;
        }
        else{
            ginkluMygtukai[2].GetComponent<Image>().color = Color.green;
        }
        if(AK47Data == 0){
            ginkluMygtukai[3].GetComponent<Image>().color = Color.red;
        }
        else{
            ginkluMygtukai[3].GetComponent<Image>().color = Color.green;
        }
        if(AWPData == 0){
            ginkluMygtukai[4].GetComponent<Image>().color = Color.red;
        }
        else{
            ginkluMygtukai[4].GetComponent<Image>().color = Color.green;
        }
         if(G36CData == 0){
            ginkluMygtukai[5].GetComponent<Image>().color = Color.red;
        }
        else{
            ginkluMygtukai[5].GetComponent<Image>().color = Color.green;
        }

        if (ginkluMygtukai[pasirinktasGinklas].GetComponent<Image>().color == Color.green && EquippedWeapon != pasirinktasGinklas)
            {
                Pirkti.GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
                Pirkti.GetComponent<Image>().color = Color.green;
                Pirkti.interactable = true;
            }
            else if (ginkluMygtukai[pasirinktasGinklas].GetComponent<Image>().color == Color.green && EquippedWeapon == pasirinktasGinklas)
            {
                Pirkti.GetComponentInChildren<TextMeshProUGUI>().text = "Equipped";
                Pirkti.GetComponent<Image>().color = Color.green;
                Pirkti.interactable = false;
            }
        else if (DabartinisZaidejoBalansas < GinkluKainos[pasirinktasGinklas])
        {
            Pirkti.interactable = false;
            PirkimoMygtukoTekstas.text = "Not Enough Money";
            Pirkti.GetComponent<Image>().color = Color.red;
        }
        else
        {
            Pirkti.interactable = true;
            PirkimoMygtukoTekstas.text = "Buy";
            Pirkti.GetComponent<Image>().color = Color.green;
        }

    }

    public void SelectMap(int mapIndex)
    {
        if (mapIndex >= 0 && mapIndex < GinkluPavadinimai.Length)
        {
            pasirinktasGinklas = mapIndex;
            UpdateMap();
        }
    }
    public void PirktiGinkla(){
        if (ginkluMygtukai[pasirinktasGinklas].GetComponent<Image>().color == Color.green && EquippedWeapon != pasirinktasGinklas)
        {
            EquippedWeapon = pasirinktasGinklas;
            PirkimoMygtukoTekstas.text = "Equipped";
        }
        else if(ginkluMygtukai[pasirinktasGinklas].GetComponent<Image>().color != Color.green){
            
                    DabartinisZaidejoBalansas = DabartinisZaidejoBalansas - GinkluKainos[pasirinktasGinklas];
                    TavoBalansas.text = "Balance: " + DabartinisZaidejoBalansas;
                    PlayerPrefs.SetInt(""+GinkluPavadinimai[pasirinktasGinklas], 1);
        }
    }

    private void UpdateMap()
    {
        mapImage.sprite = GinkluNuotraukos[pasirinktasGinklas];
        int modifiedRequiredLevel = GinkluKainos[pasirinktasGinklas];
        GinkloKaina = modifiedRequiredLevel;
        if(ginkluMygtukai[pasirinktasGinklas].GetComponent<Image>().color != Color.green){
            CostText.text = "Cost: " + modifiedRequiredLevel.ToString();
        }
        else{
            CostText.text = "";
        }
        
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("ZaidejoPinigai", DabartinisZaidejoBalansas);
        PlayerPrefs.SetInt("Equipped", EquippedWeapon);
    }
}
