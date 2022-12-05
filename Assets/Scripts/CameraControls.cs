using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float sensitivity = 1.0f;

    private Vector2 mouseAbsolute;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        //Change this value to change which direction you start facing
        //mouseAbsolute.x = 180.0f;
    }

    void Update()
    {
        Vector3 forward = transform.forward;
        forward.y = 0.0f;
        forward.Normalize();
        forward = forward * Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        Vector3 right = transform.right * Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

        transform.position += forward + right;

        //Difference between the mouse location last frame and the mouse location of this frame
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //Mouse Sensitivity
        mouseDelta *= sensitivity;
        mouseAbsolute += mouseDelta;

        //Clamp the camera
        mouseAbsolute.y = Mathf.Clamp(mouseAbsolute.y, -89.9f, 89.9f);

        transform.localRotation = Quaternion.AngleAxis(-mouseAbsolute.y, Vector3.right);

        //Rotating around the worlds y axis
        Quaternion yRotation = Quaternion.AngleAxis(mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
        transform.localRotation *= yRotation;
    }
}
