using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AlexM
{
    [CustomEditor(typeof(WorldScanner))]
    public class WorldScannerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            EditorGUILayout.LabelField(" ");
            EditorGUILayout.LabelField("Tools", EditorStyles.boldLabel);
            
            GUILayout.BeginHorizontal();
            
            if (GUILayout.Button("Draw the Grid"))
            {
                ((WorldScanner)target).DrawGrid();
            }
            
            GUILayout.EndHorizontal();
        }
    }

}