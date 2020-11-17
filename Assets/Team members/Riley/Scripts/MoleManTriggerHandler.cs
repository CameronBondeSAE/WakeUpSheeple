using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManTriggerHandler : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("platformR"))
        {
            Debug.Log("Collision Detected");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("platformR"))
        {
            Debug.Log("Collision Still Detected");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("platformR"))
        {
            Debug.Log("Collision Removed");
        }
    }
}
