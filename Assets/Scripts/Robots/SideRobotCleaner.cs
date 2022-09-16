using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class SideRobotCleaner : Robot
{
    [SerializeField]
    private Cone rightVacuum;

    [SerializeField]
    private Cone leftVacuum;

    private void OnEnable()
    {
        rightVacuum.OnCollideDust += base.Clean;
        leftVacuum.OnCollideDust += base.Clean;
    }

    private void OnDisable()
    {
        rightVacuum.OnCollideDust -= base.Clean;
        leftVacuum.OnCollideDust -= base.Clean;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckSides(true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CheckSides(false);
        }

        base.Rotate();
    }

    void FixedUpdate()
    {
        // Called here because it uses Physics
        Move();
    }

    public override void Move()
    {
        base.Move();
    }

    void CheckSides(bool check)
    {
        rightVacuum.GetComponent<BoxCollider>().enabled = check;
        leftVacuum.GetComponent<BoxCollider>().enabled = check;
    }
}
