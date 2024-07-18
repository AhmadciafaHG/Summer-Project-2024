using UnityEngine;
public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation in degrees per second
    public Transform cameraTransform; // Reference to the camera's transform
    public float cameraFollowSpeed = 5f; // Speed at which the camera follows behind the player
    public Vector3 cameraOffset; // Offset from the player to the camera
    void Update()
    {
        // Get horizontal input (A/D keys or left/right arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");
        // Calculate rotation amount based on input and speed
        float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
        // Rotate the player around the y-axis
        transform.Rotate(Vector3.up, rotationAmount);
        // Rotate the camera around the y-axis (if it exists)
        if (cameraTransform != null)
        {
            cameraTransform.Rotate(Vector3.up, rotationAmount);
            // Calculate the desired position of the camera
            Vector3 desiredPosition = transform.position + transform.TransformDirection(cameraOffset);
            // Smoothly move the camera towards the desired position
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, desiredPosition, cameraFollowSpeed * Time.deltaTime);
            // Make the camera look at the player character
            cameraTransform.LookAt(transform.position + transform.up);
        }
    }
}