using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    public event Action onImprovementTableTriggerEnter;

    public void ImprovementTabletriggerEnter()
    {
        if (onImprovementTableTriggerEnter != null)
        {
            onImprovementTableTriggerEnter();
        }
    }

    public event Action onImprovementTableTriggerExit;

    public void ImprovementTabletriggerExit()
    {
        if (onImprovementTableTriggerExit != null)
        {
            onImprovementTableTriggerExit();
        }

    }

    public event Action onUpDamage;

    public void UpDamage()
    {
        if (onUpDamage != null)
        {
            onUpDamage();
        }
    }

    public event Action<Treetypes> onTreeDestroy;

    public void TreeDestroy(Treetypes type)
    {
        if (onTreeDestroy != null)
        {
            onTreeDestroy(type);
        }
    }

    public event Action<Hashtable> onTraid;

    public void Traid(Hashtable a)
    {
        if (onTraid != null)
        {
            onTraid(a);
        }
    }

    public event Action onMoneyAmountChenge;

    public void MoneyAmountChenge()
    {
        if (onMoneyAmountChenge != null)
        {
            onMoneyAmountChenge();
        }
    }

    public event Action onSellTrees;

    public void SellTrees()
    {
        if (onSellTrees != null)
        {
            onSellTrees();
        }
    }

}
