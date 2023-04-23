using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float detectionRange = 3f;

    private void Update()
    {
        // Calculate the distance between this object and the target
        float distance = Vector2.Distance(transform.position, target.position);

        // Check if the target is within the detection range
        if (distance <= detectionRange)
        {
            // Calculate the direction from this object to the target
            Vector2 direction = (target.position - transform.position).normalized;

            // Move this object towards the target at the specified speed
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
