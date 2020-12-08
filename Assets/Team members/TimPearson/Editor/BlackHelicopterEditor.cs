using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tim;
using UnityEditor;


[CustomEditor(typeof(BlackHelicopter))]
public class BlackHelicopterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Strafe Off"))
        {
            (target as BlackHelicopter)?.StrafeOff();
        }

        if (GUILayout.Button("Strafe On"))
        {
            (target as BlackHelicopter)?.StrafeOn();
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
