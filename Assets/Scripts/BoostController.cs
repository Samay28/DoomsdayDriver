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
    public static bool isBoosting;
    private float timeSinceLastIncrease = 0.0f;
    private float timeSinceLastDecrease = 0.0f;
    public float DecreaseInterval = 1.5f;
    void Start()
    {


    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isBoosting)
        {
            timeSinceLastIncrease += Time.deltaTime;

            if (timeSinceLastIncrease >= DecreaseInterval)
            {
                IncreaseNos();
                timeSinceLastIncrease = 0;
            }
        }
        NosValue = Mathf.Clamp(NosValue, 0, 10);
    }
    public void Nitro()
    {
        if (NosValue > 0)
        {
            timeSinceLastDecrease += Time.deltaTime;
            if (timeSinceLastDecrease >= 0.5f)
            {
                Debug.Log("boosting");
                NosValue -= decreaseFactor;
                NosSlider.value = NosValue;
                timeSinceLastDecrease = 0;
            }
            isBoosting = true;
        }
        else
            isBoosting = false;
    }
    public void IncreaseNos()
    {
        NosValue = NosValue + 1;
        NosSlider.value = NosValue;
    }
}
