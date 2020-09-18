using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartHUD : MonoBehaviour
{
    [SerializeField]
    private Text _score;
    private static float _actualScore;
    private const string _scorePrefix = "Total Score : ";

    [SerializeField]
    private Text _asteroidsPassed;
    private const string _asteroidsPrefix = "Asteroids Passed : ";
    private static float _actualAsteroids;

    [SerializeField]
    private Text _maxScore;
    private static float _actualMaxScore;
    private const string _maxScorePrefix = "Max Score : ";

    [SerializeField]
    private Text _cong;
    private const string _congPrefix = "congratulations!!! new";

    private void Start()
    {
        _actualAsteroids = PlayerPrefs.GetInt("PassedAsteroids");
        _actualScore = PlayerPrefs.GetFloat("Score");
        _actualMaxScore = PlayerPrefs.GetFloat("MaxScore");
        if (_actualMaxScore < _actualScore)
        {
            _actualMaxScore = _actualScore;
            PlayerPrefs.SetFloat("MaxScore", _actualMaxScore);
            _cong.text = _congPrefix;
        }
        _maxScore.text = _maxScorePrefix + _actualMaxScore.ToString("0");
        _score.text = _scorePrefix + _actualScore.ToString("0");
        _asteroidsPassed.text = _asteroidsPrefix + _actualAsteroids.ToString("0");
    }   
}
