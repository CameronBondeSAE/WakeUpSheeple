using System;
using UnityEngine;


public class Health : MonoBehaviour
{
	public int startingHealth;

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
