using AnthonyY;
using UnityEngine;


public class RaycastAvoid : MonoBehaviour
{
	Ray ray = new Ray();
	RaycastHit raycastHit = new RaycastHit();
	public float speed = 100f;
	public float distance = 5f;
	public Transform MainTransform;
	public LayerMask layer;
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
			// Rotate the guy if something is in his way
			if (raycastHit.transform.GetComponent<PlayerBehaviour>())
			{
				MainTransform.Rotate(0, Time.deltaTime * (speed * 3f), 0);
			}

			if (raycastHit.transform.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
			{
				// string layerName = LayerMask.LayerToName(8).ToString();
				// Debug.Log(MainTransform.name + "-" + transform.name + ": Hitting layer:: " + layerName, this);
				MainTransform.Rotate(0, Time.deltaTime * speed, 0);
			}
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