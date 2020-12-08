﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossProductTests : MonoBehaviour
{
	public Vector3 direction1;
	public Vector3 direction2;

	public GameObject directionToTurnTo;
	public GameObject fakeSheep;
	public Rigidbody  rb;
	public float      turnForce = 100f;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		direction1 = directionToTurnTo.transform.forward;
		direction2 = fakeSheep.transform.forward;

		Vector3 cross = Vector3.Cross(direction2, direction1);

		Debug.DrawRay(transform.position, cross, Color.red, 0f, false);
		Debug.Log(Vector3.Dot(direction1, direction2)); //, Color.green, 0f, false);

		rb.AddTorque(cross * (turnForce * Time.deltaTime));
	}
}