using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace John
{   
public class LearningButton : MonoBehaviour
{
    public string buttonText;
    public event Action DoButton;
    
    public void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 3, 200, 100), buttonText))
        {
            DoButton?.Invoke();
        }
    }
}
}
