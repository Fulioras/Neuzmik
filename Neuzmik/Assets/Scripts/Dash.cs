using UnityEngine;

public class Dash : MonoBehaviour
{
    public AnimationCurve dashCurve; // the curve controlling the acceleration and deceleration of the dash
    public KeyCode dashKey = KeyCode.LeftShift; // the key used to initiate the dash
    private Rigidbody2D rb;
    private float dashTimer;
    private bool isDashing;
    private Nustatymai config;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject configObject = GameObject.FindGameObjectWithTag("Nustatymai");
        if (configObject != null)
        {
            config = configObject.GetComponent<Nustatymai>();
        }
        else
        {
            Debug.LogError("Could not find AttackConfig object in scene.");
        }
        dashTimer = config.dashCooldown;
    }

    private void Update()
{
    if (Input.GetKeyDown(dashKey) && dashTimer >= config.dashCooldown)
    {
        isDashing = true;
        dashTimer = 0f;
    }

    if (isDashing)
    {
        float t = dashTimer / config.dashTime;
        float curveValue = dashCurve.Evaluate(t);

        // Check if the "W" key is held down
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.up * config.dashSpeed * curveValue;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * config.dashSpeed * curveValue;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * config.dashSpeed * curveValue;
        }
        else
        {
            rb.velocity = -transform.up * config.dashSpeed * curveValue;
        }

        dashTimer += Time.deltaTime;

        if (dashTimer >= config.dashTime)
        {
            isDashing = false;
            rb.velocity = Vector2.zero;
        }
    }
    else
    {
        dashTimer = Mathf.Min(dashTimer + Time.deltaTime, config.dashCooldown);
    }
}
}