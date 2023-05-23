using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ChooseWeapon : MonoBehaviour
{
    public Image mapImage;
    public Button[] ginkluMygtukai;
    public static int pasirinktasGinklas = 0;
    private string[] GinkluPavadinimai = { "Slingshot", "Toy Gun", "Deagle", "AK-47", "AWP", "G36C" };
    private Sprite[] GinkluNuotraukos;
    private int[] GinkluKainos = { 100, 500, 1500, 3500, 10000, 18000 };
    public int DabartinisZaidejoBalansas;
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
    int modifiedRequiredLevel;
    public TextMeshProUGUI FireRate;
    public TextMeshProUGUI FireMode;
    public TextMeshProUGUI BulletSpeed;
    public TextMeshProUGUI Damage;
    public TextMeshProUGUI Accuracy;
    public TextMeshProUGUI Weight;
    Color nenupirktasMygtukas = new Color(1f, 1f, 1f, 0.5f);
    Color nupirktasMygtukas = Color.white;
    private void Start()
    {
        
        DabartinisZaidejoBalansas = PlayerPrefs.GetInt("ZaidejoPinigai", 0);
        DabartinisZaidejoBalansas += 15000;
        EquippedWeapon = PlayerPrefs.GetInt("Equipped", 0);

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
        }
        else{
        SelectMap(0);
        UpdateMap();
        UpdateStats();
        }
    }
    private void UpdateStats()
    {
        if(pasirinktasGinklas == 0){
            FireRate.text = "Fire Rate: 50 rpm";
            FireMode.text = "Fire Mode: Single";
            BulletSpeed.text = "Bullet Speed: 100 m/s";
            Damage.text = "Damage: 20";
            Accuracy.text = "Accuracy: 60%";
            Weight.text = "Weight: Light";
        }
        else if(pasirinktasGinklas == 1){
            FireRate.text = "Fire Rate: 600 rpm";
            FireMode.text = "Fire Mode: Auto";
            BulletSpeed.text = "Bullet Speed: 80 m/s";
            Damage.text = "Damage: 5";
            Accuracy.text = "Accuracy: 60%";
            Weight.text = "Weight: Light";
        }
        else if(pasirinktasGinklas == 2){
            FireRate.text = "Fire Rate: 200 rpm";
            FireMode.text = "Fire Mode: Single";
            BulletSpeed.text = "Bullet Speed: 150 m/s";
            Damage.text = "Damage: 40";
            Accuracy.text = "Accuracy: 80%";
            Weight.text = "Weight: Light";
        }
        else if(pasirinktasGinklas == 3){
            FireRate.text = "Fire Rate: 400 rpm";
            FireMode.text = "Fire Mode: Auto";
            BulletSpeed.text = "Bullet Speed: 120 m/s";
            Damage.text = "Damage: 30";
            Accuracy.text = "Accuracy: 70%";
            Weight.text = "Weight: Heavy";    
        }
        else if(pasirinktasGinklas == 4){
            FireRate.text = "Fire Rate: 60 rpm";
            FireMode.text = "Fire Mode: Single";
            BulletSpeed.text = "Bullet Speed: 200 m/s";
            Damage.text = "Damage: 150";
            Accuracy.text = "Accuracy: 100%";
            Weight.text = "Weight: Heavy"; 
        }
        else if(pasirinktasGinklas == 5){
            FireRate.text = "Fire Rate: 600 rpm";
            FireMode.text = "Fire Mode: Auto";
            BulletSpeed.text = "Bullet Speed: 150 m/s";
            Damage.text = "Damage: 30";
            Accuracy.text = "Accuracy: 85%";
            Weight.text = "Weight: Heavy";
        }
    }
    private void Update()
    {
    
        SlingshotData = PlayerPrefs.GetInt("Slingshot", 1);
        ToyGunData = PlayerPrefs.GetInt("Toy Gun", 0);
        DeagleData = PlayerPrefs.GetInt("Deagle", 0);
        AK47Data = PlayerPrefs.GetInt("AK-47", 0);
        AWPData = PlayerPrefs.GetInt("AWP", 0);
        G36CData = PlayerPrefs.GetInt("G36C", 0);
        if(SlingshotData == 0){
            ginkluMygtukai[0].GetComponent<Image>().color = nenupirktasMygtukas;
        }
        else{
            ginkluMygtukai[0].GetComponent<Image>().color = nupirktasMygtukas;
        }
        if(ToyGunData == 0){
            ginkluMygtukai[1].GetComponent<Image>().color = nenupirktasMygtukas;
        }
        else{
            ginkluMygtukai[1].GetComponent<Image>().color = nupirktasMygtukas;
        }
        if(DeagleData == 0){
            ginkluMygtukai[2].GetComponent<Image>().color = nenupirktasMygtukas;
        }
        else{
            ginkluMygtukai[2].GetComponent<Image>().color = nupirktasMygtukas;
        }
        if(AK47Data == 0){
            ginkluMygtukai[3].GetComponent<Image>().color = nenupirktasMygtukas;
        }
        else{
            ginkluMygtukai[3].GetComponent<Image>().color = nupirktasMygtukas;
        }
        if(AWPData == 0){
            ginkluMygtukai[4].GetComponent<Image>().color = nenupirktasMygtukas;
        }
        else{
            ginkluMygtukai[4].GetComponent<Image>().color = nupirktasMygtukas;
        }
         if(G36CData == 0){
            ginkluMygtukai[5].GetComponent<Image>().color = nenupirktasMygtukas;
        }
        else{
            ginkluMygtukai[5].GetComponent<Image>().color = nupirktasMygtukas;
        }

        if (ginkluMygtukai[pasirinktasGinklas].GetComponent<Image>().color == nupirktasMygtukas && EquippedWeapon != pasirinktasGinklas)
            {
                Pirkti.GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
                Pirkti.GetComponent<Image>().color = nupirktasMygtukas;
                Pirkti.interactable = true;
            }
            else if (ginkluMygtukai[pasirinktasGinklas].GetComponent<Image>().color == nupirktasMygtukas && EquippedWeapon == pasirinktasGinklas)
            {
                Pirkti.GetComponentInChildren<TextMeshProUGUI>().text = "Equipped";
                Pirkti.GetComponent<Image>().color = nenupirktasMygtukas;
                Pirkti.interactable = false;
            }
        else if (DabartinisZaidejoBalansas < GinkluKainos[pasirinktasGinklas])
        {
            Pirkti.interactable = false;
            PirkimoMygtukoTekstas.text = "($" + modifiedRequiredLevel + ")";
            Pirkti.GetComponent<Image>().color = nenupirktasMygtukas;
        }
        else
        {
            Pirkti.interactable = true;
            PirkimoMygtukoTekstas.text = "($" + modifiedRequiredLevel + ")";
            Pirkti.GetComponent<Image>().color = nupirktasMygtukas;
        }

    }

    public void SelectMap(int mapIndex)
    {
        if (mapIndex >= 0 && mapIndex < GinkluPavadinimai.Length)
        {
            pasirinktasGinklas = mapIndex;
            UpdateMap();
        }
        UpdateStats();
    }
    public void PirktiGinkla(){
        if (ginkluMygtukai[pasirinktasGinklas].GetComponent<Image>().color == nupirktasMygtukas && EquippedWeapon != pasirinktasGinklas)
        {
            EquippedWeapon = pasirinktasGinklas;
            PirkimoMygtukoTekstas.text = "Equipped";
        }
        else if(ginkluMygtukai[pasirinktasGinklas].GetComponent<Image>().color != nupirktasMygtukas){
            
                    DabartinisZaidejoBalansas = DabartinisZaidejoBalansas - GinkluKainos[pasirinktasGinklas];
                    TavoBalansas.text = "Balance: " + DabartinisZaidejoBalansas;
                    PlayerPrefs.SetInt(""+GinkluPavadinimai[pasirinktasGinklas], 1);
        }
    }

    private void UpdateMap()
    {
        mapImage.sprite = GinkluNuotraukos[pasirinktasGinklas];
        modifiedRequiredLevel = GinkluKainos[pasirinktasGinklas];
        UpdateStats();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("ZaidejoPinigai", DabartinisZaidejoBalansas);
        PlayerPrefs.SetInt("Equipped", EquippedWeapon);
    }
}
