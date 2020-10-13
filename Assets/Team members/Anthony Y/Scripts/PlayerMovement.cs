using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    
    public float movementSpeed;
    
    
    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    [ClientCallback] // prevents the server from running this method
    private void OnEnable()
    {

        controls.GamePlayer.Enable();
    }
[ClientCallback]
    private void OnDisable()
    {
     controls.GamePlayer.Disable();   
    }


    [ClientCallback] // Easier for beginners but will be terrible in the long run. Better solution is Server Authority
    void Update()
    {
        if (!isLocalPlayer)
        {
            Move();
        }
        
    }
    [Client]
    private void Move()
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

}
