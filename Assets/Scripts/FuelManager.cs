using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    public float TotalFuel = 100.0f;
    public float DecreaseInterval = 1.0f;
    [SerializeField] float RefillRate = 30;
    public GameObject FuelPanel;
    private bool shouldDecreaseFuel = false;
    bool Called;
    public static bool FuelOver;
    private float timeSinceLastDecrease = 0.0f;
    public Image[] FuelLevels;

    private void Start()
    {
        FuelPanel.SetActive(true);
        FuelOver = false;
        UpdateFuelUI();
        StartFuelDecrease();
    }

    private void Update()
    {
        timeSinceLastDecrease += Time.deltaTime;

        if (timeSinceLastDecrease >= DecreaseInterval)
        {
            if (shouldDecreaseFuel)
            {
                DecreaseFuel();
                timeSinceLastDecrease = 0.0f;
            }
        }
        // if (!Called)
        // {
        //     StartFuelDecrease();
        //     Called = true;
        //     FuelPanel.SetActive(true);
        // }
        TotalFuel = Mathf.Clamp(TotalFuel, 0, 100);
    }

    private void DecreaseFuel()
    {
        GameObject[] roadObjects = GameObject.FindGameObjectsWithTag("Roads");

        foreach (GameObject roadObject in roadObjects)
        {
            ScrollRoad road = roadObject.GetComponent<ScrollRoad>();
            if (road != null)
            {
                TotalFuel = TotalFuel + road.speed * 1 / 10;
            }
        }
        Debug.Log(TotalFuel);
        UpdateFuelUI();

        if (TotalFuel <= 0)
        {
            FuelOver = true;
            StopFuelDecrease();
        }
    }

    public void StartFuelDecrease()
    {
        shouldDecreaseFuel = true;
    }

    public void StopFuelDecrease()
    {
        shouldDecreaseFuel = false;
    }

    public void IncreaseFuel()
    {
        TotalFuel = TotalFuel + RefillRate;
        UpdateFuelUI();
    }

    public void ResetFuel()
    {
        TotalFuel = 100;
        UpdateFuelUI();
    }

   void UpdateFuelUI()
{
    for (int i = 0; i < FuelLevels.Length; i++)
    {
        if (i == 0)
        {
            // For the last image, disable it when fuel is less than or equal to 0.
            FuelLevels[i].enabled = TotalFuel > 0;
        }
        else
        {
            // Calculate the threshold for disabling/enabling each image.
            float threshold = (i + 1) * (100.0f / FuelLevels.Length);

            // Enable the image if the current fuel level is below this image's threshold.
            FuelLevels[i].enabled = TotalFuel >= threshold;
        }
    }
}

}
