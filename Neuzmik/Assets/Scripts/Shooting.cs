using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject ballPrefab;
    private bool isShooting = false;
    public GameObject fireEffect;
    public AudioSource soundEffect;
    private float timeSinceLastShot = 0.0f;
    private Nustatymai config;

    public Transform[] gunTipTransforms; // Array of gun tip transforms
    public Transform armTransform;
    public int Ginklas;
    public Sprite[] ginkluModeliai;
    public GameObject GinkloRenderer;

    private void Start()
    {
        Ginklas = PlayerPrefs.GetInt("Equipped", 0);
        GinkloRenderer.GetComponent<SpriteRenderer>().sprite = ginkluModeliai[Ginklas];
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

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (!EscapeMenu.inEscape)
        {
            if (config.firingMode == 1)
            {
                if (Input.GetButtonDown("Fire1") && timeSinceLastShot >= (60.0f / config.rpm))
                {
                    Shoot();
                    soundEffect.Play();
                    GameObject effect = Instantiate(fireEffect, gunTipTransforms[Ginklas].position, gunTipTransforms[Ginklas].rotation);

                    effect.transform.parent = transform;
                    Destroy(effect, 0.2f);
                    timeSinceLastShot = 0.0f;
                }
            }
            else if (config.firingMode == 2)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    isShooting = true;
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    isShooting = false;
                }

                if (isShooting && timeSinceLastShot >= (60.0f / config.rpm))
                {
                    Shoot();
                    soundEffect.Play();
                    GameObject effect = Instantiate(fireEffect, gunTipTransforms[Ginklas].position, gunTipTransforms[Ginklas].rotation);
                    effect.transform.parent = transform;
                    Destroy(effect, 0.2f);
                    timeSinceLastShot = 0.0f;
                }
            }
        }
    }

    void Shoot()
    {
        // Get the hand position in world space
        Vector3 handPos = armTransform.position;

        // Get the index of the equipped gun
        int equippedGunIndex = Mathf.Clamp(Ginklas, 0, gunTipTransforms.Length - 1);

        // Get the gun tip transform based on the equipped gun
        Transform gunTipTransform = gunTipTransforms[equippedGunIndex];

        // Calculate the direction from the hand to the gun tip
        Vector3 direction = gunTipTransform.position - handPos;
        direction.z = 0.0f;

        // Add random deviation to direction to simulate inaccuracy
        Vector3 deviation = new Vector3(Random.Range(-config.accuracy, config.accuracy), Random.Range(-config.accuracy, config.accuracy), 0.0f);
        direction += deviation;

        Vector3 bulletSpawn = transform.position;
        GameObject newBall = Instantiate(ballPrefab, bulletSpawn, transform.rotation);
        Rigidbody2D bulletRb = newBall.GetComponent<Rigidbody2D>();
        bulletRb.velocity = direction.normalized * config.ballSpeed;

        // Destroy the bullet after a certain time to prevent it from living forever
        Destroy(newBall, 0.4f);
    }
}
