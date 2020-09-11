using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    public void HandlePlatButtonOnClickEvent()
    {
        SceneManager.LoadScene("Main");
    }

    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    
    }
}
