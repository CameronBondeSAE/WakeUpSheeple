using UnityEngine;
// using UnityEngine.InputSystem;

public class EventDrivenState_Intermediate : MonoBehaviour
{
	public DelegateState idle = new DelegateState();
	public DelegateState run  = new DelegateState();

	public DelegateStateManager DelegateStateManager = new DelegateStateManager();

	// Start is called before the first frame update
	void Start()
	{
		// Here I'm using "Lambdas" so I don't have to define whole functions for everything. You can mix and match.
		idle.Enter   = () => Debug.Log("IDLE BEGIN");
		idle.Update = () => Debug.Log("IDLE GO!");
		idle.Exit    = () => Debug.Log("IDLE END");

		run.Enter   = () => Debug.Log("run begin");
		run.Update = () => Debug.Log("run execute");

		DelegateStateManager.ChangeState(idle);
	}

	// Update is called once per frame
	void Update()
	{
		DelegateStateManager.UpdateCurrentState();

		// Just me forcing the state to change for testing
		// if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
		if (Input.GetKeyDown(KeyCode.Space))
		{
			DelegateStateManager.ChangeState(run);
		}
	}
}
