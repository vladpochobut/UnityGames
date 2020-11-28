using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class HUDGameplay : MonoBehaviour
{
    [SerializeField]
    private Text moneyField;
    private float money = 0;
    private const string moneyPrefix = "Money :";

    [SerializeField]
    private Text TreesInfo;
    Hashtable actualCountOfTrees = new Hashtable();
    StringBuilder sb = new StringBuilder();

    private void Start()
    {
        EventManager.current.onSellTrees += onSellTrees;
        EventManager.current.onTreeDestroy += AmountTreesInInventory;
        EventManager.current.onMoneyAmountChenge += AmountMoneyRefresher;
        money = PlayerPrefs.GetFloat("Money", 0);
        moneyField.text = moneyPrefix + money.ToString();
    }

    public void AmountMoneyRefresher()
    {
        money = PlayerPrefs.GetFloat("Money");
        moneyField.text = moneyPrefix + money.ToString();
    }

    private void AmountTreesInInventory(Treetypes type)
    {
        if (actualCountOfTrees.ContainsKey(type))
        {
            int a = (int)actualCountOfTrees[type];
            a++;
            actualCountOfTrees.Remove(type);
            actualCountOfTrees.Add(type, a);
        }
        else
        {
            actualCountOfTrees.Add(type, 1);
        }
        foreach (DictionaryEntry entry in actualCountOfTrees)
        {
            sb.Append(entry.Key + " " + entry.Value + Environment.NewLine);
        }
        TreesInfo.text = sb.ToString();
        sb.Clear();
    }

    private void onSellTrees()
    {
        actualCountOfTrees.Clear();
        TreesInfo.text = sb.ToString();
    }



}
