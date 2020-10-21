using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FiveG))]
public class FiveGEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if (GUILayout.Button("Attractor On"))
        {
            (target as FiveG)?.AttractOn();
        }
        
        if (GUILayout.Button("Attractor Off"))
        {
            (target as FiveG)?.AttractOff();
        }
        
        if (GUILayout.Button("Energiser On"))
        {
            (target as FiveG)?.EnergiseOn();
        }
        
        if (GUILayout.Button("Energiser Off"))
        {
            (target as FiveG)?.EnergiseOff();
        }
    }
}
