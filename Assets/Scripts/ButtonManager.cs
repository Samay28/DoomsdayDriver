using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{   
    public PlayerControler car;
    public GameObject GameoverPanel;
    public GameObject PausePanel;
    public GameObject MainPanel;
    [SerializeField] int DiamondsReqToSpawn = 1;
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
    public void Respawn()
    {
        if (GameManager.instance.Diamonds >= DiamondsReqToSpawn)
        {
            PlayerControler.IsCollided = false;
            GameoverPanel.SetActive(false);
            MainPanel.SetActive(true);
            StartCoroutine(disableCol());

            GameManager.instance.Diamonds = GameManager.instance.Diamonds - DiamondsReqToSpawn;
            PlayerPrefs.SetInt("diamonds", GameManager.instance.Diamonds);
        }
        else
            return;
    }


    public IEnumerator disableCol()
    {   
        car.transform.position = new Vector3(0.15f, car.transform.position.y, car.transform.position.z);
        PlayerControler.DisableCol = true;
        yield return new WaitForSeconds(1);
        PlayerControler.DisableCol = false;
    }
}
