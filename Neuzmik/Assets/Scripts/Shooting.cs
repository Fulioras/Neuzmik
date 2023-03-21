using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject ballPrefab;   // The prefab for the ball
    public float ballSpeed = 10f;   // The speed at which the ball travels

    public int mode = 1;   // The firing mode: 1 for tap firing, 2 for continuous firing

    private bool isShooting = false;   // Whether the player is currently shooting

    // Update is called once per frame
    void Update()
    {
        if (mode == 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else if (mode == 2)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                isShooting = true;
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                isShooting = false;
            }

            if (isShooting)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        // Get the position of the mouse in world coordinates
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the player to the mouse position
        Vector3 direction = mousePos - transform.position;
        direction.z = 0f;   // Make sure the direction is in the 2D plane

        Vector3 bulletSpawn = transform.position;
        // Create a new ball instance and set its position and velocity
        GameObject newBall = Instantiate(ballPrefab, bulletSpawn, Quaternion.identity);
        Rigidbody2D ballRigidbody = newBall.GetComponent<Rigidbody2D>();
        ballRigidbody.velocity = direction.normalized * ballSpeed;
    }
}
