using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AlexM
{
    [CustomEditor(typeof(Movement_TurningAM))]
    public class TurningEditor : Editor
    {
        private static float force = 0.3f;
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.LabelField(" ");
            EditorGUILayout.LabelField("Custom Debugger", EditorStyles.boldLabel);
            
            force = EditorGUILayout.FloatField("Turning Force:", force);
            
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Turn Right", GUILayout.Width(90)))
            {
                ((Movement_TurningAM)target).yForce = force;
            }
            
            if (GUILayout.Button("Stop Turning", GUILayout.Width(90)))
            {
                ((Movement_TurningAM)target).yForce = 0;
            }
            
            if (GUILayout.Button("Turn Left", GUILayout.Width(90)))
            {
                ((Movement_TurningAM)target).yForce = -force;
            }
            GUILayout.EndHorizontal();
        }
    }

}