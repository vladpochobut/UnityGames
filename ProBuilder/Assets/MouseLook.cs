using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float _mouseSensitivity = 100f;

    public Transform _playerBody;
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
        //print(" " + _mouseX + " " + _mouseY + "\n");
        //float _mouseZ = Input.GetAxis("Mouse Z") * _mouseSensitivity * Time.deltaTime;
        //_xRotation -= _mouseY;
       // _xRotation = Mathf.Clamp(_xRotation, -90, 90f);

        _playerBody.rotation = Quaternion.Euler(_playerBody.eulerAngles.x, _playerBody.eulerAngles.y, 0);
        _playerBody.Rotate(_mouseY, _mouseX, 0);
        

        //_playerBody.Rotate(_mouseX);
        //_playerBody.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

    }
}
