using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Health))]
public class HealthEditor : Editor
{

    public override void OnInspectorGUI()
        {
             DrawDefaultInspector();
             int ButtonAmount = 25;
             
            if (GUILayout.Button("Instant Death"))
            {
              ((Health) target)?.Death();
            }

            if (GUILayout.Button("Decrease Current Health by 25"))
            {
                ((Health) target)?.Damage(ButtonAmount);
            }
            if (GUILayout.Button("Increase Current Health by 25"))
            {
                ((Health) target)?.Damage(-ButtonAmount);
            }

           
        }
}
