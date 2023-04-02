using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public GameObject HitEffect;
    void OnCollisionEnter2D(Collision2D collision) 
    {
        Health health = collision.gameObject.GetComponent<Health>();
        GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 0.3f);
        if (health != null)
        {
            health.TakeDamage(damage);
        }

    }
}
