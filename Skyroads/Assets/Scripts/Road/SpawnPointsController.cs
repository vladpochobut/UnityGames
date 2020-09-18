using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsController : MonoBehaviour
{
    private AsteroidSpawner _spawner;

    public void TriggerSpawnpoints()
    {
       for(int i = 0; i < gameObject.transform.GetChildCount();i++)
       {
            Transform _child = gameObject.transform.GetChild(i);
            _spawner = _child.gameObject.GetComponent<AsteroidSpawner>();
            _spawner.SpawnWithChance();
       }

    }
}
