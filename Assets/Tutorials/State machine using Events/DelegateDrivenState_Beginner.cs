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
	}

	void Update()
	{
		// Whatever the current state is, run it's update code
		DelegateStateManager.UpdateCurrentState();
	}

	
	
	
	private void OnRunEnter()
	{
		Debug.Log("OnRunEnter");
	}

	private void OnRunUpdate()
	{
		Debug.Log("OnRunExecute");
	}

	private void OnIdleEnter()
	{
		Debug.Log("OnIdleEnter");
	}

	private void OnIdleUpdate()
	{
		Debug.Log("OnIdleExecute");
	
		// Just me forcing the state to change for testing
		// if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
		if (Input.GetKeyDown(KeyCode.Space))
		{
			DelegateStateManager.ChangeState(run);
		}
	}

	private void OnIdleExit()
	{
		Debug.Log("OnIdleExit");
	}
}