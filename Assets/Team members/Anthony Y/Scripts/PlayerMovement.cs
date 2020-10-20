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
    
    
    void Update()
    {
        Debug.Log(isLocalPlayer);
        if (isLocalPlayer)
        {
            Vector3 movementInput = controls.GamePlayer.Movement.ReadValue<Vector2>();
            CmdMove(movementInput);
            
        }
    }
    [ClientRpc]
    private void RpcMove(Vector2 movementInput)
    {
       
        Vector3 movement = new Vector3
        {
            x = movementInput.x,
            z = movementInput.y
        }.normalized;
     
      
        transform.Translate(movement * (movementSpeed * Time.deltaTime),Space.World);
        transform.rotation = Quaternion.LookRotation(movement);
        transform.forward = GetComponent<Rigidbody>().velocity;

    }
    //Actually moving the player on server
    //***************************************SERVER CODE****************************
    [Command]
    private void CmdMove(Vector2 movementInput)
    {
        RpcMove(movementInput);
    }
    

}
