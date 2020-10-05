using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

namespace Zach
{
	
public class SimpleStateTest : MonoBehaviour
{
    
    public DelegateStateManager DelegateStateManager = new DelegateStateManager();
    
    public DelegateState rest = new DelegateState();
    public DelegateState active = new DelegateState();
    
    
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

        DelegateStateManager.ChangeState(rest);
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

}
