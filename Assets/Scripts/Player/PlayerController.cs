using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerControler : MonoBehaviour
{
    // public GameManager gm;
    public static GameObject Player;
    // public TimeChange tm;
    // GameObject gb;
    // Animator anim;
    // Animator anime;
    Rigidbody rb;
    public static float movespeed;
    float speed = 3f;
    float dx;
    public static bool IsColidedObstacle = false;
    // AudioSource dashed;
    public GenerateW gw;
    public TextMeshProUGUI scoreText;


    // Start is called before the first frame update
    void Start()
    {

        Player = this.gameObject;
        // anim = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        gw.RunDummy();
        gw.RunDummy();
        gw.RunDummy();
        gw.RunDummy();
        // dashed = this.GetComponent<AudioSource>();
        
    }

    void Update()
    {
        
        // if (GameManager.isDead)
        // {
        //     anim.SetBool("IsDead", true);
        // }
        // if (!GameManager.isDead)
        // {
        //     anim.SetBool("IsDead", false);
        // }

        // scoreText.text = GameManager.score.ToString();


    }
    private void FixedUpdate()
    {
        // if (GameManager.isDead)
        // {
        //     return;
        // }
        Vector3 movement = new Vector3(transform.position.x, transform.position.y, Input.acceleration.z);
        rb.AddForce(movement * movespeed * Time.deltaTime);

    }
    void OnCollisionEnter(Collision other)
    {
        // if (other.gameObject.tag == "Obstacle")
        // {
        //     IsColidedObstacle = true;
        //     anim.SetBool("IsDead", true);
        //     GameObject.Find("Obstacle").GetComponent<AudioSource>().Play();
        //     gm.gameover();
        // }
        // if (other.gameObject.tag == "Gabbar" && gm.power >= gm.maxpower)
        // {
        //     GameObject.Find("Gabbar").GetComponent<Animator>().SetBool("GabbarDead", true);
        //     dashed.Play();
        //     GameManager.score += 30;
        //     gm.diamond++;
        //     gm.setprefdiamond();
        //     tm.timespeed = 0.2f;
        //     Invoke("timeNormalise", 0.8f);
        //     Invoke("powerReset", 1f);
        // }
        // if (other.gameObject.tag == "Gabbar" && gm.power < gm.maxpower)
        // {
        //     tm.timespeed = 0.2f;
        //     Invoke("timeNormalise", 0.8f);
        //     gm.gameover();
        //     Debug.Log("Haar gaya");
        // }
    }
    void OnTriggerEnter(Collider other)
    {
        // if (other.tag != "Sambha" && other.tag != "Obstacle" && other.tag != "Gabbar")
        // {
        //     gw.RunDummy();
        //     GameManager.score++;

        // }
        // if (other.gameObject.tag == "Sambha")
        // {
        //     GameManager.score++;
        //     gm.power += 1;
        // }

    }

    // void powerReset()
    // {
    //     gm.power = 0;
    // }
    // void timeNormalise()
    // {
    //     tm.timespeed = 1;
    // }

}
