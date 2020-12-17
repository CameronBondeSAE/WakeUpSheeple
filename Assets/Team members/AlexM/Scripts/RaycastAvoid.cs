using System;
using AnthonyY;
using tripolygon.UModeler;
using UnityEngine;
using Math = UnityEngine.ProBuilder.Math;


public class RaycastAvoid : MonoBehaviour
{
	public Rigidbody mainRigidbody;
	Ray              ray        = new Ray();
	RaycastHit       raycastHit = new RaycastHit();
	public bool      panic      = false;
	public float     speed      = 100f;
	public float     distance   = 5f;
	public Transform MainTransform;
	public LayerMask layer;
	public float     slowDownForObstaclesForce = 100f;


	void Update()
	{
		RaycastOut();
	}

	void RaycastOut()
	{
		var transform1 = transform;
		ray.origin = transform1.position;
		ray.direction = transform1.forward;


		if (Physics.Raycast(ray, out raycastHit, distance,layer))
		{
			if (panic)
			{
				MainTransform.Rotate(0, (Mathf.Abs(speed) * -1f + (2f * Mathf.PerlinNoise(Time.time, 0))) * Time.deltaTime, 0);
			}
			else
			{
				MainTransform.Rotate(0, speed * Time.deltaTime, 0);
			}
			// Rotate the guy if something is in his way
			// if (raycastHit.transform.GetComponent<PlayerBehaviour>())
			// {
			// 	MainTransform.Rotate(0, (speed * -1 + (2 * Mathf.PerlinNoise(Time.time * 10f, 0))) * Time.deltaTime, 0);
			// }
			//
			// if (raycastHit.transform.gameObject.layer == LayerMask.NameToLayer("Obstacles") || raycastHit.transform.gameObject.layer == LayerMask.NameToLayer("Default") )
			// {
				// string layerName = LayerMask.LayerToName(8).ToString();
				// Debug.Log(MainTransform.name + "-" + transform.name + ": Hitting layer:: " + layerName, this);
				// MainTransform.Rotate(0, Time.deltaTime * speed, 0);
				
				// Push away from walls etc, instead of just hard turning
				mainRigidbody.AddRelativeForce(0,0,-slowDownForObstaclesForce * Time.deltaTime);
			// }
		}
	}

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