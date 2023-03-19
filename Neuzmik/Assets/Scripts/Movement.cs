using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Greitis;


    Vector2 Vec;
    public KeyCode dash;

    private float activeMoveSpeed;

    public Animator animator;

    void Start()
    {
        activeMoveSpeed = Greitis;
    }
    void Update()
    {
        Vec = transform.localPosition;
        Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * Greitis;
        Vec.y += Input.GetAxis("Vertical") * Time.deltaTime * Greitis;
        transform.localPosition = Vec;

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        //animator.SetFloat("Speed", Input.GetAxis("Horizontal")* Input.GetAxis("Vertical"));

    }
 
}