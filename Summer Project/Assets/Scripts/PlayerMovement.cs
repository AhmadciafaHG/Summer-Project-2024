using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 10f;
    private EnemyFollow enemy;
    public CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>(); // Get the CharacterController component attached to the player
        enemy = FindObjectOfType<EnemyFollow>();
    }
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Stores the Horizontal (Left & Right) input of the player
        float verticalInput = Input.GetAxis("Vertical"); // Stores the Vertical (Forward & Backward) input of the player

        Vector3 movement = new Vector3 (horizontalInput, 0f, verticalInput);
        movement = transform.TransformDirection (movement);
        movement *= movementSpeed;
        controller.Move(movement * Time.deltaTime);
    }
}
