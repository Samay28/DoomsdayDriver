using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class MainMenuManager : MonoBehaviour
{
    AsyncOperation loadingOperation;
    public TextMeshProUGUI highscoretxt;
    public TextMeshProUGUI diamondtxt;
    int count;
    int newcount;

    public GameObject TutorialPanel;
    public GameObject MainUI;
    public GameObject StoreUI;
    public GameObject SettingsUI;
    public GameObject SubSettingsPanel;
    public GameObject InstructionsPanel;
    public TutorialManager Tm;

    public PlayableDirector TransCam1;
    public PlayableDirector TransCam2;
    void Start()
    {
        StartCoroutine(LoadSceneAsync());

        if (PlayerPrefs.HasKey("highscore"))
        {
            GameManager.instance.HighScore = PlayerPrefs.GetInt("highscore", 0);
            highscoretxt.text = GameManager.instance.HighScore.ToString();
        }

        if (PlayerPrefs.HasKey("diamonds"))
        {
            GameManager.instance.Diamonds = PlayerPrefs.GetInt("diamonds", 0);
            diamondtxt.text = GameManager.instance.Diamonds.ToString();
        }

        if (PlayerPrefs.HasKey("count"))
        {
            count = PlayerPrefs.GetInt("count", 0);
        }
        if (PlayerPrefs.HasKey("newcount"))
        {
            newcount = PlayerPrefs.GetInt("newcount", 0);
        }
        Tm.enabled = false;
        MainUI.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            GameManager.instance.HighScore = PlayerPrefs.GetInt("highscore", 0);
            highscoretxt.text = GameManager.instance.HighScore.ToString();
        }

        if (PlayerPrefs.HasKey("diamonds"))
        {
            GameManager.instance.Diamonds = PlayerPrefs.GetInt("diamonds");
            diamondtxt.text = GameManager.instance.Diamonds.ToString();
        }
    }
    public void StartGame()
    {
        if (count == 0 || newcount == 0)
        {
            MainUI.SetActive(false);
            TutorialPanel.SetActive(true);
            Tm.ShowCurrentPanel();
            Tm.enabled = true;
            count++;
            newcount++;
            PlayerPrefs.SetInt("count", count);
            PlayerPrefs.SetInt("newcount", newcount);

        }

        else
            SceneManager.LoadScene(1);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private IEnumerator LoadSceneAsync()
    {
        loadingOperation = SceneManager.LoadSceneAsync(1);
        loadingOperation.allowSceneActivation = false;
        yield return null;
    }
    public void RateOnPlayStore()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.DoomsdayDriver.driverpath");
    }
    public void StoreButton()
    {
        TransCam2.extrapolationMode = DirectorWrapMode.None;
        TransCam1.Play();
        MainUI.SetActive(false);
        StoreUI.SetActive(true);
        TransCam1.extrapolationMode = DirectorWrapMode.Hold;
        // if (TransCam1.state == PlayState.Paused)
        // { 
        // }
    }
    public void BackFromStore()
    {
        TransCam1.extrapolationMode = DirectorWrapMode.None;
        TransCam2.Play();
        MainUI.SetActive(true);
        StoreUI.SetActive(false);
        TransCam2.extrapolationMode = DirectorWrapMode.Hold;
        // if (TransCam2.state == PlayState.Paused)
        // { 
        // }
    }
    public void OpenSettings()
    {
        SettingsUI.SetActive(true);
        MainUI.SetActive(false);
    }
    public void BackFromSettings()
    {
        SettingsUI.SetActive(false);
        MainUI.SetActive(true);
    }
    public void OpenInstructions()
    {
        InstructionsPanel.SetActive(true);
        SubSettingsPanel.SetActive(false);
    }
    public void BackFromInstructions()
    {
        InstructionsPanel.SetActive(false);
        SubSettingsPanel.SetActive(true);
    }
}
