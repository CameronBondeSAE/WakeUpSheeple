using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class DelegateDrivenState_Beginner : MonoBehaviour
{
	// You COULD make the statemanager a component, but I've just made it a pure c# class, so I have to 'new' it myself (unlike components/monobehaviours)

	// The EMPTY variable for the manager which swaps states
	public DelegateStateManager DelegateStateManager;

	// The EMPTY variable for the individual states
	public DelegateState idle;
	public DelegateState run;
	
	void Start()
	{
		// Create the manager which swaps states
		DelegateStateManager = new DelegateStateManager();
		// Create individual states
		idle                 = new DelegateState();
		run                  = new DelegateState();

		// Assign which functions run to which states
		// I'm ASSIGNING the variables to specific functions. Remember, variable just POINT to things... ANY thing! ints, strings, gameobjects, components... and... FUNCTIONS!
		// This DOESN'T run the function here. It just REMEMBERS IT for later! (My statemanager code)
		idle.Enter  = OnIdleEnter;
		idle.Update = OnIdleUpdate;
		idle.Exit   = OnIdleExit;

		run.Enter  = OnRunEnter;
		run.Update = OnRunUpdate;
		// Note you don't HAVE to have Enter/Exit/Update, you can leave them out if you're not going to use them

		// Set the default state
		DelegateStateManager.ChangeState(idle);
	}

	void Update()
	{
		// Whatever the current state is, run it's update code
		DelegateStateManager.UpdateCurrentState();
	}


	private void OnRunEnter()
	{
	}

	private void OnRunUpdate()
	{
	}

	private void OnIdleEnter()
	{
	}

	private void OnIdleUpdate()
	{
	}

	private void OnIdleExit()
	{
	}
}