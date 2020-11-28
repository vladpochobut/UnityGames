using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
           EventManager.current.Traid(other.GetComponent<PlayerLogic>().GetInventory());
        }
    }
}
