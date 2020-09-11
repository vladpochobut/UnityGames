using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHUD : MonoBehaviour
{
    static Text Coins;
    int totalCoins;
    const string totalCoinsPrefix = "Coins : ";
    // Start is called before the first frame update
    void Start()
    {
        Coins = GameObject.FindGameObjectWithTag("MenuResults").GetComponent<Text>();
        totalCoins = PlayerPrefs.GetInt("Score");
        Coins.text = totalCoinsPrefix + totalCoins.ToString();
    }

   
}
