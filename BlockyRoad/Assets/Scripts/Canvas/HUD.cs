using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    static Text Score;
    static int actualScore;
    
    const string scorePrefix = "Coins : ";

    static Text Distance;
    static int actualDistance ;
    static int totalDistance;
    const string distancePrefix = "Distace : ";


    void Start()
    {
        
        actualScore = PlayerPrefs.GetInt("Score");
        Score = GameObject.FindGameObjectWithTag("Coins").GetComponent<Text>();
        Distance = GameObject.FindGameObjectWithTag("Distance").GetComponent<Text>();

    }
    private void Update()
    {
        PlayerPrefs.SetInt("Score", actualScore);
        PlayerPrefs.SetInt("Distance", actualDistance);
    }
    static public void AddCoins()
    {
        actualScore++;
        Score.text = scorePrefix + actualScore.ToString();
        
    }

    static public void AddDistance()
    {
        actualDistance++;
        Distance.text = distancePrefix + actualDistance.ToString();
    }

    static public void ResetDistance()
    {
        actualDistance = 0;

    }

   

       
}
