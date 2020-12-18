using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(LevelLoader))]
public class LevelLoaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        LevelLoader levelLoader = (LevelLoader) target;

        if (GUILayout.Button("Load Next level"))
        {
            levelLoader.LoadLevel();
        }
       
    }
}
