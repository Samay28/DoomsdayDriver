using System.Collections;
using UnityEngine;
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

    private void Start()
    {
        FuelPanel.SetActive(false);
        FuelOver = false;
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
        if (GameManager.score >= 2 && !Called)
        {
            StartFuelDecrease();
            Called = true;
            FuelPanel.SetActive(true);
        }
    }

    private void DecreaseFuel()
    {
        TotalFuel = TotalFuel + ScrollRoad.speed * 3 / 4;
        Debug.Log(TotalFuel);

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
        Debug.Log(TotalFuel);
    }
}
