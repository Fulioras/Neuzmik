using UnityEngine;
using TMPro;
using System.Collections;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject laimejimas;
    private Nustatymai config;
    public int PlayerXPGain = 0;
    public int coinDropCount = 3;
    public GameObject coinPrefab;
    public float coinSpawnRadius = 50f;
    public static int BosoMaxHealth;
    public static int BosoCurrentHealth;
    [SerializeField] ParticleSystem splash = null;
    public static int enemyWorth;
    public int PraeitasMapas = 0;

    private void Start()
    {
        
        GameObject configObject = GameObject.FindGameObjectWithTag("Nustatymai");
        
        config = configObject.GetComponent<Nustatymai>();
        
        int ZaidejoPinigai = PlayerPrefs.GetInt("PiniguUpgrade", 0);
        ZaidejoPinigai *= 5;
        if (gameObject.CompareTag("Bosas"))
        {
            currentHealth = 100000;
            maxHealth = 100000;
            BosoCurrentHealth = 100000;
            BosoMaxHealth = 100000;
        }

        if(ChooseMap.SelectedMap == 0){ // Dungeon
            if(ChooseMap.SelectedDifficulty == 0){ // Easy
                PraeitasMapas = PlayerPrefs.GetInt("00", 0);
                PlayerXPGain = 150;
                enemyWorth = 10;
                currentHealth = 20;
            }
            else if(ChooseMap.SelectedDifficulty == 1){ // Medium
            PraeitasMapas = PlayerPrefs.GetInt("01", 0);
                PlayerXPGain = 300;
                enemyWorth = 15;
                currentHealth = 30;
            }
            else if(ChooseMap.SelectedDifficulty == 2){ // Hard
            PraeitasMapas = PlayerPrefs.GetInt("02", 0);
                PlayerXPGain = 500;
                enemyWorth = 20;
                currentHealth = 50;
            }
        }
        else if(ChooseMap.SelectedMap == 1){ // City
            if(ChooseMap.SelectedDifficulty == 0){ // Easy
            PraeitasMapas = PlayerPrefs.GetInt("10", 0);
                PlayerXPGain = 850;
                enemyWorth = 30;
                currentHealth = 100;
            }
            else if(ChooseMap.SelectedDifficulty == 1){ // Medium
            PraeitasMapas = PlayerPrefs.GetInt("11", 0);
                PlayerXPGain = 1000;
                enemyWorth = 40;
                currentHealth = 160;
            }
            else if(ChooseMap.SelectedDifficulty == 2){ // Hard
            PraeitasMapas = PlayerPrefs.GetInt("12", 0);
                PlayerXPGain = 1200; 
                enemyWorth = 50;
                currentHealth = 220;
            }
        }
        else if(ChooseMap.SelectedMap == 2){ // Park
            if(ChooseMap.SelectedDifficulty == 0){ // Easy
            PraeitasMapas = PlayerPrefs.GetInt("20", 0);
                PlayerXPGain = 1400;
                enemyWorth = 75;
                currentHealth = 350;
            }
            else if(ChooseMap.SelectedDifficulty == 1){ // Medium
            PraeitasMapas = PlayerPrefs.GetInt("21", 0);
                PlayerXPGain = 1800;
                enemyWorth = 100;
                currentHealth = 400;
            }
            else if(ChooseMap.SelectedDifficulty == 2){ // Hard
            PraeitasMapas = PlayerPrefs.GetInt("22", 0);
                PlayerXPGain = 2000;
                enemyWorth = 125;
                currentHealth = 500;
            }
        }

        if(ChooseMap.HardcoreRezimas){
            PlayerXPGain *= 2;
            enemyWorth *= 2;
            currentHealth *= 2;
        }
        enemyWorth += ZaidejoPinigai;
    }

    public void TakeDamage(int damage)
    {
        if(gameObject.CompareTag("Bosas"))
        {
            BosoCurrentHealth -= damage;
        }
        currentHealth -= damage;
        splash.Play();


               if (currentHealth <= 0)
        {
            if (!gameObject.CompareTag("Bosas"))
            {
                Die();
            }
            else if (gameObject.CompareTag("Bosas"))
            {
                BossDie();
            }
        }
    }

    private void Die()
    {
        XP.DabartinisZaidejoXP += PlayerXPGain;
        for (int i = 0; i < coinDropCount; i++)
        {
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * coinSpawnRadius;
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
        Destroy(gameObject);
    }
private void BossDie()
{
    XP.DabartinisZaidejoXP += PlayerXPGain * 20;
    Money.PiniguKiekis += enemyWorth * 10;

    // Disable collider on the parent GameObject
    Collider2D collider = GetComponent<Collider2D>();
    if (collider != null)
    {
        collider.enabled = false;
    }
        foreach (Transform child in transform)
    {
        Destroy(child.gameObject);
    }

    StartCoroutine(ActivateLaimejimas());
}


        private IEnumerator ActivateLaimejimas()
    {
        if(PraeitasMapas == 0){
            PlayerPrefs.SetInt(""+ChooseMap.SelectedMap+""+ChooseMap.SelectedDifficulty, 1);
            int dabartiniaiTaskai = PlayerPrefs.GetInt("PlayerPoints", 0);
            dabartiniaiTaskai += 1;
            PlayerPrefs.SetInt("PlayerPoints", dabartiniaiTaskai);
        }
        yield return new WaitForSeconds(3.0f); // Wait for 3 seconds
        laimejimas.SetActive(true);
        Time.timeScale = 0f;
    }

}

