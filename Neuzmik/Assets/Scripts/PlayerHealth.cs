using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Nustatymai config;
    public static float currentPlayerHealth;
    public static int maxPlayerHealth;
    public GameObject MirtiesZenklas;
    public Animator anim;

void Start()
    {
        GameObject configObject = GameObject.FindGameObjectWithTag("Nustatymai");
        config = configObject.GetComponent<Nustatymai>();
        currentPlayerHealth = config.playerHealth;
        maxPlayerHealth = config.playerHealth;
    }
    public void TakeDamage(float damage)
    {
        EnergyBar.currentEnergy += 10;
        currentPlayerHealth -= damage;
        anim.SetBool("GotDamaged", true);
        if (currentPlayerHealth <= 0)
        {
            Die();
        }
        
    }

    private void Die()
    {
        // Do something when the object dies, such as destroying it or playing an animation
        Time.timeScale = 0f;
        MirtiesZenklas.SetActive(true);
    }
}
