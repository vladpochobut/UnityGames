using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> cars = new List<GameObject>();

    [SerializeField]
    private bool isItRigth;

    [SerializeField]
    private int minTimeSpawn;
    [SerializeField]
    private int maxTimeSpawn;

    Timer spawnTimer;
    private void Start()
    {
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Randomither();
        spawnTimer.Run();
    }

    private void Update()
    {
        if (spawnTimer.Finished)
        {
            Spawn();
            spawnTimer.Duration = Randomither();
            spawnTimer.Run();
        }

    }
    private void Spawn()
    {
       int i = Random.Range(0, cars.Count);
       GameObject spawn = Instantiate(cars[i], transform.position, Quaternion.identity);
        if (!isItRigth)
        {
            spawn.transform.Rotate(new Vector3(0, 180, 0));
        }
        
    }

    int Randomither()
    {
        int i = Random.Range(minTimeSpawn, maxTimeSpawn);
        return i;
    }
}
