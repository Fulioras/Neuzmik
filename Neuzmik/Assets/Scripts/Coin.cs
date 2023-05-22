using UnityEngine;

public class Coin : MonoBehaviour
{
    public float moveSpeed = 500f;
    public float followDistance = 100f;
    public float despawnDistance = 1f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            float distance = direction.magnitude;

            if (distance > followDistance)
            {
                // Coin is too far from the player, do not follow
                return;
            }

            if (distance <= despawnDistance)
            {
                // Despawn the coin orb
                Destroy(gameObject);
            }
            else
            {
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
            }
        }
    }
}
