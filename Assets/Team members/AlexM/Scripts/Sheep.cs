using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexM
{
    public class Sheep : CharacterBase
	{
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