using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Mirror;
using UnityEngine;

public class PlayerRotate : NetworkBehaviour
{
    [SyncVar]
    public float rotateForce = 90f;
    public Rigidbody rb;
    
    void Start()
    {
        rb = rb.GetComponent<Rigidbody>();
    }

   [Client]
    void Update()
    { 
        if(!hasAuthority){return;}

        if (!Input.GetKeyDown(KeyCode.Space)) {return;};
        rb.AddTorque(0,rotateForce,0);
       
        CmdRotate();
    }

    [Command]
    public void CmdRotate()
    {
       RPCRotate();

    }
    [ClientRpc]
    private void RPCRotate()
    {
        rb.AddTorque(0,rotateForce,0);
    } 
}
