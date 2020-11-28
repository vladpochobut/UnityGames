using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovementTableController : MonoBehaviour
{
    Object payMenu;

    void Start()
    {
        EventManager.current.onImprovementTableTriggerEnter += OnImprovementTableEnter;
        EventManager.current.onImprovementTableTriggerExit += OnImprovementTableExit;
    }

    private void OnImprovementTableEnter()
    {
        if (payMenu == null)
        {
            payMenu = Object.Instantiate(Resources.Load("ImprovementTable"));
        }
    }

    private void OnImprovementTableExit()
    {
        Destroy(payMenu);
    }
    private void OnDestroy()
    {
        EventManager.current.onImprovementTableTriggerEnter -= OnImprovementTableEnter;
        EventManager.current.onImprovementTableTriggerExit -= OnImprovementTableExit;
    }
}
