using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class BoostButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool buttonHeld = false;
    public BoostController BoostSystem;
    public ParticleSystem BoostParticles1;
    public ParticleSystem BoostParticles2;

    private void Start()
    {

        BoostParticles1.Stop();
        BoostParticles2.Stop();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        // Button is pressed, start the coroutine
        buttonHeld = true;
        StartCoroutine(ExecuteWhileButtonHeld());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Button is released, stop the coroutine
        buttonHeld = false;
        BoostParticles1.Stop();
        BoostParticles2.Stop();
        BoostController.isBoosting = false;
    }

    private IEnumerator ExecuteWhileButtonHeld()
    {
        while (buttonHeld)
        {
            // Execute your function here
            BoostSystem.Nitro();
            BoostParticles1.Play();
            BoostParticles2.Play();

            // Wait for the next frame before checking the button state again
            yield return null;
        }
    }
}
