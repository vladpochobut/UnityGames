using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultHUD : MonoBehaviour
{
    static Text TotalScore;
    static int actualScore;
    const string scorePrefix = "Total score : ";

    static Text MaxScore;
    static int maxScore;
    const string maxScorePrefix = "Max score : ";

    static Text TotalCoins;
    static int totalCoins;
    const string totalCoinsPrefix = "Coins : ";

    private void Start()
    {
        
        MaxScore = GameObject.FindGameObjectWithTag("MaxScore").GetComponent<Text>();
        TotalScore = GameObject.FindGameObjectWithTag("TotalScore").GetComponent<Text>();
        TotalCoins = GameObject.FindGameObjectWithTag("TotalCoins").GetComponent<Text>();
       
        actualScore = PlayerPrefs.GetInt("Distance");
        maxScore = PlayerPrefs.GetInt("MaxScore");
        if (maxScore < actualScore)
        {
            maxScore = actualScore;
            PlayerPrefs.SetInt("MaxScore", maxScore);
        }
        totalCoins = PlayerPrefs.GetInt("Score");
        
        MaxScore.text = maxScorePrefix + maxScore.ToString();
        TotalScore.text = scorePrefix + actualScore.ToString();
        TotalCoins.text = totalCoinsPrefix + totalCoins.ToString();

    }

}
