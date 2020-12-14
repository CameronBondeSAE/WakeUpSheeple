using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
	void Start()
	{
		// transform.position = transform.position + Camera.main.transform.rotation * Vector3.forward * 10f;
	}

	void LateUpdate()
	{
		if (!(Camera.main is null))
		{
			transform.LookAt(
							 transform.position + Camera.main.transform.rotation * Vector3.forward,
							 Camera.main.transform.rotation * Vector3.up
							 );
		}
	}

}