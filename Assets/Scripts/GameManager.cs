using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int score = 0;
    [SerializeField] TextMeshProUGUI[] ScoreText;
    [SerializeField] public int Diamonds;
    [SerializeField] Text[] Diamondtxt;
    [SerializeField] public int HighScore;

    private void Awake()
    {
        score = 0;
    }
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        Diamonds = 0;
        HighScore = PlayerPrefs.GetInt("highscore", 0);


        if (PlayerPrefs.HasKey("diamonds"))
        {
            Diamonds = PlayerPrefs.GetInt("diamonds");
            for (int i = 0; i < Diamondtxt.Length; i++)
            {
                Diamondtxt[i].text = Diamonds.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Diamondtxt.Length; i++)
        {
            ScoreText[i].text = score.ToString();
        }
        if (PlayerPrefs.HasKey("highscore"))
        {
            HighScore = PlayerPrefs.GetInt("highscore");
        }
        if (PlayerPrefs.HasKey("diamonds"))
        {
            Diamonds = PlayerPrefs.GetInt("diamonds");
        }
        UpdateHighscore();

    }

    public void UpdateHighscore()
    {
        if (score > HighScore)
        {
            HighScore = score;
            PlayerPrefs.SetInt("highscore", HighScore);
            PlayerPrefs.Save();
        }
    }
    public void UpdateDiamonds()
    {
        Diamonds++;
        for (int i = 0; i < Diamondtxt.Length; i++)
        {
            Diamondtxt[i].text = Diamonds.ToString();
        }
        PlayerPrefs.SetInt("diamonds", Diamonds);
    }

}
