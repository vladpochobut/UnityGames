using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _asteroid;

    [SerializeField]
    private int _minSpawnChance = 15;
    [SerializeField]
    private int _maxSpawnChance = 60;
    [SerializeField]
    private int _complicityIncreaseRate = 6;

    private float _elapsedSec = 0;
    //public List<GameObject> _roadList;


    public void Start()
    {
        SpawnWithChance();
    }
    private void Update()
    {
        _elapsedSec += Time.deltaTime; 
        if (_minSpawnChance < _maxSpawnChance)
        {
            if (_elapsedSec >= _complicityIncreaseRate)
            {
                _elapsedSec = 0;
                _minSpawnChance++;
            }
        }
        else
            _minSpawnChance = _maxSpawnChance;
    }



    public GameObject SpawnWithChance()
    {
        int i = Random.Range(0, 100);
        if (i > 0 && i < _minSpawnChance)
        {
            return Instantiate(_asteroid, transform.position, Quaternion.identity);
        }
        else
            return null;
    }

}
