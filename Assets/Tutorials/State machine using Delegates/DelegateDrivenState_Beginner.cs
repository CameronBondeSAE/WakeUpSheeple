using UnityEngine;

public class DelegateDrivenState_Beginner : MonoBehaviour
{
	// You COULD make the statemanager a component, but I've just made it a pure c# class, so I have to 'new' it myself (unlike components/monobehaviours)
	public DelegateStateManager DelegateStateManager = new DelegateStateManager();

	public DelegateState idle = new DelegateState();
	public DelegateState run  = new DelegateState();

	void Start()
	{
		Debug.Log("Press space to change to run state. HACK: It's just to test");
		
		// I'm ASSIGNING the variables to specific functions. Remember, variable just POINT to things... ANY thing! ints, strings, gameobjects, components... and... FUNCTIONS!
		idle.Enter   = OnIdleEnter;
		idle.Update = OnIdleUpdate;
		idle.Exit    = OnIdleExit;

		run.Enter   = OnRunEnter;
		run.Update = OnRunUpdate;

		DelegateStateManager.ChangeState(idle);
		
		GetComponent<Renderer>().material.color = Color.red;
	}

	private void OnRunUpdate()
	{
		throw new System.NotImplementedException();
	}

	private void OnRunEnter()
	{
		throw new System.NotImplementedException();
	}

	private void OnIdleExit()
	{
		throw new System.NotImplementedException();
	}

	private void OnIdleUpdate()
	{
		throw new System.NotImplementedException();
	}

	private void OnIdleEnter()
	{
		throw new System.NotImplementedException();
	}

	void Update()
	{
		// Whatever the current state is, run it's update code
		DelegateStateManager.UpdateCurrentState();
	}

	
	
}