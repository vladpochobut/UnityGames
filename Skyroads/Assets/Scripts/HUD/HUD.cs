using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private Text _score;
    static float _actualScore = 0;
    [SerializeField]
    private Text _asteroidsPassed;
    const string _asteroidsPrefix = "Asteroids Passed  : ";
    static int _actualPassed;
    [SerializeField]
    private Text _maxScore;
    static float _actualMaxScore;
    const string _maxScorePrefix = "Max : ";

    private void Start()
    {
        _actualScore = 0;
        _actualPassed = 0;
        _actualMaxScore = PlayerPrefs.GetFloat("MaxScore");
        _maxScore.text = _maxScorePrefix + _actualMaxScore.ToString("0");
    }
    private void Update()
    {

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
        PlayerPrefs.SetFloat("Score", _actualScore);

    }
    public void AddBootScore()
    {
        _actualScore += Time.deltaTime;
    }
    public void AddAsteroidsPassed()
    {
        _actualPassed += 1;
        _asteroidsPassed.text =_asteroidsPrefix + _actualPassed.ToString();
        PlayerPrefs.SetInt("PassedAsteroids", _actualPassed);
    }

    public void ActualMaxScore()
    {
        _actualMaxScore = _actualScore;
        _maxScore.text = _maxScorePrefix + _actualMaxScore.ToString("0");

    }


}
