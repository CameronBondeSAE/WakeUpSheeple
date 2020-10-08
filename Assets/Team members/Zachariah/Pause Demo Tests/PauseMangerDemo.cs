using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMangerDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public event Action PauseTest;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseTest?.Invoke();
        }

    }
}