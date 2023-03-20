using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Greitis;


    Vector2 Vec;

    private float activeMoveSpeed;

    public Animator animator;

    void Start()
    {
        activeMoveSpeed = Greitis;
    }
    void Update()
    {
        Vec = transform.localPosition;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 inputVector = new Vector2(horizontalInput, verticalInput).normalized;

        Vec += inputVector * Time.deltaTime * activeMoveSpeed;

        transform.localPosition = Vec;

        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);
    }


}