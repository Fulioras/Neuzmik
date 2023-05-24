using UnityEngine;

public class Coin : MonoBehaviour
{
    public float followDistance = 100f;
    public float despawnDistance = 1f;

    private Transform player;

    private const float moveSpeed = 100f;

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
            Debug.Log(distance);
            if (distance > followDistance)
            {
                return;
            }

            if (distance <= despawnDistance)
            {
                // Despawn the coin orb
                Destroy(gameObject);
                Money.PiniguKiekis += 10;
            }
            else
            {
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
            }
        }
    }
}

