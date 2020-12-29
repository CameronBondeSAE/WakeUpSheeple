using System;
using System.Collections;
using System.Collections.Generic;
using John;
using UnityEngine;
using Random = UnityEngine.Random;
using NodeCanvas.Tasks.Actions;

public class ColourButton : MonoBehaviour
{
    private Renderer cubeRenderer;
    private bool isBlue;
    
    void Start()
    {
        FindObjectOfType<LearningButton>().DoButton += colourSwap;
        cubeRenderer = gameObject.GetComponent<Renderer>();
        isBlue = false;
    }

    void colourSwap()
    {
        if (isBlue == false)
        {
            cubeRenderer.material.color = Color.blue;
            isBlue = true;
        }
        else
        {
            SetRed();
        }
    }
    
    void SetRed()
    {
        cubeRenderer.material.color = Color.red;
        isBlue = false;
    }
    private void OnDisable()
    {
        FindObjectOfType<buttonHandler>().buttonEvent -= colourSwap;
    }
}
