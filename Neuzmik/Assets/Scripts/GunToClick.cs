using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunToClick : MonoBehaviour
{
// set the threshold angle at which the sprite should be flipped
public float flipAngle = 90f; 
void Update()
{
    // get the current mouse position in world space
    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    // calculate the direction to the mouse position
    Vector2 direction = mousePosition - (Vector2)transform.position;

    // calculate the angle to rotate towards the mouse position
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    // create a rotation to rotate towards the mouse position
    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    // check if the current angle is greater than the flipAngle or less than -flipAngle
    if (angle > flipAngle || angle < -flipAngle)
    {
        // flip the sprite upside down by rotating it 180 degrees around the X axis
        transform.rotation = Quaternion.Euler(180f, 0f, -angle);
    }
    else
    {
        // apply the rotation to the transform
        transform.rotation = rotation;
    }
}
}