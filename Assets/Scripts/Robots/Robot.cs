using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Robot : MonoBehaviour
{
    private Rigidbody robotRb;

    [SerializeField]
    protected float rotationSpeed = 30.0f;
    
    [SerializeField]
    protected float speed = 12.5f;

    [SerializeField]
    private float vacuumSpeed = 4.0f;

    public event Action OnCleanedDust;

    private void Awake()
    {
        robotRb = GetComponent<Rigidbody>();
        if (robotRb == null)
        {
            Debug.Log("Null RigidBody");
        }
    }

    // ABSTRACTION
    public virtual void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        robotRb.AddForce(transform.forward * verticalInput * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    // ABSTRACTION
    public virtual void Rotate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, rotationSpeed * horizontalInput * Time.deltaTime, 0);
    }

    // ABSTRACTION
    public virtual void Clean(GameObject dust)
    {
        StartCoroutine(MoveTowardsRobot(dust));
    }

    IEnumerator MoveTowardsRobot(GameObject dust)
    {
        while (Vector3.Distance(transform.position, dust.transform.position) > 0.001f)
        {
            float step = vacuumSpeed * Time.deltaTime; // calculate distance to move

            // Move our position a step closer to the target.
            dust.transform.position = Vector3.MoveTowards(dust.transform.position, transform.position, step);
            yield return new WaitForEndOfFrame();
        }
        Destroy(dust);
        OnCleanedDust();
        yield return null;
    }
}
