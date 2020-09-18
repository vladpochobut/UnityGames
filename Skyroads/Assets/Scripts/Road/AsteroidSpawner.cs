using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _asteroid;

   
    private int _spawnChance = 15;
    private float _elapsedSec = 0;
    public List<GameObject> _roadList;

    private BoxCollider _boxCollider;


    public void Start()
    {
        SpawnWithChance();
    }
    private void Update()
    {
        _elapsedSec += Time.deltaTime; 
        if (_spawnChance < 60)
        {
            if (_elapsedSec >= 6)
            {
                _elapsedSec = 0;
                _spawnChance++;
            }
        }
        else
            _spawnChance = 60;
    }



    public GameObject SpawnWithChance()
    {
        int i = Random.Range(0, 100);
        if (i > 0 && i < _spawnChance)
        {
            return Instantiate(_asteroid, transform.position, Quaternion.identity);
        }
        else
            return null;
    }

}
