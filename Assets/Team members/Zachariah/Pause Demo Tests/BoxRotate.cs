using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoxRotate : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void OnEnable()
    {
        FindObjectOfType<PauseMangerDemo>().PauseTest += PauseMangerDemoOnPauseTest;
    }

    private void OnDisable()
    {
        FindObjectOfType<PauseMangerDemo>().PauseTest -= PauseMangerDemoOnPauseTest;
    }

    private void PauseMangerDemoOnPauseTest()
    {
        Debug.Log("Pause");
        //Time.deltaTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime * 60f, Time.deltaTime * 35f, 0);
    }
}
