using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AlexM
{
    [CustomEditor(typeof(AchievementManager))]
    public class AchievementEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            EditorGUILayout.LabelField(" ");
            EditorGUILayout.LabelField("Debugging", EditorStyles.boldLabel);

            GUILayout.BeginHorizontal();
            
            if (GUILayout.Button("ToggleTest", GUILayout.Width(80)))
            {
                ((AchievementManager) target).ToggleGameObjects();
            }

            if (GUILayout.Button("Quick Setup", GUILayout.Width(80)))
            {
                ((AchievementManager) target).QuickSetup();
            }

            GUILayout.EndHorizontal();
        }
    }

}