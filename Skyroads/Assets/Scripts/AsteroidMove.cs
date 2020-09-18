﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour,IPooledObject
{
    public void OnObjectSpawn()
    {
        transform.position =  transform.position;
    }
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
