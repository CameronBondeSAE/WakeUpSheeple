using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
	// Full event definition with delegate
	public delegate void       PauseDelegate();
	public event PauseDelegate PauseEvent;

	// Shortcut lazy event definition
	public event Action AnotherPauseEvent;


	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			// YOU NEED to check for null. Because if nothing is 'listening' it will be calling NOTHING which will null

			// Using .Invoke. I personally like this, because it shows that it's not a normal function
			
			// Full null check
			if (AnotherPauseEvent != null)
			{
				AnotherPauseEvent.Invoke();
			}
			
			// Checking for null shortcut using ?. Same as the if above
			PauseEvent?.Invoke();
		}
	}
}