using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class FakeSheep : MonoBehaviour{}

public class Neighbours : MonoBehaviour
{
	public float radius = 5f;

	public List<FakeSheep> neighbours;
	

    // Update is called once per frame
    void Update()
	{
		Collider[] overlapSphereColliders = Physics.OverlapSphere(transform.position, radius);

		// Either the above array or the list
		foreach (Collider collider1 in overlapSphereColliders)
		{
			// Check if the collider is actually attached to an object you're interested in
			if (collider1.GetComponent<FakeSheep>()) // eg check if there's a sheep script also attached to this GameObject
			{
				
			}
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<FakeSheep>())
		{
			neighbours.Add(other.GetComponent<FakeSheep>());
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<FakeSheep>())
		{
			neighbours.Remove(other.GetComponent<FakeSheep>());
		}
	}
}
