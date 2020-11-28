using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private float speed = 4f;
    [SerializeField]
    private float turnSmoothTime = 0.1f;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundDistance = 0.4f;
    [SerializeField]
    private LayerMask groundMask;
    [SerializeField]
    private float gravity = -9.81f;

    private Vector3 velosity;
    private bool isGrounded;

    private float turnSmoothVelosity;

    [SerializeField]
    private Joystick joystick;
    
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velosity.y < 0)
        {
            velosity.y = -2f;
        }

        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        velosity.y += gravity * Time.deltaTime;
        controller.Move(velosity * Time.deltaTime);
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,ref turnSmoothVelosity,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
            
        }
        animator.SetFloat("Speed", Mathf.Abs(direction.magnitude));
    }
}
