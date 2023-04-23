using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashSpeed = 10f; // the speed at which the object will dash
    public float dashTime = 0.5f; // the duration of the dash
    public float dashCooldown = 1f; // the cooldown time before the object can dash again
    public AnimationCurve dashCurve; // the curve controlling the acceleration and deceleration of the dash
    public KeyCode dashKey = KeyCode.LeftShift; // the key used to initiate the dash

    private Rigidbody2D rb;
    private float dashTimer;
    private bool isDashing;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTimer = dashCooldown;
    }

    private void Update()
{
    if (Input.GetKeyDown(dashKey) && dashTimer >= dashCooldown)
    {
        isDashing = true;
        dashTimer = 0f;
    }

    if (isDashing)
    {
        float t = dashTimer / dashTime;
        float curveValue = dashCurve.Evaluate(t);

        // Check if the "W" key is held down
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.up * dashSpeed * curveValue;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * dashSpeed * curveValue;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * dashSpeed * curveValue;
        }
        else
        {
            rb.velocity = -transform.up * dashSpeed * curveValue;
        }

        dashTimer += Time.deltaTime;

        if (dashTimer >= dashTime)
        {
            isDashing = false;
            rb.velocity = Vector2.zero;
        }
    }
    else
    {
        dashTimer = Mathf.Min(dashTimer + Time.deltaTime, dashCooldown);
    }
}
}