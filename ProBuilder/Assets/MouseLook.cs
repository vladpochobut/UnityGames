using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float _mouseSensitivity = 100f;

    public Transform PlayerBody;
    public Transform Target;

    private float _xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float _mouseY = -Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
        transform.position = Target.position;
        
        PlayerBody.rotation = Quaternion.Euler(PlayerBody.eulerAngles.x, PlayerBody.eulerAngles.y, 0);
        PlayerBody.Rotate(_mouseY, _mouseX, 0);
        Target.rotation = PlayerBody.rotation;
        

    }
}
