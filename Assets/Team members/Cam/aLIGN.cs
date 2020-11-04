using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aLIGN : MonoBehaviour
{
	void FixedUpdate()
	{
		// Some are Torque, some are Force
		// rb.AddTorque(CalculateMove(neighbours.Getneighbours()));
	}
	
	public Vector3 CalculateMove(List<Transform> neighbours)
	{
		if (neighbours.Count == 0)
			return transform.forward;

		Vector3         alignmentMove   = Vector3.zero;

		foreach (Transform item in neighbours)
		{
			alignmentMove += (Vector3) item.transform.transform.forward;
		}

		// Average of all neighbours directions
		alignmentMove /= neighbours.Count;

		return alignmentMove;
	}
}