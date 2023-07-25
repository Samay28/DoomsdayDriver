using UnityEngine;

public class ScreenShaking : MonoBehaviour
{
    // Intensity of the shake effect.
    public float shakeIntensity = 0.1f;

    // Duration of the shake effect.
    public float shakeDuration = 0.2f;

    // Timer to control the shake effect.
    private float shakeTimer = 0f;

    // Initial position of the camera before the shake effect.
    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the camera.
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            // Generate a random position within a unit sphere and scale it by the shake intensity.
            Vector3 shakePosition = Random.insideUnitSphere * shakeIntensity;

            // Apply the shake effect to the camera's local position.
            transform.localPosition = initialPosition + shakePosition;

            // Reduce the shake timer.
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Reset the camera position after the shake effect has ended.
            transform.localPosition = initialPosition;
        }
    }

    public void StartShake()
    {
        // Start the shake effect by setting the shake timer to the duration.
        shakeTimer = shakeDuration;
    }
}
