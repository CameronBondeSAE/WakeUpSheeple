using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTest : MonoBehaviour
{
    public DelegateStateManager StateManager = new DelegateStateManager();
    public DelegateState standing = new DelegateState();
    public DelegateState jump = new DelegateState();
    void Start()
    {
        standing.Enter = 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
