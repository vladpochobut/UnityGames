using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _gameHasEntered = false;
    public GameObject DeadUI;
    public void RestartGame()
    {
        if (_gameHasEntered == false)
        {
            _gameHasEntered = true;
            DeadUI.SetActive(true);
        }
    }
}
