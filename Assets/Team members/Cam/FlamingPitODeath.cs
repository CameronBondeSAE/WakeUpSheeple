using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamingPitODeath : MonoBehaviour
{

	private void OnTriggerStay(Collider other)
	{
		
		// This will work with ANY NUMBER of damageable items
		// This supports items that HAVEN'T BEEN MADE YET
		// other.GetComponent<Health>().amount -= 10f * Time.deltaTime;
	}
}
