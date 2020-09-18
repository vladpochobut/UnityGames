using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    static Text _score;
    static float _actualScore = 0;

    static Text _asteroidsPassed;
    const string _asteroidsPrefix = "Asteroids Passed  : ";
    static int _actualPassed;

    static Text _maxScore;
    static float _actualMaxScore;
    const string _maxScorePrefix = "Max : ";

    private void Start()
    {
        _actualScore = 0;
        _actualPassed = 0;
        _score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        _asteroidsPassed = GameObject.FindGameObjectWithTag("PassedAsteroids").GetComponent<Text>();
        _maxScore = GameObject.FindGameObjectWithTag("MaxScorePlay").GetComponent<Text>();
        _actualMaxScore = PlayerPrefs.GetFloat("MaxScore");
        _maxScore.text = _maxScorePrefix + _actualMaxScore.ToString("0");
    }
    private void Update()
    {
        PlayerPrefs.SetFloat("Score", _actualScore);
        PlayerPrefs.SetInt("PassedAsteroids", _actualPassed);
        if (_actualScore > _actualMaxScore)
        {
            ActualMaxScore();
        }
        
    }
    public void AddScore(int _bonus)
    {
        _actualScore += Time.deltaTime;
        _actualScore += _bonus;
        _score.text = _actualScore.ToString("0");

    }
    public void AddBootScore()
    {
        _actualScore += Time.deltaTime;
    }
    public void AddAsteroidsPassed()
    {
        _actualPassed += 1;
        _asteroidsPassed.text =_asteroidsPrefix + _actualPassed.ToString();
    }

    public void ActualMaxScore()
    {
        _actualMaxScore = _actualScore;
        _maxScore.text = _maxScorePrefix + _actualMaxScore.ToString("0");

    }


}
