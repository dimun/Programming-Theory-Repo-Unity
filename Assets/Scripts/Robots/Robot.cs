using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private Rigidbody robotRb;
    public float rotationSpeed = 4.0f;
    public float speed = 13.0f;

    private void Start()
    {
        robotRb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    public virtual void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        robotRb.AddForce(transform.forward * verticalInput * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        transform.Rotate(0, rotationSpeed * horizontalInput, 0);
    }

    public virtual void Clean()
    {

    }
}
