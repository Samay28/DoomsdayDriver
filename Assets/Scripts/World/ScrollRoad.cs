using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRoad : MonoBehaviour
{
    public static float speed = -0.2f;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        // if (GameManager.isDead)
        // {
        //     return;
        // }
       StartScrolling();

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
