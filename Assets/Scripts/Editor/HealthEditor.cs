﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Health))]
public class HealthEditor : Editor
{

    public override void OnInspectorGUI()
        {
             DrawDefaultInspector();
             
            if (GUILayout.Button("Instant Death"))
            {
              ((Health) target)?.Death();
            }

           
        }
}
