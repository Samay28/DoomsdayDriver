using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public int Boolkey = 1;
    public Button targetButton;
    public Sprite SoundOn;
    public Sprite SoundOff;
    void Start()
{
    // Check if the "audio" key exists in PlayerPrefs
    if (PlayerPrefs.HasKey("audio"))
    {
        // Retrieve the value from PlayerPrefs and update the Boolkey
        Boolkey = PlayerPrefs.GetInt("audio");

        Image buttonImage = targetButton.GetComponent<Image>();
        if (Boolkey == 1)
        {
            buttonImage.sprite = SoundOn;
            AudioListener.volume = 1;
        }
        else
        {
            buttonImage.sprite = SoundOff;
            AudioListener.volume = 0;
        }
    }
    else
    {
        // Set the default value for "audio" key in PlayerPrefs if it doesn't exist
        PlayerPrefs.SetInt("audio", Boolkey);
    }
}

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickButton()
    {
        Image buttonImage = targetButton.GetComponent<Image>();
        if (Boolkey == 1)
        {
            Boolkey = 0;
            PlayerPrefs.SetInt("audio", Boolkey);
            buttonImage.sprite = SoundOff;
           AudioListener.volume = 0;
        }
        else
        {
            Boolkey = 1;
            PlayerPrefs.SetInt("audio", Boolkey);
            buttonImage.sprite = SoundOn;
           AudioListener.volume = 1;
        }
    }
}
