using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NukeSpawner))]
public class NukeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Earn A 25 Killstreak"))
        {
            (target as NukeSpawner)?.DropTheNuke();
        }
    }
}

