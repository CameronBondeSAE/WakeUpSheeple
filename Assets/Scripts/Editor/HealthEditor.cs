using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Health))]
public class HealthEditor : Editor
{
    private Health h;
    
        public override void OnInspectorGUI()
        {
             DrawDefaultInspector();
             
            if (GUILayout.Button("Instant Death"))
            {
                h.Death();
            }

           
        }
}
