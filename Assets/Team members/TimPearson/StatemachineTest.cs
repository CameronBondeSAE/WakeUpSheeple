using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class StatemachineTest : MonoBehaviour
{
    public DelegateStateManager DelegateStateManager = new DelegateStateManager();

    public DelegateState idle = new DelegateState();
    public DelegateState jump = new DelegateState();
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(message:"Press space to test if code works");
        idle.Enter = OnIdleEnter;
        idle.Update = OnIdleUpdate;
        idle.Exit = OnIdleExit;

        jump.Enter = OnJumpEnter;
        jump.Update = OnJumpUpdate;
        jump.Exit = OnJumpExit;
        
        
        
        DelegateStateManager.ChangeState(idle);

    }

    


    private void OnJumpExit()
    {
        Debug.Log("OnJumpExit");
        
    }

    private void OnJumpUpdate()
    {
        Debug.Log("OnJumpUpdate");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(0, 10, 0, ForceMode.VelocityChange);
            
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            DelegateStateManager.ChangeState(idle);
        }
    }

    private void OnJumpEnter()
    {
        Debug.Log("OnJumpEnter");
        
    }

    private void OnIdleExit()
    {
        Debug.Log("OnIdleExit");
    }

    private void OnIdleUpdate()
    {
        Debug.Log("OnIdleUpdate");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DelegateStateManager.ChangeState(jump);
        }

        
    }

    private void OnIdleEnter()
    {
        Debug.Log(message:"OnIdleEnter");
        
    }

    // Update is called once per frame
    void Update()
    {
        DelegateStateManager.UpdateCurrentState();
    }
}

