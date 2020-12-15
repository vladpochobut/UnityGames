using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shadow : MonoBehaviour
{
    [SerializeField]
    protected Spells Spell; 

    public void Create(Vector3 hitPoint, Vector3 hitNormal, Type shadowType)
    {
        if (GetType().Equals(shadowType))
        {
            GameObject shadowObject = Instantiate(gameObject, hitPoint, Quaternion.LookRotation(hitNormal));
        }
    }

    protected void LifeTime(float _speed,float _destroyTime)
    {
        transform.position += new Vector3(-_speed * Time.deltaTime, 0f, 0f);
        Destroy(gameObject, _destroyTime);

    }

}
