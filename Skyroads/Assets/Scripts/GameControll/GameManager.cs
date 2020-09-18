using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _gameHasEntered = false;
    public float _restartdelay = 1f;
    public GameObject _deadUI;

    public void EndGame()
    {
        if (_gameHasEntered == false)
        {
            _gameHasEntered = true;
            _deadUI.SetActive(true);
        }
    }

 
}
