using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UFOSpawner))]
public class UFOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Spawn UFO"))
        {
            (target as UFOSpawner)?.SpawnNewUFO();
        }
    }
}
