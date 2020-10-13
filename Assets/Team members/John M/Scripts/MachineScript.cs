using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MachineScript : MonoBehaviour
{
    public DelegateStateManager stateManager = new DelegateStateManager();
    public DelegateState idle = new DelegateState();
    public DelegateState spin = new DelegateState();
    
    private void Start()
    {
        
        idle.Enter   = OnIdleEnter;
        idle.Update = OnIdleUpdate;
        idle.Exit    = OnIdleExit;

        spin.Enter   = OnSpinEnter;
        spin.Update = OnSpinUpdate;
        spin.Exit = OnSpinExit;

        stateManager.ChangeState(idle);
    }

   void Update()
    {
        stateManager.UpdateCurrentState();
    }

    void OnIdleEnter()
    {
        Debug.Log("Entering Idle State");
    }

    void OnIdleUpdate()
    {
        Debug.Log("Currently Idle");
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateManager.ChangeState(spin);
        }
    }

    void OnIdleExit()
    {
        Debug.Log("Exiting Idle State");
        
    }

    void OnSpinEnter()
    {
        Debug.Log("Entering Spin State");
        
    }

    void OnSpinUpdate()
    {
        Debug.Log("Currently Spinning");
        transform.Rotate(Random.Range(1,7),Random.Range(1,3),Random.Range(1,8));
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateManager.ChangeState(idle);
        }
    }

    void OnSpinExit()
    {
        Debug.Log("Exiting Spinning State");
    }
    
}
