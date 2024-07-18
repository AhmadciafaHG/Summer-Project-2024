using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraControls : MonoBehaviour
{
    public Transform target; // The transform the camera will follow; ASSIGN IN EDITOR
    public Vector3 posOffset; // The offset to set how far the camera should be from the target; EDIT IN EDITOR
    public float rotationSpeed = 5.0f; // Speed of camera rotation
    public float distance = 2.0f; // Distance between the camera and the target
    public float height = 2.0f; // Height offset of the camera from the target
    private float yaw = 0.0f; // Yaw rotation value
    private float pitch = 0.0f; // Pitch rotation value
    void Start()
    {
        if (target != null)
        {
            // Initialize yaw and pitch based on the current rotation of the camera
            yaw = transform.eulerAngles.y;
            pitch = transform.eulerAngles.x;
        }
    }
    void LateUpdate()
    {
        if (target == null) return;
        // Camera rotation controlled by mouse movement
        yaw += rotationSpeed * Input.GetAxis("Mouse X");
        pitch -= rotationSpeed * Input.GetAxis("Mouse Y");
        // Clamp the pitch to prevent flipping the camera
        pitch = Mathf.Clamp(pitch, -45f, 45f);
        // Calculate the desired position based on the target's position, distance, height, and current yaw and pitch
        Vector3 offset = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 position = target.position + rotation * offset;
        // Update the camera's position and rotation
        transform.position = position;
        transform.LookAt(target.position + new Vector3(0, height, 0));
        // Rotate the target to match the camera's yaw rotation
        target.rotation = Quaternion.Euler(0, yaw, 0);
    }
}