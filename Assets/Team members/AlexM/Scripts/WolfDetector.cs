using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using UnityEngine;

public class WolfDetector : MonoBehaviour
{
	
	public float radius = 5f;
	public int lastAmountOfWolves;

	public List<PlayerBehaviour> GetNearbyWolves()
	{
		List<PlayerBehaviour> neighbours = new List<PlayerBehaviour>();
		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

		foreach (Collider c in colliders)
		{
			// Is targetDirection sheep?
			if (c.GetComponent<PlayerBehaviour>())
			{
				neighbours.Add(c.GetComponent<PlayerBehaviour>());
			}
		}

		lastAmountOfWolves = neighbours.Count;
		return neighbours;
	}
	
}
