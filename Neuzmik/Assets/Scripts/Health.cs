using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject laimejimas;
    private Nustatymai config;
    public TextMeshProUGUI priesuLiko;

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
        XP.DabartinisZaidejoXP += 5;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemies.Length);
        if(enemies.Length <= 11){
        priesuLiko.text = "Liko priešų: " + (enemies.Length-1);
        }
        if (enemies.Length == 1)
        {
            Boss.Bosas = true;
        }
        
        Destroy(gameObject);
    }

}
