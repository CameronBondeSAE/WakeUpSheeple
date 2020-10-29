using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCube : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		other.GetComponent<Health>().Damage(50);
	}
}
