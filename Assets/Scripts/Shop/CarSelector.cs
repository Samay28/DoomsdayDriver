using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MonoBehaviour
{
    public GameObject[] CarPrefabs;
    public CarsDatabase carDatabase; // Reference to your CarsDatabase scriptable object
    public static int selectedCar = 0;
    public int ViewingCar = 0;

    void Start()
    {
        // Load the selected car index from PlayerPrefs
        selectedCar = PlayerPrefs.GetInt("selectedcar", 0);

        // Ensure selectedCar is within valid bounds
        selectedCar = Mathf.Clamp(selectedCar, 0, carDatabase.carsCount - 1);

        // Set the initially selected car
        SetSelectedCar(selectedCar);
        ViewingCar = selectedCar;
    }

    void Update()
    {
        // You can handle your swipe input here and call NextCar() when needed.
    }

    public void NextCar()
    {
        // Deactivate the currently selected car.
        carDatabase.GetCars(ViewingCar).CargameObject.SetActive(false);
        CarPrefabs[ViewingCar].SetActive(false);

        // Increment the selectedCar index and wrap around if necessary.
        ViewingCar = (ViewingCar + 1) % carDatabase.carsCount;


        SetSelectedCar(ViewingCar);
        Debug.Log(ViewingCar);

    }

    // Helper method to activate the selected car and deactivate others.
    public void SetSelectedCar(int index)
    {
        for (int i = 0; i < carDatabase.carsCount; i++)
        {
            carDatabase.GetCars(i).CargameObject.SetActive(i == index);
            CarPrefabs[i].SetActive(i == index);

            if (carDatabase.GetCars(i).locked == false)
            {
                PlayerPrefs.SetInt("selectedcar", selectedCar);
                PlayerPrefs.Save();

                Debug.Log("Selected Car Index: " + selectedCar);
            }
            // else
            // {

            // }
        }

    }
    public void SaveCar()
    {
        SetSelectedCar(selectedCar);
    }
    public void PurchaseCar()
    {
        if (carDatabase.GetCars(ViewingCar).locked == true)
        {
            if (GameManager.instance.Diamonds >= 1)
            {
                GameManager.instance.Diamonds = GameManager.instance.Diamonds - 1;
                PlayerPrefs.SetInt("diamonds", GameManager.instance.Diamonds);
                carDatabase.GetCars(selectedCar).locked = false;


                SaveCarData(selectedCar, carDatabase.GetCars(selectedCar).locked);
                Debug.Log("Transaction successfull");
                selectedCar = ViewingCar;
                PlayerPrefs.SetInt("selectedcar", selectedCar);
                PlayerPrefs.Save();

                Debug.Log("Selected Car Index: " + selectedCar);
            }
            else
            {
                Debug.Log("not enough ");
            }
        }
    }
    private void SaveCarData(int carIndex, bool lockedStatus)
    {
        // You can use a key unique to each car to store its locked status.
        // For example, use "carX_locked" where X is the car's index.
        string key = "car" + carIndex + "_locked";

        // Store the locked status in PlayerPrefs
        PlayerPrefs.SetInt(key, lockedStatus ? 1 : 0);
        PlayerPrefs.Save();
    }
}
