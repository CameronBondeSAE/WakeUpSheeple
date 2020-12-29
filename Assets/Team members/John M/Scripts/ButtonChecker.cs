using System;
using System.Collections;
using System.Collections.Generic;
using John;
using UnityEngine;
using Random = UnityEngine.Random;
using NodeCanvas.Tasks.Actions;



public class ButtonChecker : MonoBehaviour
{
    
    private Vector3 scaleChange, positionChange;
    
    void Start()
    {
        FindObjectOfType<LearningButton>().DoButton += resize;
    }

    public void Update()
    {
        scaleChange = new Vector3((Random.Range(1,4)),(Random.Range(1,4)),(Random.Range(1,4)));
    }

    private void resize()
    {
        this.transform.localScale = scaleChange;
    }
}
