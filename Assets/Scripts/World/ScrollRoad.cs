using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRoad : MonoBehaviour
{
    public static float speed = -0.2f;
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
    }

}
