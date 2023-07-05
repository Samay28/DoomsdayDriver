using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotate the wheel around its local Y-axis
        transform.Rotate(rotationSpeed * Time.deltaTime, 0f , 0f);
    }
}
