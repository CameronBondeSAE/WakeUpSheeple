using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonHandler : MonoBehaviour
{
    public event Action buttonEvent;
    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 20), "Event Button"))
        {
            buttonEvent?.Invoke();
        }
    }
}
