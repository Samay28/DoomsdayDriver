using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MonoBehaviour
{
    public GameObject[] CarPrefabs;
    public CarsDatabase carDatabase; // Reference to your CarsDatabase scriptable object
    public static int selectedCar = 0;
    public int ViewingCar = 0;


    Vector2 startTouchPos;
    Vector2 currentTouchPos;
    Vector2 endTouchPos;
    bool stopTouch = false;
    public float swipeRange;
    public float tapRange;

    public GameObject SelectButton;
    public GameObject PurchaseButton;

    // private void Start()
    // {
    // }

    void Start()
    {
        // Assuming you have a total number of cars (e.g., totalCars)
        int totalCars = 20; // Change this to the total number of cars you have

        // Create a list to store the locked status of all cars
        List<bool> carLockedStatusList = new List<bool>();

        for (int carIndex = 0; carIndex < totalCars; carIndex++)
        {
            // Construct the key for the locked status of the car
            string key = "car" + carIndex + "_locked";

            // Retrieve the locked status from PlayerPrefs
            int lockedStatus = PlayerPrefs.GetInt(key, 1); // Default to 1 if the key doesn't exist (locked)

            // Convert the lockedStatus (1 or 0) to a boolean
            bool isLocked = lockedStatus == 1;

            // Add the locked status to the list
            carLockedStatusList.Add(isLocked);
        }

        // Now, 'carLockedStatusList' contains the locked status of all cars.
        // You can use this list in your logic as needed.
        for (int carIndex = 1; carIndex < totalCars; carIndex++)
        {
            Debug.Log("Car " + carIndex + " is locked: " + carLockedStatusList[carIndex]);
            carDatabase.GetCars(carIndex).locked = carLockedStatusList[carIndex];
        }
        // Load the selected car index from PlayerPrefs
        selectedCar = PlayerPrefs.GetInt("selectedcar", 0);

        // Ensure selectedCar is within valid bounds
        selectedCar = Mathf.Clamp(selectedCar, 0, carDatabase.carsCount - 1);
        ViewingCar = Mathf.Clamp(ViewingCar, 0, carDatabase.carsCount - 1);

        // Set the initially selected car
        SetSelectedCar(selectedCar);
        ViewingCar = selectedCar;
    }

    void Update()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentTouchPos = Input.GetTouch(0).position;
            Vector2 Distance = currentTouchPos - startTouchPos;

            if (!stopTouch)
            {
                if (Distance.x < -swipeRange)
                {
                    if (ViewingCar == 0)
                    {
                        return;
                    }
                    else
                    {
                        PrevCar();
                    }
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                    if (ViewingCar == 20)
                    {
                        ViewingCar = 0;
                    }
                    NextCar();
                    stopTouch = true;
                }
            }
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPos = Input.GetTouch(0).position;
            Vector2 Distance = endTouchPos - startTouchPos;
        }
        if (carDatabase.GetCars(ViewingCar).locked == false)
        {
            PurchaseButton.SetActive(false);
            SelectButton.SetActive(true);
        }
        else
        {
            PurchaseButton.SetActive(true);
            SelectButton.SetActive(false);
        }


    }

    public void NextCar()
    {
        // Deactivate the currently selected car.
        carDatabase.GetCars(ViewingCar).CargameObject.SetActive(false);
        CarPrefabs[ViewingCar].SetActive(false);

        // Increment the selectedCar index and wrap around if necessary.
        ViewingCar = (ViewingCar + 1) % carDatabase.carsCount;

        // if (carDatabase.GetCars(ViewingCar).locked == false)
        // {
        //     PurchaseButton.SetActive(false);
        //     SelectButton.SetActive(true);
        // }
        // else
        // {
        //     PurchaseButton.SetActive(true);
        //     SelectButton.SetActive(false);
        // }

        SetSelectedCar(ViewingCar);
        Debug.Log(ViewingCar);

    }
    public void PrevCar()
    {
        // Deactivate the currently selected car.
        carDatabase.GetCars(ViewingCar).CargameObject.SetActive(false);
        CarPrefabs[ViewingCar].SetActive(false);

        // Increment the selectedCar index and wrap around if necessary.
        ViewingCar = (ViewingCar - 1) % carDatabase.carsCount;

        // if (carDatabase.GetCars(ViewingCar).locked == false)
        // {
        //     PurchaseButton.SetActive(false);
        //     SelectButton.SetActive(true);
        // }
        // else
        // {
        //     PurchaseButton.SetActive(true);
        //     SelectButton.SetActive(false);
        // }

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
                // PurchaseButton.SetActive(false);
                // SelectButton.SetActive(true);
                PlayerPrefs.SetInt("selectedcar", selectedCar);
                PlayerPrefs.Save();

                Debug.Log("Selected Car Index: " + selectedCar);
            }
            // else
            // {
            //     PurchaseButton.SetActive(true);
            //     SelectButton.SetActive(false);
            // }
            // else
            // {

            // }
        }

    }
    public void SaveCar()
    {
        selectedCar = ViewingCar;
        SetSelectedCar(selectedCar);
    }

    public void PurchaseCar()
    {
        // Check if the car is locked
        if (carDatabase.GetCars(ViewingCar).locked)
        {
            // Check if the player has enough diamonds
            if (GameManager.instance.Diamonds >= 1)
            {
                // Deduct one diamond from the player
                GameManager.instance.Diamonds -= 1;
                PlayerPrefs.SetInt("diamonds", GameManager.instance.Diamonds);

                // Unlock the car
                carDatabase.GetCars(ViewingCar).locked = false;

                // Save the car data including its locked status
                SaveCarData(ViewingCar, carDatabase.GetCars(ViewingCar).locked);
                PlayerPrefs.Save();

                // Update the selected car to the purchased car
                selectedCar = ViewingCar;
                PlayerPrefs.SetInt("selectedcar", selectedCar);

                // Hide the PurchaseButton and show the SelectButton
                PurchaseButton.SetActive(false);
                SelectButton.SetActive(true);

                Debug.Log("Transaction successful");
                Debug.Log("Selected Car Index: " + selectedCar);
            }
            else
            {
                Debug.Log("Not enough diamond");
            }
        }
    }

    private void SaveCarData(int carIndex, bool lockedStatus)
    {
        // Use a key unique to each car to store its locked status.
        string key = "car" + carIndex + "_locked";

        // Store the locked status in PlayerPrefs
        PlayerPrefs.SetInt(key, lockedStatus ? 1 : 0);
    }
}

