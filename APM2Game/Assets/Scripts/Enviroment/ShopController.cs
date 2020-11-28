using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopController : MonoBehaviour
{
    private Hashtable priceList = new Hashtable();
    private float money;
    // Start is called before the first frame update
    void Start()
    {
        money = PlayerPrefs.GetFloat("Money", 0);
        EventManager.current.onTraid += onTraid;
        priceList.Add(Treetypes.level1,5);
        priceList.Add(Treetypes.level2, 20);
        priceList.Add(Treetypes.level3, 40);

    }

    private void onTraid(Hashtable inventory)
    {
        foreach (DictionaryEntry entry in priceList)
        {
            if (inventory.ContainsKey(entry.Key))
            {
                money += (int)entry.Value * (int)inventory[entry.Key];
                inventory.Remove(entry.Key);
                inventory.Add(entry.Key, 0);
            }
        }
        PlayerPrefs.SetFloat("Money", money);
        EventManager.current.MoneyAmountChenge();
        EventManager.current.SellTrees();
    }
}
