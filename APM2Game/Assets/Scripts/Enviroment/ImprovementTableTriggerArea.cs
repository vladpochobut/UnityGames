using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovementTableTriggerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EventManager.current.ImprovementTabletriggerEnter();
    }
    private void OnTriggerExit(Collider other)
    {
        EventManager.current.ImprovementTabletriggerExit();
    }
}
