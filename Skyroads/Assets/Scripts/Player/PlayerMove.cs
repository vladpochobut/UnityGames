using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private SmoothFollow _smoothFollow;

    public UnityEvent BoostScore;
    public UnityEvent Score;
    private CharacterController _characterController;
    private Vector3 _direcction;
    public float _forwardSpeed = 5f;
    private Animator _animator;
    private int _laneNumber = 1;
    private int _laneCount = 2;
    private float _startSpeed;
    private float _boostSpeed ;

    [SerializeField]
    private int _accelerationFactor = 2;
    public float _firstLanePos, _laneDistance, _sideSpeed;

    private void Start()
    {
        _startSpeed = _forwardSpeed;
        _boostSpeed = _forwardSpeed * _accelerationFactor;
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _direcction.z = _forwardSpeed;
        _characterController.Move(_direcction * Time.deltaTime);
        Score.Invoke();
        InputControl();
        Vector3 _newPosition = transform.position;
            _newPosition.x = Mathf.Lerp(_newPosition.x, _firstLanePos + (_laneNumber + _laneDistance), Time.deltaTime * _sideSpeed);
            transform.position = _newPosition;
    }

    private void InputControl()
    {
        int _sign = 0;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _sign = -1;
            StartCoroutine(DoLeft());
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _sign = 1;
            StartCoroutine(DoRigth()); 
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            BoostScore.Invoke();
            StartCoroutine(DoBoost());
        }
        else
        {
            _forwardSpeed = _startSpeed;
            return;
        }
        _laneNumber += _sign;
        _laneNumber = Mathf.Clamp(_laneNumber, 0, _laneCount);
    }

    IEnumerator DoRigth()
    {
        _animator.SetBool("turningRigth", true);
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("turningRigth", false);
    }

    IEnumerator DoLeft()
    {
        _animator.SetBool("turningLeft", true);
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("turningLeft", false);
    }

    IEnumerator DoBoost()
    {  
        _smoothFollow.distance = Mathf.Lerp(_smoothFollow.distance, 1, Time.deltaTime  );
        _forwardSpeed = _boostSpeed;
        yield return new WaitForSeconds(1f);
        _smoothFollow.distance = Mathf.Lerp(_smoothFollow.distance, 2, Time.deltaTime  );
    }
}
