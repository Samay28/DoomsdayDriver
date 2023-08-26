using UnityEngine;

public class RotateCar: MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Adjust this value to change the rotation speed.

    void Update()
    {
        // Rotate the GameObject around the Y-axis.
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
