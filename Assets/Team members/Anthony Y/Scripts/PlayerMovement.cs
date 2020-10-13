using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.Examples.Chat;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SyncVar]
    public float movementSpeed;
    
    
    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
    }
    
    
    private void OnEnable()
    {

        controls.GamePlayer.Enable();
    }
    
    private void OnDisable()
    {
     controls.GamePlayer.Disable();   
    }

    private void Start()
    {
      
    }

    [Client] 
    void Update()
    {
        if (!isLocalPlayer)
        {
            RpcMove();
        }
    }
    [ClientRpc]
    private void RpcMove()
    {
        var movementInput = controls.GamePlayer.Movement.ReadValue<Vector2>();
        var movement = new Vector3
        {
            x = movementInput.x,
            z = movementInput.y
        }.normalized;
     
      
        transform.Translate(movement * (movementSpeed * Time.deltaTime),Space.World);
        transform.rotation = Quaternion.LookRotation(movement);

    }
    //Actually moving the player on server
    [Command]
    private void CmdMove()
    {
        if (!isLocalPlayer)
        {
            RpcMove();
        }
    }
    

}
