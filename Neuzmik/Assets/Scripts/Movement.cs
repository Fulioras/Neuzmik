using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 Vec; 

    private float activeMoveSpeed;

    public Animator animator;
    private Nustatymai config;

    void Start()
    {
        GameObject configObject = GameObject.FindGameObjectWithTag("Nustatymai");
        config = configObject.GetComponent<Nustatymai>();
        activeMoveSpeed = config.greitis;
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
        animator.SetFloat("Speed", inputVector.sqrMagnitude);

    }


}