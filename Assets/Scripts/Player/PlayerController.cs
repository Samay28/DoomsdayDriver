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
    float speed = 0.2f;
    float dx;
    public static bool IsColidedObstacle = false;
    public GenerateW gw;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Player = this.gameObject;
        rb = GetComponent<Rigidbody>();
        gw.RunDummy();
        gw.RunDummy();
        gw.RunDummy();
        gw.RunDummy();
    }

    private void FixedUpdate()
    {
        // Get the user input for left/right movement
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement vector based on user input
        Vector3 movement = new Vector3(horizontalInput * movespeed * Time.deltaTime, 0f, speed);

        // Apply the movement to the rigidbody
        rb.MovePosition(transform.position + movement);
    }
}
