using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;
using UnityEngine.SceneManagement;

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
        if (count == 0 || newcount==0)
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
        TransCam1.Play();
        MainUI.SetActive(false);
        StoreUI.SetActive(true);
    }
    public void BackFromStore()
    {
        TransCam2.Play();
        MainUI.SetActive(true);
        StoreUI.SetActive(false);
    }
}
