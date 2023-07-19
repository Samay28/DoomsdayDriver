using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaking : MonoBehaviour
{

    public PlayerControler Car;
    public AnimationCurve curve;
    // public float duration = 1f;
    private void Update()
    {
        if(PlayerControler.IsCollided)
            StartCoroutine(ShakingCam(0.1f, 4f));
    }
    public IEnumerator ShakingCam(float duration, float magnitude)
    {
        Vector3 startPos = transform.localPosition;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {   
            float x = Random.Range(-1.2f,1.2f)*magnitude;
            // float z = Random.Range(-1f,1f)*magnitude;

            elapsedTime += Time.deltaTime;
            transform.localPosition = new Vector3(x,startPos.y,startPos.z);
            yield return null;
        }
        transform.localPosition = startPos;
    }
}
