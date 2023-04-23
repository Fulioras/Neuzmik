using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target;
    private Nustatymai config;

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
        // Calculate the distance between this object and the target
        float distance = Vector2.Distance(transform.position, target.position);

        // Check if the target is within the detection range
        if (distance <= config.detectionRange)
        {
            // Calculate the direction from this object to the target
            Vector2 direction = (target.position - transform.position).normalized;

            // Move this object towards the target at the specified speed
            transform.Translate(direction * config.speed * Time.deltaTime);
        }
    }
}
