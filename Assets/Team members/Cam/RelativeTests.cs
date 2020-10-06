using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cam
{
	public class RelativeTests : MonoBehaviour
	{
		public Vector3 speed;

		// Start is called before the first frame update
		void Start()
		{
		}

		// Update is called once per frame
		void Update()
		{
			Vector3 localSpeed = transform.InverseTransformDirection(speed);

			GetComponent<Rigidbody>().AddForce(localSpeed);
		}
	}
}