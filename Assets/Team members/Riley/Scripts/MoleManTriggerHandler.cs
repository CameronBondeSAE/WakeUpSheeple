using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManTriggerHandler : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(10);
        }
    }
}
