using UnityEngine;

public class Attack : MonoBehaviour
{
    private Nustatymai config;
    private float lastAttackTime;

    private void Start()
    {
        GameObject configObject = GameObject.FindGameObjectWithTag("Nustatymai");
        if (configObject != null)
        {
            config = configObject.GetComponent<Nustatymai>();
        }
        else
        {
            Debug.LogError("Could not find AttackConfig object in scene.");
        }
    }

    private void Update()
    {
        if (config == null)
        {
            return;
        }

        // Check if the player is within attack range and enough time has passed since the last attack
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        float distance = Vector3.Distance(transform.position, playerPos);

        if (distance <= config.attackRange && Time.time - lastAttackTime >= config.attackSpeed)
        {
            // Deal damage to the player
            PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(config.enemyDamage);

            // Record the time of the attack
            lastAttackTime = Time.time;
        }
    }
}
