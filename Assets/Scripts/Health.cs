using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
	public float maxHealth;
	public float currentHealth;

	public event Action<Health> changeHealth;
	
	



}
