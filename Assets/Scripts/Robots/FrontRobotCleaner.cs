using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class FrontRobotCleaner : Robot
{
    [SerializeField]
    private Cone frontVacuum;

    private float multiplier = 3.0f;

    private void Start()
    {
        frontVacuum.OnCollideDust += base.Clean;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotationSpeed *= multiplier;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rotationSpeed /= multiplier;
        }
        base.Rotate();
    }

    void FixedUpdate()
    {
        // Called here because it uses Physics
        Move();
    }

    // POLYMORPHISM
    public override void Move()
    {
        CheckFront(true);
        base.Move();
    }

    void CheckFront(bool check)
    {
        frontVacuum.GetComponent<BoxCollider>().enabled = check;
    }
}
