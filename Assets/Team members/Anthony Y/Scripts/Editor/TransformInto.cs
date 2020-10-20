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
   [SerializeField] private bool used = false;
   
    private void Update()
    {
        Debug.Log(isLocalPlayer);
        if (isLocalPlayer)
        {
            if (!used && Input.GetKeyDown(KeyCode.E))
            {
                CmdReplace(originalPrefab,replacementPrefab);
                Debug.Log("Replaced");
                used = true; 
            }
            else
            {
                used = false;
            }
        }
    }
[ClientRpc]
    public void RPCReplace(GameObject obj1, GameObject obj2)
    {
        Instantiate(obj2, obj1.transform.position, Quaternion.identity);
        Destroy(obj1);
    }
    //**************************SERVER CODE****************************************
[Command]
    public void CmdReplace(GameObject obj1, GameObject obj2)
    {
        RPCReplace(obj1,obj2);
    }
}

//******************************EDITOR CODE********************************

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