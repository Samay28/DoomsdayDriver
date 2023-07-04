using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateW : MonoBehaviour
{
    // public GameManager gm;
    // public CarContr gabbar;
    static public GameObject dummyTraveller;
    static public GameObject LastPlatform;
    public GameObject panel;


    void Awake()
    {
        dummyTraveller = new GameObject("dummy");
    }

    public void RunDummy()
    {
        
            GameObject p = ObjectPool.instance.GetRandom();
            if (p == null) return;

            if (LastPlatform != null)
            {
                dummyTraveller.transform.position = LastPlatform.transform.position +
                PlayerControler.Player.transform.forward * 66.5f;
                // if (LastPlatform.tag == "GabbarRoad")
                // {
                //     GameObject.Find("Gabbar").GetComponent<AudioSource>().Play();
                //     panel.SetActive(true);
                //     Invoke("SetInActivePanel", 3f);
                // }
            }
            LastPlatform = p;
            p.SetActive(true);
            p.transform.position = dummyTraveller.transform.position;
            p.transform.rotation = dummyTraveller.transform.rotation;
    }
    // void SetInActivePanel()
    // {
    //     panel.SetActive(false);
    // }


}
