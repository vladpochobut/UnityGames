using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnManager : MonoBehaviour
{
    private RoadSpawner _roadSpawner;

    void Start()
    {
        _roadSpawner = GetComponent<RoadSpawner>();
    }

    public void SpawnTriggerEntered()
    {
        _roadSpawner.MoveRoad();
    }
}
