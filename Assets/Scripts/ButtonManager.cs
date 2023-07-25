using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject GameoverPanel;
    public GameObject PausePanel;
    public GameObject MainPanel;
    void Start()
    {
        GameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControler.IsCollided)
        {
            ShowGameOver();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ShowGameOver()
    {
        GameoverPanel.SetActive(true);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        MainPanel.SetActive(false);
        PausePanel.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        MainPanel.SetActive(true);
        PausePanel.SetActive(false);
    }
}
