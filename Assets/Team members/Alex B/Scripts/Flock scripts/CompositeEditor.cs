using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEditor;
using UnityEngine;

namespace AJ
{
    [CustomEditor(typeof(CompositeBehavior))]
    public class CompositeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //setup
            CompositeBehavior cb = (CompositeBehavior) target;
            Rect r = EditorGUILayout.BeginHorizontal();
            r.height = EditorGUIUtility.singleLineHeight;
            if (cb.behaviors == null || cb.behaviors.Length == 0)
            {
                EditorGUILayout.HelpBox("No behaviours in array.", MessageType.Warning);
                EditorGUILayout.EndHorizontal();
                r = EditorGUILayout.BeginHorizontal();
                r.height = EditorGUIUtility.singleLineHeight;

            }
            else
            {
                r.x = 30f;
                
            }
        }
    }
}

