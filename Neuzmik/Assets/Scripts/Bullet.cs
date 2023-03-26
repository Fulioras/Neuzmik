using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject HitEffect;
    void OnCollisionEnter2D(Collision2D collision) 
    {
        GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 0.3f);
    }
    
}
