using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantVelocity : MonoBehaviour
{
	public Vector3 velocity;
	Rigidbody      rb;

	// Start is called before the first frame update
	void Start()
	{
		rb          = GetComponent<Rigidbody>();
		rb.velocity = velocity;
	}
}