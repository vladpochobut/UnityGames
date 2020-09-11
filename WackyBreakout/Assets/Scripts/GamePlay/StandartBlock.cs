using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBlock : Block
{
    [SerializeField]
    Sprite prefabBlue;
    [SerializeField]
    Sprite prefabOrange;
    [SerializeField]
    Sprite prefabPurple;


    // Start is called before the first frame update
    void Start()
    {
        int standartPoints = ConfigurationUtils.PointsForCommonBlock;
        SpriteRender();
        bonusCoins = ConfigurationUtils.PointsForCommonBlock;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpriteRender()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber < 1)
        {
            spriteRenderer.sprite = prefabBlue;
        }
        else if (spriteNumber < 2)
        {
            spriteRenderer.sprite = prefabOrange;
        }
        else
        {
            spriteRenderer.sprite = prefabPurple;
        }

    }

}
