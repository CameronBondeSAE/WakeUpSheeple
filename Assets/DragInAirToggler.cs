using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragInAirToggler : MonoBehaviour
{
	public LayerMask layerMask;

	float startingDrag;
	float startingAngularDrag;

	Rigidbody rb;

	// Start is called before the first frame update
	void Start()
	{
		rb                  = GetComponent<Rigidbody>();
		startingDrag        = rb.drag;
		startingAngularDrag = rb.angularDrag;
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.layer == layerMask.value)
		{
			rb.drag        = startingDrag;
			rb.angularDrag = startingAngularDrag;
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.layer == layerMask.value)
		{
			rb.drag        = 0;
			rb.angularDrag = 0;
		}
	}
}