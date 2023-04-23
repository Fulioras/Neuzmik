using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Nustatymai config;
    public static int currentPlayerHealth;
    public static int maxPlayerHealth;
    public GameObject MirtiesZenklas;


    void Start()
    {
        GameObject configObject = GameObject.FindGameObjectWithTag("Nustatymai");
        config = configObject.GetComponent<Nustatymai>();
        currentPlayerHealth = config.playerHealth;
        maxPlayerHealth = config.playerHealth;
    }
    public void TakeDamage(int damage)
    {
        currentPlayerHealth -= damage;

        if (currentPlayerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Do something when the object dies, such as destroying it or playing an animation
        Destroy(gameObject);
        MirtiesZenklas.SetActive(true);
    }
}
