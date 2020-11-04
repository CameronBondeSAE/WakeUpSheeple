using System.Collections;
using System.Collections.Generic;
using Tim;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChemtrailTest))]
public class ChemtrailEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Trail Off"))
        {
            (target as ChemtrailTest)?.TrailOff();
        }

        if (GUILayout.Button("Trail On"))
        {
            (target as ChemtrailTest)?.TrailOn();
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
