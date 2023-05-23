using UnityEngine;

public class CityBoss : MonoBehaviour
{
    public GameObject Collider;
    public GameObject PriesaiPrefab;
    private GameObject[] Priesai;
    private GameObject[] nereikalingiPriesai;
    private bool spawningPriesai;
    private float spawnInterval = 5f;
    private float spawnDuration = 15f;
    private float spawnTimer;
    public bool Bosas = false;

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

    public void Collected()
    {
                nereikalingiPriesai = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject priesai in Priesai)
        {
            priesai.SetActive(false);
        }
        Bosas = true;
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
