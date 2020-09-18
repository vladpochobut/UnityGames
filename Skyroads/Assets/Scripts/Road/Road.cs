using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
   public SpawnPointsController SpawnPointsController;

    public void SpawnNewPoints()
    {
        SpawnPointsController.TriggerSpawnpoints();
    }
}
