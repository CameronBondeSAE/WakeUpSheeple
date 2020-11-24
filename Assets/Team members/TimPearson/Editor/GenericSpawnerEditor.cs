using System.Collections;
using System.Collections.Generic;
using Tim;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GenericSpawner))]
public class GenericSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Spawn"))
        {
            (target as GenericSpawner)?.Spawn();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
