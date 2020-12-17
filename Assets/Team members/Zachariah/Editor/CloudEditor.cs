using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Zach;

[CustomEditor(typeof(Cloud))] //Set this as the script we are controlling
public class CloudEditor : Editor //inherit from editor
{
    public override void OnInspectorGUI() //use the gui
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Spawn Lightning")) //This makes our button visible in the editor of unity
        {
            Debug.Log("Forced Lightning chance to 100%"); //Debug to prove it works
            (target as Cloud)?.ForceLightning(); //Set the function to what we want the button to do
        }
    }
}
