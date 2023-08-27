using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Net.Http.Headers;

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
    public static bool DisableCol;
    public FuelManager FuelSystem;


    // Start is called before the first frame update
    void Start()
    {
        Player = this.gameObject;
        rb = GetComponent<Rigidbody>();
        gw.RunDummy();
        IsCollided = false;
        Music.Play();
        DisableCol = false;

    }
    private void Update()
    {
        if (!IsCollided && !FuelManager.FuelOver)
        {
            if (Input.GetMouseButton(0))
            {
                Time.timeScale = 1f;
                if (!EventSystem.current.currentSelectedGameObject)
                {
                    // if (Input.touchCount == 2)
                    // {
                    //     BoostSystem.Nitro();
                    //     BoostParticles1.Play();
                    //     BoostParticles2.Play();
                    // }
                    if (Input.touchCount == 1)
                    {

                        // BoostController.isBoosting = false;
                        if (Input.mousePosition.x < Screen.width / 2)
                        {
                            transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
                            Move.Play();
                        }
                        else if (Input.mousePosition.x > Screen.width / 2)
                        {
                            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
                            Move.Play();
                        }

                    }
                    // else
                    //     BoostController.isBoosting = false;
                }
            }
        }

    }

    private void FixedUpdate()
    {
        if (!IsCollided && !FuelManager.FuelOver)
        {
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
        if (!other.gameObject.CompareTag("Building") && !other.gameObject.CompareTag("Human") && !other.gameObject.CompareTag("Can"))
        {
            gw.RunDummy();
            Debug.Log("generate kar");
            GameManager.score++;
        }

        if (other.gameObject.CompareTag("Human"))
        {
            StartCoroutine(HumanActivation());
            GameManager.score++;
            Debug.Log("Pickedup");
            GameManager.instance.UpdateDiamonds();
            Collected.Play();
        }
        if (other.gameObject.CompareTag("Can"))
        {
            StartCoroutine(JerryCanActivation());
            Debug.Log("Fuel pickedup");
            Collected.Play();
            FuelSystem.IncreaseFuel();
        }
        if (other.gameObject.CompareTag("Building") && !DisableCol)
        {
            IsCollided = true;
            Debug.Log("Takra gye");
            ss.StartShake();
            Crashed.Play();
            Music.Stop();
            GameOverAudio.Play();
            GameManager.instance.TotalDiamonds();
        }
    }
    private void OnCollisionEnter(Collision other)
    {

    }
    IEnumerator HumanActivation()
    {
        GameObject[] human = GameObject.FindGameObjectsWithTag("Human");
        foreach (GameObject obj in human)
        {
            obj.SetActive(false);
        }
        yield return new WaitForSeconds(1);
        foreach (GameObject obj in human)
        {
            obj.SetActive(true);
        }

    }
    IEnumerator JerryCanActivation()
    {
        GameObject[] JerryCan = GameObject.FindGameObjectsWithTag("Can");
        foreach (GameObject obj in JerryCan)
        {
            obj.SetActive(false);
        }
        yield return new WaitForSeconds(1);
        foreach (GameObject obj in JerryCan)
        {
            obj.SetActive(true);
        }

    }
    // public void OnClickBoost()
    // {

    //     BoostSystem.Nitro();
    //     BoostParticles1.Play();
    //     BoostParticles2.Play();

    // }
}
