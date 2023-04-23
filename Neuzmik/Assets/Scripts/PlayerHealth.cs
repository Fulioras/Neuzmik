using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int maxPlayerHealth = 100;
    public static int currentPlayerHealth = 100;
    public GameObject MirtiesZenklas;
    public Animator anim;

    public void TakeDamage(int damage)
    {
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
        Destroy(gameObject);
        MirtiesZenklas.SetActive(true);
        currentPlayerHealth = maxPlayerHealth;
    }
}
