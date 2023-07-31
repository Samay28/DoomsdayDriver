using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    AsyncOperation loadingOperation;
    public TextMeshProUGUI highscoretxt;
    public TextMeshProUGUI diamondtxt;
    int count;

    public GameObject TutorialPanel;
    public GameObject MainUI;
    public TutorialManager Tm;
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
            GameManager.instance.Diamonds = PlayerPrefs.GetInt("diamonds");
            diamondtxt.text = GameManager.instance.Diamonds.ToString();
        }
        if (PlayerPrefs.HasKey("count"))
        {
            count = PlayerPrefs.GetInt("count", 0);
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
        if (count == 0)
        {
            MainUI.SetActive(false);
            TutorialPanel.SetActive(true);
            Tm.ShowCurrentPanel();
            Tm.enabled = true;
            count++;
            PlayerPrefs.SetInt("count", count);
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
}
