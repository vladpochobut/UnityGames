using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillIfCollision : MonoBehaviour
{
   

    private void OnCollisionEnter(Collision collision)
   {
        if (collision.collider.GetComponent<Player>() != null)
        {
            
            Destroy(collision.gameObject);
            MenuManager.GoToMenu(MenuName.Results);

        }
   }
}
