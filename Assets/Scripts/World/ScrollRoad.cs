using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRoad : MonoBehaviour
{
    public static float speed = -15f;
    private void Update()
    {
        if(PlayerControler.IsCollided || FuelManager.FuelOver)
        {
            stopscroll();
        }
        else
        StartScrolling();
    }
    public void stopscroll()
    {
        this.transform.position += PlayerControler.Player.transform.forward * 0;
    }
    public void StartScrolling()
    {
        this.transform.position += PlayerControler.Player.transform.forward * speed * Time.deltaTime;
        DifficultyIncrease();
    }
    public void DifficultyIncrease()
    {
        if (GameManager.score <= 10)
        {
            speed = -15f;
        }
        if (GameManager.score >= 10 && GameManager.score <= 20)
        {
            speed = -16;
        }
        else if (GameManager.score > 20 && GameManager.score <= 30)
        {
            speed = -17f;
        }
        else if (GameManager.score > 30 && GameManager.score <= 40)
        {
            speed = -18f;
        }
        else if (GameManager.score > 40 && GameManager.score <= 50)
        {
            speed = -19f;
        }
        else if (GameManager.score > 50 && GameManager.score <= 60)
        {
            speed = -20f;
        }
        else if (GameManager.score > 60 && GameManager.score <= 70)
        {
            speed = -216f;
        }
        else if (GameManager.score > 70 && GameManager.score <= 80)
        {
            speed = -22f;
        }
        else if (GameManager.score > 80)
        {
            speed = -23f;
        }

    }

}
