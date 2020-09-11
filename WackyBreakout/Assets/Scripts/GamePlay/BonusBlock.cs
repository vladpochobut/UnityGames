using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block
{
    // Start is called before the first frame update
    void Start()
    {
        bonusCoins = ConfigurationUtils.PointsForBonusBlock;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
