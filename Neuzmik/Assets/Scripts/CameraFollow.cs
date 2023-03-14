using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform kaSeka;
    public Vector3 distance;

    // Update is called once per frame
    void Update()
    {
        transform.position = kaSeka.position + distance;
    }
}
