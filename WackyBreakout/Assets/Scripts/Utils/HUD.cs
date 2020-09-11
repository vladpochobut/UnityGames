using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    static Text Score;
    static int actualScore ;
    const string ScorePrefix = "Score : ";
    const string BallsLeftPrefix = "Balls left : ";
    static Text BallsLeft;
    static int actualBallsLeft = 10;
    // Start is called before the first frame update
    void Start()
    {
        Score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        BallsLeft = GameObject.FindGameObjectWithTag("Left").GetComponent<Text>();
    }


    static public void MinusBall()
    {
        actualBallsLeft--;
        BallsLeft.text = BallsLeftPrefix + actualBallsLeft.ToString();
    }
    static public void AddScore(int points) 
    {
        actualScore += points;
        Score.text = ScorePrefix + actualScore.ToString();
    }
}
