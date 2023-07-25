using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateRoad : MonoBehaviour
{
    void SetInactive()
    {
        this.gameObject.SetActive(false);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            Debug.Log("he");
            Invoke("SetInactive", 5.0f);
        }
    }
}
