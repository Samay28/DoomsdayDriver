using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostController : MonoBehaviour
{

    public float NosValue = 10;
    public float SpeedMuliplier = 1.2f;
    public Slider NosSlider;
    int decreaseFactor = 2;
    public bool isBoosting;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isBoosting)
        {
            NosValue = NosValue + 1;
            NosSlider.value = NosValue;
            // NosValue = Mathf.Clamp(NosValue, 0, 10);
        }
    }
    public void Nitro()
    {
        if (NosValue > 0)
        {
            NosValue -= decreaseFactor;
            NosSlider.value = NosValue;
            ScrollRoad.speed = -100;
            isBoosting = true;
        }
    }
}
