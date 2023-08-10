using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryCan : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Adjust this value to control the rotation speed

    void Update()
    {
        // Rotate the object around the Z-axis continuously
        transform.Rotate(0.0f, 0.0f, rotationSpeed * Time.deltaTime);
    }
}
