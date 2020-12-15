using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMedium : Shadow
{
   
    private float _speed = 4;
    private float _destroyTime = 3;
    Vector3 angleX ;

    private void Update()
    {
        LifeTime(_speed, _destroyTime);
    }

    private void OnDestroy()
    {
        RaycastHit hit;
        Ray downRay = new Ray(transform.position, Vector3.down);
        Ray rightRay = new Ray(transform.position, Vector3.forward);
        Ray upRay = new Ray(transform.position, Vector3.up);
        Ray leftRay = new Ray(transform.position, Vector3.back);
        if (!Physics.Raycast(downRay, out hit, 50f))
        {
            Debug.Log("ANGLE  = 0  , UP");
            angleX = new Vector3(0, 0, 0);
        }
        //else if (!Physics.Raycast(upRay, out hit, 50f))
        //{
        //    Debug.Log("ANGLE  = 180");
        //}
        else if (!Physics.Raycast(rightRay, out hit, 50f))
        {
            Debug.Log("ANGLE  = -90 , RIGHT");
            angleX = new Vector3(0, -90, 0);
        }
        else if (!Physics.Raycast(leftRay, out hit, 50f))
        {
            Debug.Log("ANGLE  = 90 , LEFT");
            angleX = new Vector3(0, 90, 0);
        }
        else
        {
            Debug.Log("CENTER");
        }
        print(angleX);
        GameObject prefab = Resources.Load("Tree") as GameObject;
        GameObject prem = Instantiate(prefab, transform.position, Quaternion.LookRotation(angleX));
        Destroy(prem, 1.5f);
    }

}
