using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SheepAnimation_ViewModel : MonoBehaviour
{
	public Animator  anim;
	public Rigidbody rb;
	public float     speedScale     = 0.25f;
	public float     speedThreshold = 5;

	public List<Transform>  thingsToFling;
	public List<Quaternion> initRotOfThings;

	public float flingAmount;

	public bool  flingToVelocity           = false;
	public float minimumVelocityToFling = 1f;

	// Start is called before the first frame update
	void Start()
	{
		//
		// float velocityMagnitude = rb.velocity.magnitude * speedScale;
		//
		// if (velocityMagnitude > speedThreshold)
		// {
		// 	Animator.speed = velocityMagnitude;
		// }

		initRotOfThings = new List<Quaternion>(thingsToFling.Count);

		for (int index = 0; index < thingsToFling.Count; index++)
		{
			// Debug.Log("New thing to fling:" + thingsToFling[index].name);
			Transform thing = thingsToFling[index];
			initRotOfThings.Add(thing.localRotation);
			// initRotOfThings[index] = thing.rotation;
		}
		
		if (anim != null)
		{
			anim.speed = Random.Range(0.75f, 1.25f);
		}
	}

	void FixedUpdate()
	{
		if (flingToVelocity)
		{
			if (rb.velocity.magnitude > minimumVelocityToFling)
			{
				if (Random.value > 0.8f)
				{
					// Debug.Log("Random Leg fling");
					LegFling();
				}
			}
		}
	}

	public void LegFling()
	{
		for (int index = 0; index < thingsToFling.Count; index++)
		{
			Transform thing = thingsToFling[index];
			thing.localRotation = initRotOfThings[index] * Quaternion.Euler(Random.Range(-flingAmount, flingAmount), Random.Range(-flingAmount, flingAmount), Random.Range(-flingAmount, flingAmount)); // Random.rotation;
		}
	}
}