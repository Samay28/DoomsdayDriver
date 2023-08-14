using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateW : MonoBehaviour
{
    static public GameObject dummyTraveller;
    static public GameObject LastPlatform;
    public GameObject panel;


    void Awake()
    {
        dummyTraveller = new GameObject("dummy");
    }

    public void RunDummy()
    {
        if (GameManager.score > 40)
        {
            GameObject p = ObjectPool.instance.GetRandom();
            if (p == null) return;

            if (LastPlatform != null)
            {
                Vector3 spawnPosition = LastPlatform.transform.position + new Vector3(0f, 0f, 66.25f);
                dummyTraveller.transform.position = spawnPosition;

            }
            LastPlatform = p;
            p.SetActive(true);
            p.transform.position = dummyTraveller.transform.position;
            p.transform.rotation = dummyTraveller.transform.rotation;
        }
        else if (GameManager.score > 20)
        {
            GameObject p = ObjectPool2.instance.GetRandom();
            if (p == null) return;

            if (LastPlatform != null)
            {
                Vector3 spawnPosition = LastPlatform.transform.position + new Vector3(0f, 0f, 66.25f);
                dummyTraveller.transform.position = spawnPosition;

            }
            LastPlatform = p;
            p.SetActive(true);
            p.transform.position = dummyTraveller.transform.position;
            p.transform.rotation = dummyTraveller.transform.rotation;
        }
        else if (GameManager.score <= 20)
        {
            GameObject p = ObjectPool3.instance.GetRandom();
            if (p == null) return;

            if (LastPlatform != null)
            {
                Vector3 spawnPosition = LastPlatform.transform.position + new Vector3(Random.Range(-2f,2f), 0f, 66.25f);
                dummyTraveller.transform.position = spawnPosition;

            }
            LastPlatform = p;
            p.SetActive(true);
            p.transform.position = dummyTraveller.transform.position;
            p.transform.rotation = dummyTraveller.transform.rotation;
        }

        
    }
}
// void SetInActivePanel()
// {
//     panel.SetActive(false);
// }



