using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour
{
    public TextMeshProUGUI alertText;
    public float displayDuration = 5f;
    public Color startColor;
    public Color alarmingColor;

    private Coroutine displayCoroutine;

    private void Start()
    {
        // Initialize the text and color
        alertText.text = "Fuel Leakage";
        alertText.color = startColor;
        alertText.enabled = false;
    }

    public void ShowAlert()
    {
        if (displayCoroutine != null)
        {
            StopCoroutine(displayCoroutine);
        }
        displayCoroutine = StartCoroutine(DisplayAlert());
    }

    private IEnumerator DisplayAlert()
    {
        // Display the alert
        alertText.enabled = true;

        // Gradually change the color to alarmingColor
        float elapsedTime = 0f;
        while (elapsedTime < displayDuration)
        {
            float t = elapsedTime / displayDuration;
            alertText.color = Color.Lerp(startColor, alarmingColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset the color and hide the alert
        alertText.color = startColor;
        alertText.enabled = false;
    }
}
