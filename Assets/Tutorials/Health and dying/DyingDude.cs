using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingDude : MonoBehaviour
{
	public Health health;


	void OnEnable()
	{
		health.DeathEvent += HealthOnDeathEvent;
	}

	void OnDisable()
	{
		health.DeathEvent -= HealthOnDeathEvent;
	}

	void HealthOnDeathEvent(Health obj)
	{
		// My death code goes here
		// - This is a demo only, you do whatever YOUR object does when it dies
		Destroy(gameObject);
	}
}
