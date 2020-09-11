using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{

    [SerializeField]
    GameObject prefabPaddle;
    [SerializeField]
    GameObject prefabBlock;
    [SerializeField]
    GameObject prefabBonusBlock;
    [SerializeField]
    GameObject prefabPickUpBlock;
    [SerializeField]
    GameObject prefabPickUpBlockS;




    const int numOfRows = 3;
    GameObject[] block;
    float[] xPositions;
    Vector2 blockLocation = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabPaddle);
        GameObject tempPrefabBlock = Instantiate(prefabPickUpBlock);
        BoxCollider2D collider = tempPrefabBlock.GetComponent<BoxCollider2D>();
        float blockColliderWidth = collider.size.x;
        float blockColliderHeight = collider.size.y;
        Destroy(tempPrefabBlock);

        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        float screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;
        int numOfBlocks = (int)(screenWidth / blockColliderWidth);
        float totalBlockWidth = numOfBlocks * blockColliderWidth;
        float firstX = ScreenUtils.ScreenLeft + (blockColliderWidth / 2);
        float firstY = ScreenUtils.ScreenTop - (screenHeight / 5);
        float leftBlockOffset = ScreenUtils.ScreenLeft +
                               (screenWidth - totalBlockWidth) / 2 +
                               blockColliderWidth / 2;
        block = new GameObject[numOfBlocks];
        xPositions = new float[numOfBlocks];
        blockLocation = new Vector2(leftBlockOffset, firstY);
        
        for (int rows = 0; rows < numOfRows; rows++)
        {
            int blockIndex = 0;
            for (int colloms = 0; colloms < numOfBlocks; colloms++)
            {

                block[blockIndex] = Instantiate(SpawnBlock(),
                        blockLocation, Quaternion.identity);
                xPositions[blockIndex] = blockLocation.x;
                blockLocation.x += blockColliderWidth;
                blockIndex++;

            }
            blockLocation.y -= blockColliderHeight;
            blockLocation.x = leftBlockOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject SpawnBlock() 
    {
        int i = Random.Range(0, 100);
        if (i > 0 && i < 70) 
        {
            return prefabBlock;
        }
        if (i > 70 && i < 90)
        {
            return prefabBonusBlock;
        }
        if (i > 90 && i < 95)
        {
            return prefabPickUpBlock;
        }
        else
            return prefabPickUpBlockS;
        ;
    }
   

}
