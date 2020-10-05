using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class DelegateDrivenState_Beginner : MonoBehaviour
{
	// You COULD make the statemanager a component, but I've just made it a pure c# class, so I have to 'new' it myself (unlike components/monobehaviours)
	public DelegateStateManager DelegateStateManager = new DelegateStateManager();

	public DelegateState idle = new DelegateState();
	public DelegateState run  = new DelegateState();

	public int        health;
	public string     name;
	public GameObject target;
	public Action     thing;

	void Start()
	{
		Debug.Log("Press space to change to run state. HACK: It's just to test");

		// I'm ASSIGNING the variables to specific functions. Remember, variable just POINT to things... ANY thing! ints, strings, gameobjects, components... and... FUNCTIONS!
		// This DOESN'T run the function here. It just REMEMBERS IT for later! (My statemanager code)
		idle.Enter  = OnIdleEnter;
		idle.Update = OnIdleUpdate;
		idle.Exit   = OnIdleExit;

		run.Enter  = OnRunEnter;
		run.Update = OnRunUpdate;

		DelegateStateManager.ChangeState(idle);

		// GetComponent<Renderer>().material.color = Color.red;

		StartCoroutine(Sequence());
		Debug.Log("I happened AFTER the call to coroutine");
	}

	public IEnumerator Sequence()
	{
		while (true)
		{
			transform.position += new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));


			// Vector3 randomOffset = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
			// transform.position = transform.position + randomOffset;
			
			GetComponent<Renderer>().material.color = Color.red;
			Debug.Log("Wait");
			yield return new WaitForSeconds(1f);
			GetComponent<Renderer>().material.color = Color.green;
			Debug.Log("Do stuff");
			yield return new WaitForSeconds(1f);
			GetComponent<Renderer>().material.color = Color.blue;
			Debug.Log("Finished");
			yield return new WaitForSeconds(3f);
		}

		// StartCoroutine(Sequence());
	}

	void Update()
	{
		// Whatever the current state is, run it's update code
		DelegateStateManager.UpdateCurrentState();
	}


	private void OnRunUpdate()
	{
	}

	private void OnRunEnter()
	{
	}

	private void OnIdleExit()
	{
	}

	private void OnIdleUpdate()
	{
	}

	private void OnIdleEnter()
	{
	}
}