using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _gameHasEntered = false;
    [SerializeField]
    private float _restartdelay = 1f;
    public GameObject DeadUI;

    public void EndGame()
    {
        if (_gameHasEntered == false)
        {
            _gameHasEntered = true;
            DeadUI.SetActive(true);
        }
    }

 
}
