using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LukesSubsriber : MonoBehaviour
{
    public float force;
    public GameObject cube;

    private void OnEnable()
    {
        FindObjectOfType<PauseManager>().PauseEvent += OnPauseEvent;
    }

    private void OnDisable()
    {
        FindObjectOfType<PauseManager>().PauseEvent -= OnPauseEvent;
    }
    
    private void OnPauseEvent()
    {
        Debug.Log("luke's pause");
    }

    private void spin()
    { 
        transform.Rotate(0, force, 0);
    }

    void Update()
    {
        spin();
    }
}
