using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Mirror;
using UnityEngine;
using UnityEditor;

public class TransformInto : NetworkBehaviour
{
    public GameObject originalPrefab;

    public GameObject replacementPrefab;
    private bool used = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (isLocalPlayer)
        {
            if (!used && Input.GetKey(KeyCode.E))
            {
                CmdReplace(originalPrefab,replacementPrefab);
                Debug.Log("Replaced");
                used = true; 
            }
        }
    }
[ClientRpc]
    public void RPCReplace(GameObject obj1, GameObject obj2)
    {
        Instantiate(obj2, obj1.transform.position, Quaternion.identity);
        Destroy(obj1);
    }
[Command]
    public void CmdReplace(GameObject obj1, GameObject obj2)
    {
        RPCReplace(obj1,obj2);
    }
}
[CustomEditor(typeof(TransformInto))]
public class TransformIntoWolf : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TransformInto transformInto = (TransformInto) target;
        if (GUILayout.Button("Transform"))
        {
            transformInto.CmdReplace(transformInto.originalPrefab,transformInto.replacementPrefab);
        }
    }
}