using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HUDUp : MonoBehaviour
{
    [SerializeField]
    private Text updatePrice;
    private float price = 2;
    private const string updatePricePrefix = "PRICE:";

    [SerializeField]
    private Text currentDamage;
    private const string currentDamagePrefix = "DAMAGE:";
    private float damage = 2;

    private float currentMoney;

    private void Start()
    {
        //PlayerPrefs.DeleteKey("Damage");
        //PlayerPrefs.DeleteKey("Price");
        price = PlayerPrefs.GetFloat("Price", 2);
        damage = PlayerPrefs.GetFloat("Damage", damage);
        updatePrice.text = updatePricePrefix + IntReduse(price);
        currentDamage.text = currentDamagePrefix + IntReduse(damage);
    }

    private string IntReduse(float price)
    {
        if (price >= 1000 && price < 1000000)
            return (price / 1000).ToString("0.00") + "K";
        else if (price >= 1000000 && price < 1000000000)
            return (price / 1000000).ToString("0.00") + "M";
        else if(price >=1000000000 )
            return (price / 1000000000).ToString("0.00") + "B";
        else
            return price.ToString();
            
    }
    private void AddPrice()
    {
        if (price < 1000000000000)
        {
           price *= 2f;
           PlayerPrefs.SetFloat("Price", price);
           EventManager.current.UpDamage();
        }
        else 
        {
            price = price;
        }

        updatePrice.text = updatePricePrefix + IntReduse(price);
    }
    private void HudDamageChenge()
    {
        AddPrice();
        damage = PlayerPrefs.GetFloat("Damage",damage);
        currentDamage.text = currentDamagePrefix + IntReduse(damage);
    }
    public void onGunUppdate()
    {
        currentMoney = PlayerPrefs.GetFloat("Money");
        if (currentMoney >= price)
        {
            currentMoney -= price;
            PlayerPrefs.SetFloat("Money", currentMoney);
            EventManager.current.MoneyAmountChenge();
            HudDamageChenge();
        }
        else { Debug.Log("Don't have enough money"); }
    
    }






}
