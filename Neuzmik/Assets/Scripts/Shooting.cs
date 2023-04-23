using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject ballPrefab;
    public float ballSpeed = 10f;
    public float accuracy = 0.1f;

    public int mode = 1;

    private bool isShooting = false;
    public float rpm = 60;
    public GameObject fireEffect;

    public AudioSource soundEffect;

    private float timeSinceLastShot = 0f;
    public int bulletDamage = 1; 

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (mode == 1)
        {
            if (Input.GetButtonDown("Fire1") && timeSinceLastShot >= ((1/rpm)*60))
            {
                Shoot();
                soundEffect.Play();
                GameObject effect = Instantiate(fireEffect, transform.position, transform.rotation);
                effect.transform.parent = transform;
                timeSinceLastShot = 0f;
                Destroy(effect, 0.2f);
                timeSinceLastShot = 0f;
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

            if (isShooting && timeSinceLastShot >= ((1/rpm)*60))
            {
                Shoot();
                soundEffect.Play();
                GameObject effect = Instantiate(fireEffect, transform.position, transform.rotation);
                effect.transform.parent = transform;
                timeSinceLastShot = 0f;
                Destroy(effect, 0.2f);
            }
        }
    }
public Transform gunTipTransform;
public Transform armTransform;
   void Shoot()
{
     // Get the hand position in world space
    Vector3 handPos = armTransform.position;

    // Calculate the direction from the hand to the gun tip
    Vector3 direction = gunTipTransform.position - handPos;
    direction.z = 0f;



    // Add random deviation to direction to simulate inaccuracy
    Vector3 deviation = new Vector3(Random.Range(-accuracy, accuracy), Random.Range(-accuracy, accuracy), 0f);
    direction += deviation;

    Vector3 bulletSpawn = transform.position;
    GameObject newBall = Instantiate(ballPrefab, bulletSpawn, transform.rotation);
    Rigidbody2D bulletRb = newBall.GetComponent<Rigidbody2D>();
    bulletRb.velocity = direction.normalized * ballSpeed;

    // Set the bullet damage on the bullet prefab so that OnCollisionEnter2D() can access it
    newBall.GetComponent<Bullet>().damage = bulletDamage;

    // Destroy the bullet after a certain time to prevent it from living forever
    Destroy(newBall, 0.4f);
}
}

