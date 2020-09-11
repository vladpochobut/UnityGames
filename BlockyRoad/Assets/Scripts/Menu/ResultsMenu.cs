using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsMenu : MonoBehaviour
{
    void Start()
    {

        Time.timeScale = 0;
    }

    public void HandleQuitButtonOnClickEvent()
    {
        BlockyRoad.isitActive = false;
        Time.timeScale = 1;
        MenuManager.GoToMenu(MenuName.Main);

    }
}
