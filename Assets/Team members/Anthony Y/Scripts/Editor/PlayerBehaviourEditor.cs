using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(PlayerBehaviour))]
public class PlayerBehaviourEditor : Editor
{
    public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            PlayerBehaviour playerBehaviour = (PlayerBehaviour) target;

            if (GUILayout.Button("Turn into Wolf"))
            {
                playerBehaviour.TurnIntoWolf();
            }

            if (GUILayout.Button("Turn back into Dog"))
            {
                playerBehaviour.TurnIntoDog();
            }
        }
}
