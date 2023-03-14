using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int Greitis;
    Vector3 Vec;
    public KeyCode dash;
    void Start()
    {

    }

    void Update()
    {
        Vec = transform.localPosition;
        Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * Greitis;
        Vec.y += Input.GetAxis("Vertical") * Time.deltaTime * Greitis;
        transform.localPosition = Vec;
        if (Input.GetKeyDown(dash))
        {
            Vec.x += Input.GetAxis("Horizontal") * 100f;
            Vec.y += Input.GetAxis("Vertical") * 100f;
            Debug.Log("Bam!");
        }
    }
}