using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestroyByBoundery : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && Player.isItMove == true)
        {

            gameObject.transform.position = new Vector3(transform.position.x + 1, 0, 0);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

}
