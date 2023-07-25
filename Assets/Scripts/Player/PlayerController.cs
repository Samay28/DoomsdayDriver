using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public ScreenShaking ss;
    public static GameObject Player;
    Rigidbody rb;
    public static float movespeed;
    [SerializeField] float speed = 40f;
    float dx;
    public static bool IsColidedObstacle = false;
    public GenerateW gw;
    public static bool IsCollided;
    public AudioSource Move;
    public AudioSource Crashed;
    public AudioSource Collected;
    public AudioSource Music;
    public AudioSource GameOverAudio;

    // Start is called before the first frame update
    void Start()
    {
        Player = this.gameObject;
        rb = GetComponent<Rigidbody>();
        gw.RunDummy();
        IsCollided = false;
        Music.Play();
    }

    private void FixedUpdate()
    {
        if (!IsCollided)
            if (Input.GetMouseButton(0))
            {
                Time.timeScale = 1f;

                if (Input.mousePosition.x < Screen.width / 2) // Pressing the left side of the screen
                {
                    transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f); // Move the object to the left along the x-axis
                    Move.Play();
                }
                else
                {
                    transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f); // Move the object to the right along the x-axis
                    Move.Play();
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
        if (!other.gameObject.CompareTag("Building") && !other.gameObject.CompareTag("Human"))
        {
            gw.RunDummy();
            Debug.Log("generate kar");
            GameManager.score++;
            
        }

        if (other.gameObject.CompareTag("Human"))
        {
            other.gameObject.SetActive(false);
            GameManager.score++;
            Debug.Log("Pickedup");
            GameManager.instance.UpdateDiamonds();
            Collected.Play();
        }
        if (other.gameObject.CompareTag("Building"))
        {
            IsCollided = true;
            Debug.Log("Takra gye");
            ss.StartShake();
            Crashed.Play();
            Music.Stop();
            GameOverAudio.Play();
        }
    }
    private void OnCollisionEnter(Collision other)
    {

    }
}
