using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public static GameObject Player;
    Rigidbody rb;
    public static float movespeed;
    [SerializeField] float speed = 40f;
    float dx;
    public static bool IsColidedObstacle = false;
    public GenerateW gw;
    public TextMeshProUGUI scoreText;
    [SerializeField] private float minRotation;
    [SerializeField] private float maxRotation;
    public static bool IsCollided;

    // Start is called before the first frame update
    void Start()
    {
        Player = this.gameObject;
        rb = GetComponent<Rigidbody>();
        gw.RunDummy();
        IsCollided = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Time.timeScale = 1f;

            if (Input.mousePosition.x < Screen.width / 2) // Pressing the left side of the screen
            {
                transform.Rotate(0f, -speed * Time.deltaTime, 0f); // Rotate the object counterclockwise around its Y-axis
            }
            else
            {
                transform.Rotate(0f, speed * Time.deltaTime, 0f); // Rotate the object clockwise around its Y-axis
            }

        }
    }
    private void ClampRotation()
    {
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.y = Mathf.Clamp(currentRotation.y, minRotation, maxRotation);
        transform.localEulerAngles = currentRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        gw.RunDummy();
        Debug.Log("generate kar");
        GameManager.score++;
    }
    private void OnCollisionEnter(Collision other)
    {
        IsCollided = true;
    }
}
