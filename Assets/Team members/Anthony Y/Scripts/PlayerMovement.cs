using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls controls;
    public float movementSpeed;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() => Move();

    private void Move()
    {
        //QUICK SHIT HACK
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
