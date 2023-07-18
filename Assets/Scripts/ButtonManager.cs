using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject GameoverPanel;
    void Start()
    {
        GameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControler.IsCollided)
        {
            ShowGameOver();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowGameOver()
    {
        GameoverPanel.SetActive(true);
    }
}
