using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trails : MonoBehaviour
{
   public TrailRenderer[] TyreMarks;
   public static bool drift;
    void Start()
    {
        drift = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDrift();
    }
    private void CheckDrift()
    {
        if(drift)
        {
            startEmitter();
        }
        else
        {
            stopEmitter();
        }
    }
    private void startEmitter()
    {
        foreach(TrailRenderer T in TyreMarks)
        {
            T.emitting = true;
        }
    }
     private void stopEmitter()
    {
        foreach(TrailRenderer T in TyreMarks)
        {
            T.emitting = false;
        }
    }

}
