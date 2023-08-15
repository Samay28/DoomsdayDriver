using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisableArrows : MonoBehaviour
{
   [SerializeField] Image ImageObj;
    void Start()
    {
        ImageObj = GetComponent<Image>();
        StartCoroutine(DisableThis());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator DisableThis()
    {
        ImageObj.enabled = true;
        yield return new WaitForSeconds(5);
        ImageObj.enabled = false;
    }
}
