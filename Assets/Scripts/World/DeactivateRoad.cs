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
        Debug.Log("he");
        Invoke("SetInactive", 10.0f);
    }
}
