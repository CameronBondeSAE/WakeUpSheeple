using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CamsDude_Model))]
public class CamsDude_Model_Editor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if (GUILayout.Button("GET BIG"))
		{
			// Test is the target is actually a CamsDude (which inherits from the base class "Object")
			(target as CamsDude_Model)?.GetBigOrDieTrying();
			
			
			// ((CamsDude_Model)target)?.GetBigOrDieTrying();

			
			// if (target as CamsDude_Model)
			// {
				// (target as CamsDude_Model).GetBigOrDieTrying();
			// }
		}
	}
}
