﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarHandlerR : MonoBehaviour
{
    public UnityEvent DeleteEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    private void OnTriggerEnter(Collider other)
    {
        DeleteEvent.Invoke();
    }
}
