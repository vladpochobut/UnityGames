using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    private Vector3 currentPosition = new Vector3(0, 0, 0);

    [SerializeField]
    private List<TerrainData> terrainDatas = new List<TerrainData>();

    [SerializeField]
    private int maxCountOfTrains;
    private List<GameObject> currentTerrains = new List<GameObject>();

    bool startBlock = true;
    
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < maxCountOfTrains; i++)
        {
            SpawnTrain(true);
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && Player.isItMove == true) 
        {
            SpawnTrain(false);

        }
    }

    private void SpawnTrain(bool isitStart)
    {
        int randTerrain = RandomTerrainType();
        int terrainSeccession = Random.Range(1, terrainDatas[randTerrain].maxInSuccession);
        if (startBlock == true)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject firstTerrain = Instantiate(terrainDatas[1].randTerrains[Random.Range(0, terrainDatas[randTerrain].randTerrains.Count)], currentPosition, Quaternion.identity);
                currentTerrains.Add(firstTerrain);
                currentPosition.x++;
            }
                startBlock = false;
        }

        for (int i = 0; i < terrainSeccession ; i++) 
        {
            GameObject terrain = Instantiate(terrainDatas[randTerrain].randTerrains[Random.Range(0,terrainDatas[randTerrain].randTerrains.Count)], currentPosition, Quaternion.identity);
                currentTerrains.Add(terrain);
            
            if (!isitStart)
            {
                if (currentTerrains.Count > maxCountOfTrains+1)
                {
                    Destroy(currentTerrains[0]);
                    currentTerrains.RemoveAt(0);
                }
            }
            currentPosition.x++;
        }
       
    }
    int RandomTerrainType()
    {
        int i = Random.Range(0, 100);
        if (i > 0 && i < 40)
        {
            return 0;
        }
        if (i > 40 && i < 80)
        {
            return 1;
        }
        else 
        {
            return 2;
        }
    }

}
