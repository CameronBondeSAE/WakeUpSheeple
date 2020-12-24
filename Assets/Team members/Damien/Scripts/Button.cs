using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damien

{
    public class Button : MonoBehaviour
    {
        public event Action actionButton;
        public string buttonText;

        public void OnGUI()
        {
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), buttonText))
            {
                actionButton?.Invoke();
            }
        }
    }
}