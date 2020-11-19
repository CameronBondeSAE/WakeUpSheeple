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
			// Make a readonly variable, by removing the ability to set it from outside this class!
			// set
			// {
			// 	isBlack = value;
			// }
		}

		// Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

		public void ChangeToBlack()
		{
			isBlack = true;
		}

		public void ChangeToWhite()
		{
			isBlack = false;
		}
    }

}