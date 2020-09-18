using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnManager : MonoBehaviour
{
    private RoadSpawner _roadSpawner;

    // Start is called before the first frame update
    void Start()
    {
        _roadSpawner = GetComponent<RoadSpawner>();
    }

    public void SpawnTriggerEntered()
    {
        _roadSpawner.MoveRoad();
    
    }
}
