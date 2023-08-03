using UnityEngine;

public class FallBuildings : MonoBehaviour
{
    [SerializeField] private BoxCollider boxColl;
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
        boxColl = GetComponent<BoxCollider>();

        // MeshCollider meshCollider = GetComponent<MeshCollider>();
        // if (meshCollider != null)
        // {
        //     // Set the Mesh Collider's convex property to true
        //     meshCollider.convex = true;

        //     // Optionally, update the Mesh Collider's sharedMesh to match the building's mesh
        //     meshCollider.sharedMesh = GetComponent<MeshFilter>().mesh;

        // }
        boxColl.enabled = false;
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
                    transform.position.z // Do not add ScrollRoad.speed * Time.deltaTime here
                );

            }
            if (isLeft)
            {
                transform.position = new Vector3(
                    Mathf.Lerp(initialPosition.x, initialPosition.x + xDirec, t),
                    Mathf.Lerp(initialPosition.y, initialPosition.y + 0.0179f, t),
                    transform.position.z // Do not add ScrollRoad.speed * Time.deltaTime here
                );
            }

            Quaternion targetQuaternion = Quaternion.Euler(targetRotation);
            Quaternion interpolatedRotation = Quaternion.LerpUnclamped(initialRotation, targetQuaternion, t);
            transform.rotation = interpolatedRotation;

            // Make the building fall from its pivot
            float fallSpeed = 20f; // Adjust the falling speed as needed
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

        }
        else
        {
            boxColl.enabled = true;
        }
    }

}
