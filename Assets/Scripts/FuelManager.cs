using System.Collections;
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
    public Slider FuelSlider;
    public FuelUI AlertTxt;

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
        if (GameManager.score >= 24 && !Called)
        {
            StartFuelDecrease();
            Called = true;
            FuelPanel.SetActive(true);
            AlertTxt.ShowAlert();
        }
        TotalFuel = Mathf.Clamp(TotalFuel,0,100);
    }

    private void DecreaseFuel()
    {
        TotalFuel = TotalFuel + ScrollRoad.speed * 2 / 4;
        Debug.Log(TotalFuel);
        FuelSlider.value = TotalFuel;

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
    public void ResetFuel()
    {
        TotalFuel = 100;
        FuelSlider.value = TotalFuel;
    }
}
