using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRoad : MonoBehaviour
{
    public static float speed = -0.30f;
    private void FixedUpdate()
    {
        // if (GameManager.isDead)
        // {
        //     return;
        // }
        if (!PlayerControler.IsCollided)
            StartScrolling();
        else
            stopscroll();

    }
    public void stopscroll()
    {
        this.transform.position += PlayerControler.Player.transform.forward * 0;
    }
    public void StartScrolling()
    {
        this.transform.position += PlayerControler.Player.transform.forward * speed;
        DifficultyIncrease();
    }
    public void DifficultyIncrease()
    {   
        if (GameManager.score<=10)
        {
            speed = -0.30f;
        }
        if (GameManager.score >= 10 && GameManager.score<=20)
        {
            speed = -0.31f;
        }
        else if (GameManager.score > 20 && GameManager.score<=30)
        {
            speed = -0.32f;
        }
        else if (GameManager.score > 30 && GameManager.score<=40)
        {
            speed = -0.33f;
        }
        else if (GameManager.score > 40 && GameManager.score<=50)
        {
            speed = -0.34f;
        }
        else if (GameManager.score > 50 && GameManager.score<=60)
        {
            speed = -0.35f;
        }
        else if (GameManager.score > 60 && GameManager.score<=70)
        {
            speed = -0.36f;
        }
        else if (GameManager.score > 70 && GameManager.score<=80)
        {
            speed = -0.37f;
        }
        else if (GameManager.score > 80)
        {
            speed = -0.38f;
        }

    }

}
