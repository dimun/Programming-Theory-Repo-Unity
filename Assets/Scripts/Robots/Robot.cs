using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private Rigidbody robotRb;
    public float rotationSpeed = 30.0f;
    public float speed = 12.5f;

    private void Start()
    {
        robotRb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Called here because it uses Physics
        Move();
    }

    private void Update()
    {
        Rotate();
    }

    public virtual void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        robotRb.AddForce(transform.forward * verticalInput * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    public virtual void Rotate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, rotationSpeed * horizontalInput * Time.deltaTime, 0);
    }

    public virtual void Clean()
    {

    }
}
