﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
	public int startingHealth;
	

	[ReadOnly]
	public int currentHealth;

	
	public event Action<Health> DeathEvent;

	void Awake()
	{
		currentHealth = startingHealth;
	}

	public void Damage(int amount)
	{
		currentHealth = currentHealth - amount;
		Debug.Log(gameObject.name + " current health : " + currentHealth);

		if (currentHealth <= 0)
		{
			Death();
		}
	}

	public void Death()
	{
		DeathEvent?.Invoke(this);
	}





}
