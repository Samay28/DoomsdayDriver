using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CarsDatabase : ScriptableObject
{
    
    public Car[] Cars;
    public int carsCount
    {
        get
        {
            return Cars.Length;
        }
    }
    public Car GetCars(int index)
    {
        {
            return Cars[index];
        }
    }
}
