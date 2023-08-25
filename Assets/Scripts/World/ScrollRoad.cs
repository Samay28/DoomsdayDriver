using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRoad : MonoBehaviour
{
    public float speed = -15f;
    public float currentSpeed;
    private void LateUpdate()
    {
        if (PlayerControler.IsCollided || FuelManager.FuelOver)
        {
            stopscroll();
        }
        else
        {
            StartScrolling();
        }


    }
    private void Update()
    {
        if (!PlayerControler.IsCollided || !FuelManager.FuelOver)
            if (BoostController.isBoosting)
            {
                speed = -30f;
            }
            else if (!BoostController.isBoosting)
            {
                speed = currentSpeed;
                DifficultyIncrease();
            }


    }
    public void stopscroll()
    {
        this.transform.position += PlayerControler.Player.transform.forward * 0;
    }
    public void StartScrolling()
    {
        this.transform.position += PlayerControler.Player.transform.forward * speed * Time.deltaTime;

    }
    public void DifficultyIncrease()
    {
        if (GameManager.score <= 10)
        {
            currentSpeed = -15f;
        }
        if (GameManager.score >= 10 && GameManager.score <= 20)
        {
            currentSpeed = -16;
        }
        else if (GameManager.score > 20 && GameManager.score <= 30)
        {
            currentSpeed = -17f;
        }
        else if (GameManager.score > 30 && GameManager.score <= 40)
        {
            currentSpeed = -18f;
        }
        else if (GameManager.score > 40 && GameManager.score <= 50)
        {
            currentSpeed = -19f;
        }
        else if (GameManager.score > 50 && GameManager.score <= 60)
        {
            currentSpeed = -20f;
        }
        else if (GameManager.score > 60 && GameManager.score <= 70)
        {
            currentSpeed = -21f;
        }
        else if (GameManager.score > 70 && GameManager.score <= 80)
        {
            currentSpeed = -22f;
        }
        else if (GameManager.score > 80)
        {
            currentSpeed = -23f;
        }

    }

}
