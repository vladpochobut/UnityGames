using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class RayShooter : MonoBehaviour
{
    public float damage = 100f;
    public float range = 100f;
    public GameObject shadow;
    public Camera _camera;
    public UnityEvent<Vector3,Vector3,Type> afterSpellShort;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.Q))
        {
            ShootShortShadow();
        }
        else if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.E))
        {
            ShootMediumShadow();
        }
        else if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.R))
        {
            ShootLargeShadow();
        }
    }

    void ShootShortShadow()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range)) 
        {
            afterSpellShort.Invoke(hit.point,hit.normal,typeof(ShadowShort));  
            
        }
        
    }
    void ShootMediumShadow()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
        {
            //afterSpellMedium.Invoke(hit.point, hit.normal);
            afterSpellShort.Invoke(hit.point, hit.normal, typeof(ShadowMedium));
        }
        
    }

    void ShootLargeShadow()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
        {
            //afterSpellLarge.Invoke(hit.point, hit.normal);
            afterSpellShort.Invoke(hit.point, hit.normal, typeof(ShadowLarge));
        }
    }

   
}

public enum Spells
{
    Short,
    Medium,
    Large
}
  
