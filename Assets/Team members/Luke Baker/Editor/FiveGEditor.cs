using UnityEditor;
using UnityEngine;

namespace LukeBaker
{
    [CustomEditor(typeof(FiveG))]
    public class FiveGEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Attractor On"))
            {
                (target as FiveG)?.AttractOn();
            }

            if (GUILayout.Button("Attractor Off"))
            {
                (target as FiveG)?.AttractOff();
            }
        }
    }
}