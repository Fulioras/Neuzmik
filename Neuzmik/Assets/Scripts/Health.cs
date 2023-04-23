using UnityEngine;

public class Health : MonoBehaviour
{
     int currentHealth;
    private Nustatymai config;

    private void Start()
    {
        GameObject configObject = GameObject.FindGameObjectWithTag("Nustatymai");
        config = configObject.GetComponent<Nustatymai>();
        currentHealth = config.enemyHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Do something when the object dies, such as destroying it or playing an animation
        Destroy(gameObject);
    }
}
