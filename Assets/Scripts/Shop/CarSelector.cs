using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MonoBehaviour
{
    public Car[] Cars;
    public static int selectedCar = 0;
    public int UnlockedCar = 0;

    void Start()
    {
        selectedCar = PlayerPrefs.GetInt("selectedcar", 0);
        selectedCar = Mathf.Clamp(selectedCar, 0, Cars.Length - 1);
        SetSelectedCar(selectedCar);

        for (int i = 0; i < Cars.Length; i++)
        {

        }
    }

    void Update()
    {
        // You can handle your swipe input here and call NextCar() when needed.
    }

    public void NextCar()
    {
        // Deactivate the currently selected car.
        Cars[selectedCar].CargameObject.SetActive(false);

        // Increment the selectedCar index and wrap around if necessary.
        selectedCar = (selectedCar + 1) % Cars.Length;

        // Activate the newly selected car.
        SetSelectedCar(selectedCar);

        Debug.Log(selectedCar);
    }

    // Helper method to activate the selected car and deactivate others.
    public void SetSelectedCar(int index)
    {
        for (int i = 0; i < Cars.Length; i++)
        {
            // Cars[i].CargameObject.SetActive(i == index);
        }
        // for (int i = 0; i < Cars.Length; i++)
        // {
        //     if (Cars[i].Locked == false)
        //     {
        //         PlayerPrefs.SetInt("selectedCar", selectedCar);
        //         PlayerPrefs.Save();
        //     }
        // }
    }

}
