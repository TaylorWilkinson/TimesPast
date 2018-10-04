﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementClass : MonoBehaviour {


    [SerializeField]

    float moveSpeed = 5.0f;
    Vector3 forward, right, heading; //will dictate forward and right vectors that will differ from the world axes

    /*
     * Old Code
     * 
    public CharacterController characterController;

    public float speed = 6.0f;
    public float gravity = 20.0f;
    public float rotSpeed = 6.0f;

    private Vector3 moveDirection = Vector3.zero;
    */

    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0; //for clarity; ensures that y value is always set to 0
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;


        /*
         * Old Code
         * 
        characterController = GetComponent<CharacterController>();
        */
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }


        /*
         * Old Code
         * 
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)

        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
        */

    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        //rotation transformation
        transform.forward = heading;

        print("MOVEMENR"+rightMovement);
        //movement transformation
        transform.position += rightMovement;
        transform.position += upMovement;
    }
}
