using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damageAmount = 10;
    public float attackRange = 1.5f;
    public float attackSpeed = 1.5f;

    private float lastAttackTime;

    private void Update()
    {
        // Check if the player is within attack range and enough time has passed since the last attack
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        float distance = Vector3.Distance(transform.position, playerPos);

        if (distance <= attackRange && Time.time - lastAttackTime >= attackSpeed)
        {
            // Deal damage to the player
            PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageAmount);

            // Record the time of the attack
            lastAttackTime = Time.time;
        }
    }
}

