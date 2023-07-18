using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    [SerializeField] TextMeshProUGUI ScoreText;
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
    }
}
