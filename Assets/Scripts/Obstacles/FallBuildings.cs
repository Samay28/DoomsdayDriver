using UnityEngine;

public class FallBuildings : MonoBehaviour
{
    public Vector3 targetRotation; // The target rotation in Euler angles
    float duration = 2f; // Time in seconds for the transformation
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private float timer = 0f;

    [SerializeField] private bool IsRight = false;
    [SerializeField] private bool isLeft = false;

    float xDirec = 0.0089f;
    private void Start()
    {
        // Save the initial position and rotation
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (timer < duration)
        {
            timer += Time.deltaTime;

            // Calculate the interpolation value between 0 and 1
            float t = Mathf.Clamp01(timer / duration);

            if (IsRight)
            {
                transform.position = new Vector3(
                    Mathf.Lerp(initialPosition.x, initialPosition.x - xDirec, t),
                    Mathf.Lerp(initialPosition.y, initialPosition.y + 0.0179f, t),
                    transform.position.z + (ScrollRoad.speed * Time.deltaTime)
                );
            }
            if (isLeft)
            {
                transform.position = new Vector3(
                    Mathf.Lerp(initialPosition.x, initialPosition.x + xDirec, t),
                    Mathf.Lerp(initialPosition.y, initialPosition.y + 0.0179f, t),
                    transform.position.z + (ScrollRoad.speed * Time.deltaTime)
                );
            }

            Quaternion targetQuaternion = Quaternion.Euler(targetRotation);
            Quaternion interpolatedRotation = Quaternion.LerpUnclamped(initialRotation, targetQuaternion, t);
            transform.rotation = interpolatedRotation;

            // Make the building fall from its pivot
            float fallSpeed = 10f; // Adjust the falling speed as needed
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

        }
    }
}
