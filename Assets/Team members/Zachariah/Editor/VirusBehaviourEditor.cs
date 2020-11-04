using UnityEditor;
using UnityEngine;

namespace Zach
{
    [CustomEditor(typeof(VirusBehaviour))]
    public class VirusBehaviourEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Breed"))
                //testing if the object is a virus behaviour 
                (target as VirusBehaviour)?.Breed();
        }
    }
}
