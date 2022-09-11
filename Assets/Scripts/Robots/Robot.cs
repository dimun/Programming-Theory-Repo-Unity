using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Move();
        Clean();
    }

    public virtual void Move()
    {

    }

    public virtual void Clean()
    {

    }
}
