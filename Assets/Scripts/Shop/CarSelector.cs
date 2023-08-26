using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MonoBehaviour
{
    public CarsDatabase carDatabase; // Reference to your CarsDatabase scriptable object
    public static int selectedCar = 0;

    void Start()
    {
        // Load the selected car index from PlayerPrefs
        selectedCar = PlayerPrefs.GetInt("selectedcar", 0);

        // Ensure selectedCar is within valid bounds
        selectedCar = Mathf.Clamp(selectedCar, 0, carDatabase.carsCount - 1);

        // Set the initially selected car
        SetSelectedCar(selectedCar);
    }

    void Update()
    {
        // You can handle your swipe input here and call NextCar() when needed.
    }

    public void NextCar()
    {
        // Deactivate the currently selected car.
        carDatabase.GetCars(selectedCar).CargameObject.SetActive(false);

        // Increment the selectedCar index and wrap around if necessary.
        selectedCar = (selectedCar + 1) % carDatabase.carsCount;

        // Activate the newly selected car.
        SetSelectedCar(selectedCar);

        // Save the selected car index to PlayerPrefs
        PlayerPrefs.SetInt("selectedcar", selectedCar);
        PlayerPrefs.Save();

        Debug.Log("Selected Car Index: " + selectedCar);
    }

    // Helper method to activate the selected car and deactivate others.
    public void SetSelectedCar(int index)
    {
        for (int i = 0; i < carDatabase.carsCount; i++)
        {
            carDatabase.GetCars(i).CargameObject.SetActive(i == index);
        }
    }
}
