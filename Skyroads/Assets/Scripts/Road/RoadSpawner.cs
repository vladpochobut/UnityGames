using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Road> _roads;


    private float _offset = 16f;

    // Start is called before the first frame update
    void Start()
    {
        if (_roads != null && _roads.Count > 0)
        {
            _roads = _roads.OrderBy(r => r.transform.position.z).ToList();

        }


    }

    public void MoveRoad()
    {
        Road _moveRoad = _roads[0];
        _roads.Remove(_moveRoad);
        float _newZ = _roads[_roads.Count - 1].transform.position.z + _offset;
        _moveRoad.transform.position = new Vector3(0, 0, _newZ);
        _roads.Add(_moveRoad);
        _moveRoad.SpawnPointsController.TriggerSpawnpoints();
       


    }

  

}
   
