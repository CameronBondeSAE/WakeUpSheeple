using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AlexM
{
	[CustomEditor(typeof(Movement_ForwardAM))]
	public class MovingEditor : Editor
	{
		private static float force = 6;

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			
			EditorGUILayout.LabelField(" ");
			EditorGUILayout.LabelField("Custom Debugger", EditorStyles.boldLabel);
            
			force = EditorGUILayout.FloatField("Applied Force:", force);
			
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Forward"))
			{
				((Movement_ForwardAM)target).zForce = force;
			}
			if (GUILayout.Button("Stop"))
			{
				((Movement_ForwardAM)target).zForce = 0;
			}
			if (GUILayout.Button("Backwards"))
			{
				((Movement_ForwardAM)target).zForce = -force;
			}
			GUILayout.EndHorizontal();
		}
	}

}