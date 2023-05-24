using UnityEngine;
using System.Collections;

public class CityBoss : MonoBehaviour
{
    public GameObject Collider;
    public GameObject PriesaiPrefab;
    private GameObject[] Priesai;
    private GameObject[] nereikalingiPriesai;
    private GameObject[] nereikalingiPriesai2;
    private GameObject[] nereikalingiPriesai3;
    private bool spawningPriesai;
    private float spawnInterval = 5f;
    private float spawnDuration = 15f;
    private float spawnTimer;
    public static bool Bosas = false;
    public GameObject[] remainingEnemies;
    public GameObject laimejimas;
    public bool conditionMet = false;

    private void Start()
    {
        Bosas = false;
        // Disable the collider
        Collider.SetActive(false);

        // Find all Priesai game objects in the scene
        Priesai = GameObject.FindGameObjectsWithTag("Final");


        // Disable all Priesai game objects
        foreach (GameObject priesai in Priesai)
        {
            priesai.SetActive(false);
        }
    }
    private void Update()
    {
        remainingEnemies = GameObject.FindGameObjectsWithTag("Final");
            if (remainingEnemies.Length == 0 && CityBoss.Bosas)
    {
        if (!conditionMet)
        {
            StartCoroutine(CheckCondition());
        }
    }
    else
    {
        conditionMet = false;
    }
    }
            IEnumerator CheckCondition()
{
    yield return new WaitForSeconds(3f);

     if (remainingEnemies.Length == 0 && CityBoss.Bosas)
    {
        // The condition has been true for 3 seconds, so activate the action here
        StartCoroutine(ActivateLaimejimas());
    }
    else
    {
        conditionMet = false; // Reset the condition if it's no longer true
    }
}
            private IEnumerator ActivateLaimejimas()
    {
        yield return new WaitForSeconds(2.0f); // Wait for 3 seconds
        laimejimas.SetActive(true);
        Time.timeScale = 0f;
    }
 public void Collected()
{
    // Check if the collectible has already been collected
    if (!Bosas)
    {
        nereikalingiPriesai = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject priesai in nereikalingiPriesai)
        {
            Destroy(priesai);
        }

        nereikalingiPriesai2 = GameObject.FindGameObjectsWithTag("bigEnemy");
        foreach (GameObject priesai in nereikalingiPriesai2)
        {
            Destroy(priesai);
        }

        nereikalingiPriesai3 = GameObject.FindGameObjectsWithTag("FastEnemy");
        foreach (GameObject priesai in nereikalingiPriesai3)
        {
            Destroy(priesai);
        }

        Bosas = true;
        Invoke("SpawnFirstWave", 2f);
    }
}

private void SpawnFirstWave()
{
    SpawnPriesaiPrefab();
    Collider.SetActive(true);
    spawningPriesai = true;
    spawnTimer = 0f;
    InvokeRepeating("SpawnPriesaiPrefab", spawnInterval, spawnInterval);
    Invoke("StopSpawningPriesai", spawnDuration);
}



    private void SpawnPriesaiPrefab()
    {
        // Instantiate and enable the Priesai prefab at the default positions
        foreach (GameObject priesai in Priesai)
        {
            GameObject spawnedPriesai = Instantiate(PriesaiPrefab, priesai.transform.position, priesai.transform.rotation);
spawnedPriesai.tag = "Final";
            spawnedPriesai.SetActive(true);
        }
    }

    private void StopSpawningPriesai()
    {
        spawningPriesai = false;
        CancelInvoke("SpawnPriesaiPrefab");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object is colliding with the player
        if (collision.CompareTag("Player"))
        {
            // Call the Collected function
            Collected();
        }
    }
}
