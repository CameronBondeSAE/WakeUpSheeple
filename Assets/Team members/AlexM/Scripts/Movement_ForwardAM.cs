using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Rigidbody))]
public class Movement_ForwardAM : MonoBehaviour
{
#region Variables

	[Header("Settings")]
	private Rigidbody _rB;

	public  float speedScale = 1f;
	
	[Tooltip("Adjust these to make the object move in the given direction")]
	public float zForce = 200f;

	public event Action<Vector3> velEvent;

	//beacon even to passthrough all the info in this script
	public event Action<Movement_ForwardAM> beacon;

	private Vector3 forceApplied;

	
	//Debugging
	private Vector3 vel;
	float           previousForce;

#endregion

	private void OnEnable()
	{
		beacon?.Invoke(this);
	}

	private void Awake()
	{
		forceApplied = Vector3.zero;
		if (_rB == null)
		{
//         Debug.Log("MV_Fwd: Assigning Rigidbody..");
			_rB = GetComponent<Rigidbody>();

			if (_rB.constraints != RigidbodyConstraints.FreezeRotationX)
			{
				_rB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
			}
		}
	}

	private void FixedUpdate()
	{
		Debugging();
		//Move();
		GoForward();
		// DoStop();
	}

	public void GoForward()
	{
		// HACK: Minimal speed always. Make variable
		speedScale = Mathf.Clamp(speedScale, 0.1f, 1f);
		
		//forceApplied.z = zForce;
		float finalSpeed = speedScale * zForce;


		Vector3 localSpeed = transform.InverseTransformDirection(new Vector3(0,0,finalSpeed));

		
		_rB.AddRelativeForce(0, 0, finalSpeed);

	#region BrokenMovement

		//TODO: Clamping totally breaks movement. Figure out why if time permits.

		// if (clampSpeed)
		// {
		//    //Negatives aren't clamped for now...
		//    if (localSpeed.z > maxSpeed)
		//    {
		//       _rB.velocity = new Vector3(vel.x, vel.y, maxSpeed);
		//    }
		//    else
		//    {
		//       _rB.AddRelativeForce(0,0,forceApplied.z);
		//    }
		// }
		// else
		// {
		//    //Un-Clamped
		//    _rB.AddRelativeForce(0,0,forceApplied.z);
		// }

	#endregion
	}

	public float SetForce(float force)
	{
		previousForce = zForce;


		zForce = force;

		return zForce;
	}

	void DoStop()
	{
		if (zForce == 0)
		{
			_rB.velocity = Vector3.zero;
		}
	}

	private void Debugging()
	{
		vel = _rB.velocity;
		velEvent?.Invoke(vel);
	} 
}