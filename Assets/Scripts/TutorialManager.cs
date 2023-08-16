using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] Panels;
    private int currentIndex = 0;

    void Start()
    {
        // ShowCurrentPanel();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ShowNextPanel();
        }
    }

    public void ShowCurrentPanel()
    {
        if (currentIndex >= 0 && currentIndex < Panels.Length)
        {
            for (int i = 0; i < Panels.Length; i++)
            {
                Panels[i].SetActive(i == currentIndex);
            }
        }

        if (currentIndex == 5)
        {
            LoadNextScene();
        }
    }

    private void ShowNextPanel()
    {
        currentIndex++;
        ShowCurrentPanel();
    }

    private void LoadNextScene()
    {
        // You can either specify the scene name or the build index of the next scene.
        // Replace "NextSceneName" with the actual name of your next scene.
        SceneManager.LoadScene(1);
    }
}
