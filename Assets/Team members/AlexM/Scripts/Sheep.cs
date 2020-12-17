using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexM
{
    public class Sheep : CharacterBase
	{
		public Material wool;
		private static readonly int     Colour = Shader.PropertyToID("Color_B9F56194");
		void Awake()
		{
			GetComponent<Health>().DeathEvent += OnDeathEvent;
		}

		void OnDeathEvent(Health health)
		{
			Destroy(gameObject);
		}

		// Property for access to variable
		[SerializeField]
		private bool isBlack = false;
		public bool IsBlack
		{
			get
			{
				return isBlack;
			}
			// Make targetDirection readonly variable, by removing the ability to set it from outside this class!
			// set
			// {
			// 	isBlack = value;
			// }
		}

		public void ChangeToBlack()
		{
			isBlack = true;
			wool.SetColor(Colour, Color.black);
		}

		public void ChangeToWhite()
		{
			isBlack = false;
		}

		private void OnCollisionEnter(Collision other)
		{
			//This should re-enable the movement of sheep when they get touched after getting stopped by propaganda TV's
			GetComponent<Movement_ForwardAM>().enabled = true;
		}
	}

}