using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SubscribedObject2 : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer objectRenderer;
    private bool colourBool;
    void Start()
    {
        FindObjectOfType<buttonHandler>().buttonEvent += changeColour;
        objectRenderer = gameObject.GetComponent<Renderer>();
        colourBool = false;
    }
    void changeColour()
    {
        if (colourBool == false)
        {
            objectRenderer.material.color = Color.red;
            colourBool = true;
        }
        else
        {
            otherColour();
        }
    }
    void otherColour()
    {
        objectRenderer.material.color = Color.green;
        colourBool = false;
    }
    private void OnDisable()
    {
        FindObjectOfType<buttonHandler>().buttonEvent -= changeColour;
    }
}
