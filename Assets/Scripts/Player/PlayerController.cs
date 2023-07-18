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
                transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f); // Move the object to the left along the x-axis
            }
            else
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f); // Move the object to the right along the x-axis
            }
        }

    }
    // private void ClampRotation()
    // {
    //     Vector3 currentRotation = transform.localEulerAngles;
    //     currentRotation.y = Mathf.Clamp(currentRotation.y, minRotation, maxRotation);
    //     transform.localEulerAngles = currentRotation;
    // }

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
