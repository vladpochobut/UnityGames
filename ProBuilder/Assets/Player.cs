using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 20f;

    private void FixedUpdate()
    {
        float _moveX = Input.GetAxis("Horizontal") * _speed * Time.fixedDeltaTime;
        float _moveZ = Input.GetAxis("Vertical") * _speed * Time.fixedDeltaTime;


        transform.Translate(_moveX, 0, _moveZ);
    }
}
