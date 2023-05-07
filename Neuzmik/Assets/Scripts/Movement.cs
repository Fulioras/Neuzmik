using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 Vec; 

    private float activeMoveSpeed;
    private bool isColliding;

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
        Vec = transform.position;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 inputVector = new Vector2(horizontalInput, verticalInput).normalized;

        // Increase the raycast length based on the player speed
        float raycastDistance = inputVector.magnitude * Time.deltaTime * activeMoveSpeed * 1.1f;

        // Raycast to check for collision with walls
        RaycastHit2D hit = Physics2D.Raycast(transform.position, inputVector, raycastDistance, LayerMask.GetMask("Siena"));
        if (hit.collider != null)
        {
            // Wall collision, prevent player movement and set isColliding to true
            isColliding = true;
        }
        else
        {
            // No wall collision, update player position and set isColliding to false
            isColliding = false;
            Vec += inputVector * Time.deltaTime * activeMoveSpeed;
            transform.position = Vec;
        }

        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);
        animator.SetFloat("Speed", inputVector.sqrMagnitude);
    }

    void LateUpdate()
    {
        // If the player is colliding with a wall, smoothly move them back to their previous position
        if (isColliding)
        {
            transform.position = Vector2.Lerp(transform.position, Vec, 0.5f);
        }
    }
}
