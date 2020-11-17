using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MoleManManager))] //Set this as the script we are controlling
public class RUIScript : Editor //inherit from editor
{
    public override void OnInspectorGUI() //use the gui
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Jump State")) //This makes our button visible in the editor of unity
        {
            Debug.Log("Forced Jump State"); //Debug to prove it works
            (target as MoleManManager)?.ForceJumpState(); //Set the function to what we want the button to do
        }

        if (GUILayout.Button("Next Waypoint State")) //This makes our button visible in the editor of unity
        {
            Debug.Log("Forced Waypoint State"); //Debug to prove it works
            (target as MoleManManager)?.ForceWaypointState(); //Set the function to what we want the button to do
        }
    }
}
