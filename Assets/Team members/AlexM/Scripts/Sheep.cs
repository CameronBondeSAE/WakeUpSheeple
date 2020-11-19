using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexM
{
    public class Sheep : MonoBehaviour
	{
		public bool isBlack = false;
		
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