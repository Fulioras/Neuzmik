using UnityEngine;

public class GunToClick : MonoBehaviour
{
    public Transform gunTip;  // The tip of the gun where bullets will be spawned
    public float flipAngle = 90f;  // The angle at which to flip the gun sprite

    void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // Calculate the direction to point the gun
        Vector3 direction = (mousePos - transform.position).normalized;
        
        // Calculate the angle to rotate the gun
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the gun towards the mouse
        if (angle > flipAngle || angle < -flipAngle)
        {
            // flip the sprite upside down by rotating it 180 degrees around the X axis
            transform.rotation = Quaternion.Euler(180f, 0f, -angle);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
