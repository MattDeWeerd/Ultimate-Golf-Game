using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    public Rigidbody ballRigidBody;
    public GameObject arrow;
    public float Force;
    public Transform CameraTransform;
    public Transform arrowTransform;
    public AudioSource swing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CameraPosition = CameraTransform.position;
        Vector3 forwardShootingDirection = transform.position - CameraPosition;

        forwardShootingDirection.y = 0.0f;
        forwardShootingDirection.Normalize();

        //Setting the arrows positon
        arrowTransform.position = transform.position + forwardShootingDirection * 0.3f;

        float angle = Mathf.Atan2(forwardShootingDirection.z, forwardShootingDirection.x) * Mathf.Rad2Deg;
        arrowTransform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
        arrowTransform.Rotate(new Vector3(90.0f, 90.0f, 0.0f));
        ForceWriter.setForce(Force);
        if (Input.GetKey(KeyCode.Space))
        {
            Force += 10;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StrokeCounter.increaseStrokes();
            ballRigidBody.AddForce(forwardShootingDirection * Force);
            Force = 0;
            ForceWriter.resetForce();
            swing.Play();
        }

        if (ballRigidBody.velocity.magnitude <= 0.05)
        {
            arrow.SetActive(true);
        } else
        {
            arrow.SetActive(false);
        }
    }
}
