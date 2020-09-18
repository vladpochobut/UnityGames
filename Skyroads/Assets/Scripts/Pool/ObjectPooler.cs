using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int Size;
    }

    #region Singleton
    public static ObjectPooler Instance;

    private void Awake()
    {

        Instance = this;

        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool _pool in Pools)
        {
            Queue<GameObject> _objectPool = new Queue<GameObject>();
            for (int i = 0; i < _pool.Size; i++)
            {
                GameObject _object = Instantiate(_pool.Prefab);
                _object.SetActive(false);
                _objectPool.Enqueue(_object);
            }
            PoolDictionary.Add(_pool.Tag, _objectPool);
        }

    }
    #endregion

    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;
    
    public GameObject SpawnFromPool(string _tag,Vector3 _posotion,Quaternion _roration)
    {
        if (!PoolDictionary.ContainsKey(_tag))
        {
            Debug.LogWarning("Pool with tag" + _tag + "dosnt exist");
            return null;
        }
        GameObject _objectToSpawn = PoolDictionary[_tag].Dequeue();
        _objectToSpawn.SetActive(true);
        _objectToSpawn.transform.position = _posotion;
        _objectToSpawn.transform.rotation = _roration;

        IPooledObject _pooledObject = _objectToSpawn.GetComponent<IPooledObject>();
        if (_pooledObject != null)
        {
            _pooledObject.OnObjectSpawn();
        }
        PoolDictionary[_tag].Enqueue(_objectToSpawn);
        return _objectToSpawn;
    }
}
