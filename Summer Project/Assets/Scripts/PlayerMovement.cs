using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpHeight = 2.0f;  // Height the player will jump
    public float jumpForce = 30f;    // Increase this value to jump higher
    public float gravity = -9.81f;   // Gravity force
    public float swingSpeed = 10f;   // Speed of the swing
    public float swingRadius = 10f;  // Maximum distance to find a swing point
    public LayerMask swingLayer;     // Layer mask for swingable objects

    private float verticalVelocity;  // Vertical velocity for jump and gravity
    private bool isSwinging = false; // Check if the player is swinging
    private Vector3 swingPoint;      // The point where the player is swinging from
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>(); // Get the CharacterController component attached to the player
    }

    void FixedUpdate()
    {
        if (isSwinging)
        {
            Swing();
        }
        else
        {
            MoveAndJump();
        }
    }

    void MoveAndJump()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Stores the Horizontal (Left & Right) input of the player
        float verticalInput = Input.GetAxis("Vertical");     // Stores the Vertical (Forward & Backward) input of the player
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement = transform.TransformDirection(movement);
        movement *= movementSpeed;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f; // Small negative value to keep the player grounded
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime; // Apply gravity

            // Double jump to initiate swinging
            if (Input.GetButtonDown("Jump"))
            {
                AttemptSwing();
            }
        }

        movement.y = verticalVelocity;
        controller.Move(movement * Time.deltaTime);
    }

    void AttemptSwing()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, swingRadius, swingLayer))
        {
            swingPoint = hit.point;
            isSwinging = true;
        }
    }

    void Swing()
    {
        Vector3 swingDirection = swingPoint - transform.position;
        Vector3 swingForce = swingDirection.normalized * swingSpeed;
        controller.Move(swingForce * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            isSwinging = false;
        }
    }
}








