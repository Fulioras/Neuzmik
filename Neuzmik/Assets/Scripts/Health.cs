using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject laimejimas;

    private void Start()
    {
        currentHealth = maxHealth;
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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemies.Length);
        if (enemies.Length == 1)
        {
            NoMoreEnemies();
        }
        // Do something when the object dies, such as destroying it or playing an animation
        Destroy(gameObject);
        
        
    }
    public void NoMoreEnemies()
    {
            laimejimas.SetActive(true);
        Debug.Log("Veikia");
    }

}
