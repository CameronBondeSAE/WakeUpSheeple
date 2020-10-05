using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class SimpleStateTest2 : MonoBehaviour
{
    
    public DelegateStateManager DelegateStateManager = new DelegateStateManager();
    
    public DelegateState rest = new DelegateState();
    public DelegateState active = new DelegateState();
    public DelegateState moving = new DelegateState();
    
    
    // Start is called before the first frame update
    void Start()
    {
        //this doesn't run the function. It just remembers it for later
        rest.Enter = OnRestEnter;
        rest.Update = OnRestUpdate;
        rest.Exit = OnRestExit;

        active.Enter = OnActiveEnter;
        active.Update = OnActiveUpdate;
        active.Exit = OnActiveExit;

        moving.Enter = OnMovingEnter;
        moving.Update = OnMovingUpdate;
        moving.Exit = OnMovingExit;

        DelegateStateManager.ChangeState(rest);
    }

    private void OnMovingEnter()
    {
        Debug.Log("MovingStart");    
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(1,0,0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(0,0,1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(0,0,-1);
        }
    }

    private void OnMovingUpdate()
    {
        Debug.Log("Moving");
        DelegateStateManager.ChangeState(rest);
    }

    private void OnMovingExit()
    {
        Debug.Log("MovingStop");
    }

    private void OnRestEnter()
    {
       Debug.Log("RestEnter");
       GetComponent<Renderer>().material.color = Color.yellow;
    }

    private void OnRestUpdate()
    {
        Debug.Log("RestUpdate");
        if (Input.GetKey(KeyCode.Space))
        {
            DelegateStateManager.ChangeState(active);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            DelegateStateManager.ChangeState(moving);
        }
    }

    private void OnRestExit()
    {
        Debug.Log("RestExit");
    }

    private void OnActiveEnter()
    {
       Debug.Log("ActiveEnter");
       GetComponent<Renderer>().material.color = Color.magenta;
       GetComponent<Rigidbody>().AddForce(1,1,0,ForceMode.VelocityChange);
    }

    private void OnActiveUpdate()
    {
        Debug.Log("ActiveUpdate");
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            DelegateStateManager.ChangeState(rest);
        }
    }

    private void OnActiveExit()
    {
        Debug.Log("ActiveExit");
        
    }

    // Update is called once per frame
    void Update()
    {
        DelegateStateManager.UpdateCurrentState();
    }
}
