using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCube : MonoBehaviour
{
	public int amount = 10;
	
	void OnTriggerEnter(Collider other)
	{
		other.GetComponent<Health>().Damage(amount);
	}
}
