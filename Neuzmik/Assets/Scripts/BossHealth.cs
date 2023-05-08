using UnityEngine;
using TMPro;

public class BossHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    private Nustatymai config;

    [SerializeField] ParticleSystem splash = null;

    private void Start()
    {
        GameObject configObject = GameObject.FindGameObjectWithTag("Nustatymai");
        config = configObject.GetComponent<Nustatymai>();
        currentHealth = config.bossHealth;
        Debug.Log(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        splash.Play();
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        XP.DabartinisZaidejoXP += 50;    
        Destroy(gameObject);
    }

}
