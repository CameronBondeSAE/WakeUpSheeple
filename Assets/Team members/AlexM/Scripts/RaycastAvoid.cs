using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaycastAvoid : MonoBehaviour
{
	public ParticleSystem ParticleSystem;
	Ray ray = new Ray();
	RaycastHit raycastHit = new RaycastHit();
	public float speed = 100f;
	public float distance = 5f;
	public Transform MainTransform;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		RaycastOut();
	}

	void RaycastOut()
	{
		ray.origin = transform.position;
		ray.direction = transform.forward;


		if (Physics.Raycast(ray, out raycastHit, distance))
		{
			// Rotate the guy if something is in his way
			MainTransform.Rotate(0, Time.deltaTime * speed, 0);
		}
	}

	// public void Lightning(LineRenderer lineRenderer)
	// {
	// 	// lineRenderer.stuff = 1
	// 	LineRenderer addComponent = gameObject.AddComponent<LineRenderer>();
	// 	Lightning(addComponent);
	// }

	void OnDrawGizmos()
	{
		if (raycastHit.transform != null)
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