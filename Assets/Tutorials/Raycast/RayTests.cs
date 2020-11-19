using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RayType
{
	RaycastBool,
	RaycastOut
}

/// <summary>
/// Ray cast tests
/// Try any of the 'cast' functions in "Physics."
/// eg Linecast takes a target directly
/// </summary>
public class RayTests : MonoBehaviour
{
	public RayType        RayType = RayType.RaycastOut;
	public ParticleSystem ParticleSystem;
	Ray                   ray        = new Ray();
	RaycastHit            raycastHit = new RaycastHit();
	public float          speed      = 100f;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		switch (RayType)
		{
			case RayType.RaycastBool:
				RaycastBool();
				break;
			case RayType.RaycastOut:
				RaycastOut();
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	void RaycastBool()
	{
		if (Physics.Raycast(transform.position, transform.forward))
		{
			// Rotate the guy if something is in his way
			transform.Rotate(0, Time.deltaTime * speed, 0);
		}
	}

	void RaycastOut()
	{
		ray.origin    = transform.position;
		ray.direction = transform.forward;


		if (Physics.Raycast(ray, out raycastHit, 5f))
		{
			ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
			emitParams.position = raycastHit.point;
			ParticleSystem.Emit(emitParams, 1);

			// Rotate the guy if something is in his way
			transform.Rotate(0, Time.deltaTime * speed, 0);
		}
	}

	void OnDrawGizmos()
	{
		if (raycastHit.transform != null && RayType == RayType.RaycastOut)
		{
			// Where it hit
			Gizmos.color = Color.green;
			Gizmos.DrawLine(ray.origin, raycastHit.point);

			// Hit polygon normal (direction)
			Gizmos.color = Color.red;
			Gizmos.DrawRay(raycastHit.point, raycastHit.normal);

			// Reflected normal bouncing off the wall.
			Gizmos.color = Color.yellow;
			Gizmos.DrawRay(raycastHit.point, Vector3.Reflect(ray.direction, raycastHit.normal));
		}
	}
}