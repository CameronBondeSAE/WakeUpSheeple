using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Health>().Damage(1000);
    }
}
