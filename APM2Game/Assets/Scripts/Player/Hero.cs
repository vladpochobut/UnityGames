using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
   protected abstract void AttackTypeLogic();
   protected abstract void UpDamage();
   protected abstract void Inventory(Treetypes type);
    
}
