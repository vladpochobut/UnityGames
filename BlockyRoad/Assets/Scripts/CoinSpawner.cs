using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform spawnZone;
    [SerializeField]
    private GameObject bonusObject;

    float minX;
    float maxX;
    float minZ;
    float maxZ;

    int randomNumber;

    void Start()
    {
        maxX = spawnZone.position.x + spawnZone.localScale.x / 2;
        minX = spawnZone.position.x - spawnZone.localScale.x / 2;

        maxZ = spawnZone.position.z + spawnZone.localScale.z / 2;
        minZ = spawnZone.position.z - spawnZone.localScale.z / 2;

        randomNumber = Random.Range(0, 100);
        if (randomNumber > 0 && randomNumber < ConfigurationData.COIN_SPAWN_PERCENTAGE)
        {
            SpawnBonus();
        }

    }

    
    void SpawnBonus()
    {
        Vector3 spawnPos = new Vector3(Random.Range(minX,maxX),-1,Random.Range(minZ,maxZ));
        Instantiate(bonusObject, spawnPos, Quaternion.identity);
    }

    
}
