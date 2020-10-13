using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEditor;
using UnityEngine;
/*                                                         MIGHT USE LATER CURRENTLY NOT WORKING
namespace AJ
{
    [CustomEditor(typeof(CompositeBehavior))]
    public class CompositeBehaviorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //setup
            CompositeBehavior cb = (CompositeBehavior) target;
                
            Rect r = EditorGUILayout.BeginHorizontal();
            r.height = EditorGUIUtility.singleLineHeight;
            
            //Check for behaviours
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
                r.width = EditorGUIUtility.currentViewWidth - 95f;
                EditorGUI.LabelField(r, "Behaviors");
                r.x = EditorGUIUtility.currentViewWidth - 65f;
                r.width = 60f;
                EditorGUI.LabelField(r,"Weights");
                r.y += EditorGUIUtility.singleLineHeight * 1.2f;

                for (int i = 0; i < cb.behaviors.Length; i++)
                {
                    r.x = 5f;
                    r.width = 20f;
                    EditorGUI.LabelField(r, i.ToString());
                    r.x = 30f;
                    r.width = EditorGUIUtility.currentViewWidth - 95f;
                    cb.behaviors[i] = (FlockBehavior)EditorGUI.ObjectField(r, cb.behaviors[i], typeof(FlockBehavior), false);
                    r.x = EditorGUIUtility.currentViewWidth - 65f;
                    r.width = 60f;
                    cb.weights[i] = EditorGUI.FloatField(r, cb.weights[i]);
                    r.y += EditorGUIUtility.singleLineHeight * 1.1f;
                }
            }
        }
    }
}*/

