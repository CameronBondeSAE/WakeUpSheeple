using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement_TurningAM : MonoBehaviour
{
	private Rigidbody _rB;
	public float yForce;
	private Vector3 torqueApplied;

	//Debugging
	private Vector3 vel;

#region EventStuff

	private void OnEnable()
	{
		GetComponent<Movement_ForwardAM>().velEvent += OnvelEvent;
	}

	private void OnDisable()
	{
		GetComponent<Movement_ForwardAM>().velEvent -= OnvelEvent;
	}
	
	private void OnvelEvent(Vector3 obj)
	{
		vel = obj;
	}

#endregion

	public void Start()
	{
		if (_rB == null)
		{
			_rB = GetComponent<Rigidbody>();

			if (_rB != null)
			{
				Debug.Log("MV_Turn: Assigned Rigidbody..");
			}
		}
	}

	public void Update()
	{
		Turn();
	}

	public void Turn()
	{
		torqueApplied.y = yForce;
		
		if (_rB)
		{
			_rB.AddTorque(0,torqueApplied.y,0);
			//_rB.AddRelativeTorque(0,torqueApplied.y, 0);
			//transform.Rotate(0, torqueApplied.y,0);
		}
	}
}