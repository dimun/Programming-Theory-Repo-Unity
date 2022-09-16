using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cone : MonoBehaviour
{
    public event Action<GameObject> OnCollideDust;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dust"))
        {
            OnCollideDust(other.gameObject);
        }
    }
}
