using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
   
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
        if (transform.position.y < -2f)
        {
            Destroy(gameObject);
        }
    }
}
