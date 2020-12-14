using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsWithParameters : MonoBehaviour
{
	public Action<EventsWithParameters> PassThroughMySelfWhenICallTheEvent;
	
	
    // Start is called before the first frame update
    void Start()
	{
		PassThroughMySelfWhenICallTheEvent?.Invoke(this);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
