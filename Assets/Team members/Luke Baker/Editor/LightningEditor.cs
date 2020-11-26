using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace LukeBaker
{
    [CustomEditor(typeof(Lightning))]
    public class LightningEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Lightning test"))
            {
                (target as Lightning)?.LightningOn();
            }
            
            if (GUILayout.Button("Lightning OFF"))
            {
                (target as Lightning)?.LightningOff();
            }
        }
    }
}