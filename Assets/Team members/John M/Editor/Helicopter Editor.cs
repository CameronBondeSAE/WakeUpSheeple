using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HeliSpawner))]
public class HelicopterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Spawn Helicopter"))
        {
            (target as HeliSpawner)?.SpawnNewHeli();
        }
    }
}
