using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Nustatymai config;
    public GameObject HitEffect;

        private void Start()
    {
        GameObject configObject = GameObject.FindGameObjectWithTag("Nustatymai");
        config = configObject.GetComponent<Nustatymai>();
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        Health health = collision.gameObject.GetComponent<Health>();
        GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 0.3f);
        if (health != null)
        {
            health.TakeDamage(config.bulletDamage);
        }

    }
}
