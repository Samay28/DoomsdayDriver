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
    [SerializeField] Text Diamondtxt;
    [SerializeField] public int DiamondsCollected;
    [SerializeField] Text CurrentDiamondTxt;
    [SerializeField] public int HighScore;
    bool isCalled;

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
        DiamondsCollected = 0;
        isCalled = false;


        if (PlayerPrefs.HasKey("diamonds"))
        {
            Diamonds = PlayerPrefs.GetInt("diamonds");
            Diamondtxt.text = Diamonds.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ScoreText.Length; i++)
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
        UpdateCurrentDiamondsText();

        // if (PlayerControler.IsCollided && !isCalled)
        // {
        //     TotalDiamonds();
        // }
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
        DiamondsCollected++;
        CurrentDiamondTxt.text = DiamondsCollected.ToString();
    }
    public void TotalDiamonds()
    {
        Diamonds = Diamonds + DiamondsCollected;
        Diamondtxt.text = Diamonds.ToString();
        PlayerPrefs.SetInt("diamonds", Diamonds);
        isCalled = true;
    }
    public void UpdateCurrentDiamondsText()
    {   
        if(CurrentDiamondTxt!=null)
        CurrentDiamondTxt.text = DiamondsCollected.ToString();
    }
     public void UpdateDiamondsText()
    {   
        if(Diamondtxt!=null)
        Diamondtxt.text = Diamonds.ToString();
    }

}
