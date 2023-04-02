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

    void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        direction.z = 0f;

        Vector3 deviation = new Vector3(Random.Range(-accuracy, accuracy), Random.Range(-accuracy, accuracy), 0f);
        direction += deviation;

        Vector3 bulletSpawn = transform.position;
        GameObject newBall = Instantiate(ballPrefab, bulletSpawn, transform.rotation);
        Rigidbody2D ballRigidbody = newBall.GetComponent<Rigidbody2D>();
        ballRigidbody.velocity = direction.normalized * ballSpeed;

        // Set the bullet damage on the bullet prefab so that OnCollisionEnter2D() can access it
        newBall.GetComponent<Bullet>().damage = bulletDamage;

        Destroy(newBall, 1f);
    }

}
