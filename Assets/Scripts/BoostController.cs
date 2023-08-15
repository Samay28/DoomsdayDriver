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
    private float timeSinceLastIncrease = 0.0f;
    public float DecreaseInterval = 1.0f;
    void Start()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
    private void Update()
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
        NosValue = Mathf.Clamp(NosValue,0,10);
    }
        public void Nitro()
        {
            if (NosValue > 0)
            {
                GameObject[] roadObjects = GameObject.FindGameObjectsWithTag("Roads");
                NosValue -= decreaseFactor;
                NosSlider.value = NosValue;
                foreach (GameObject roadObject in roadObjects)
                {
                    ScrollRoad road = roadObject.GetComponent<ScrollRoad>();
                    if (road != null)
                    {
                        road.speed = road.speed * 8.2f;
                    }
                }
                isBoosting = true;
            }
        }
        public void IncreaseNos()
        {
            NosValue = NosValue + 1;
            NosSlider.value = NosValue;
        }
    }
