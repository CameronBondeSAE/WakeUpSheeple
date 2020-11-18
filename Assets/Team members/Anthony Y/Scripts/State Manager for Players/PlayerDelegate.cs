using System;
using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDelegate : MonoBehaviour
{
    public DelegateStateManager DelegateStateManager = new DelegateStateManager();

    public DelegateState wolf = new DelegateState();

    public DelegateState dog = new DelegateState();
    public PlayerBehaviour player;

    // Start is called before the first frame update
    void Start()
    {
        dog.Enter = OnIdleEnter;
        dog.Update = OnIdleUpdate;
        dog.Exit = OnIdleExit;

        wolf.Enter = OnRunEnter;
        wolf.Update = OnRunUpdate;

        DelegateStateManager.ChangeState(dog);


    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DelegateStateManager.UpdateCurrentState();
            Debug.Log("I changed States");
        }
     
        
        
    }
    private void OnRunUpdate()
    {
        player.controls.Wolf.Howl.performed += _ =>player.RpcHowl();
        
    }
    


    private void OnRunEnter()
    {
        //dog controls already been disabled
        player.controls.Wolf.Enable();
    }
//Idle Dog Run is Wolf
    private void OnIdleExit()
    {
        player.controls.Wolf.Enable();
        player.controls.Dog.Disable();
    }

    private void OnIdleUpdate()
    {
        player.controls.Dog.Bark.performed += _ =>player.RpcBark();
        player.controls.Wolf.Disable();
    }
    
    private void OnIdleEnter()
    { 
        player.controls.Dog.Enable();
    }
}
