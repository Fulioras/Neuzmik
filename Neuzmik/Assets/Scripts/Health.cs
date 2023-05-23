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

    [SerializeField] ParticleSystem splash = null;

    private void Start()
    {
        GameObject configObject = GameObject.FindGameObjectWithTag("Nustatymai");
        config = configObject.GetComponent<Nustatymai>();
        currentHealth = config.enemyHealth;

        if (gameObject.CompareTag("Bosas"))
        {
            currentHealth = 350;
            maxHealth = 350;
        }

        if(ChooseMap.SelectedMap == 0){ // Dungeon
            if(ChooseMap.SelectedDifficulty == 0){ // Easy
                PlayerXPGain = 150;
            }
            else if(ChooseMap.SelectedDifficulty == 1){ // Medium
                PlayerXPGain = 300;
            }
            else if(ChooseMap.SelectedDifficulty == 2){ // Hard
                PlayerXPGain = 500;     
            }
        }
        else if(ChooseMap.SelectedMap == 1){ // City
            if(ChooseMap.SelectedDifficulty == 0){ // Easy
                PlayerXPGain = 850;
            }
            else if(ChooseMap.SelectedDifficulty == 1){ // Medium
                PlayerXPGain = 1000;
            }
            else if(ChooseMap.SelectedDifficulty == 2){ // Hard
                PlayerXPGain = 1200; 
            }
        }
        else if(ChooseMap.SelectedMap == 2){ // Park
            if(ChooseMap.SelectedDifficulty == 0){ // Easy
                PlayerXPGain = 1400;
            }
            else if(ChooseMap.SelectedDifficulty == 1){ // Medium
                PlayerXPGain = 1800;
            }
            else if(ChooseMap.SelectedDifficulty == 2){ // Hard
                PlayerXPGain = 2000;
            }
        }

        if(ChooseMap.HardcoreRezimas){
            PlayerXPGain *= 2;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        splash.Play();
        Debug.Log(currentHealth);

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
    for (int i = 0; i < coinDropCount * 20; i++)
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * coinSpawnRadius;
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }

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
        yield return new WaitForSeconds(3.0f); // Wait for 3 seconds
        laimejimas.SetActive(true);
        Time.timeScale = 0f;
    }

}

