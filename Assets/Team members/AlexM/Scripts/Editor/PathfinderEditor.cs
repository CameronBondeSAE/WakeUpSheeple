using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AlexM
{
    [CustomEditor(typeof(Pathfinder))]
    public class pathfinderEditor : Editor
    {
        //private static Vector2 moveToPos;
        private float x = 0, z = 0;
        
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            EditorGUILayout.LabelField(" ");
            EditorGUILayout.LabelField("Moving Debugger", EditorStyles.boldLabel);

            //moveToPos = EditorGUILayout.Vector2Field("Move to(X,Z): ", moveToPos);
            
            GUILayout.BeginHorizontal();
            
            if (GUILayout.Button("X+1"))
            {
                x = 1;
                ((Pathfinder)target).stepTo(x, 0);
            }
            if (GUILayout.Button("Y+1"))
            {
                z = 1;
                ((Pathfinder)target).stepTo(0, z);
            }
            GUILayout.EndHorizontal();
            
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("X-1"))
            {
                x = -1;
                ((Pathfinder)target).stepTo(x, 0);
            }

            if (GUILayout.Button("Y-1"))
            {
                z = -1;
                ((Pathfinder)target).stepTo(0, z);
            }
            GUILayout.EndHorizontal();
            
        }
    }

}
