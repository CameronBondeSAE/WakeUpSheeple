using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAnimation_ViewModel : MonoBehaviour
{
	public Animator  Animator;
	public Rigidbody rb;
	public float     speedScale     = 0.25f;
	public float     speedThreshold = 5;

	public List<Transform>  thingsToFling;
	public List<Quaternion> initRotOfThings;

	public float flingAmount;

    // Start is called before the first frame update
    void Start()
	{
		Animator.speed = Random.Range(0.75f, 1.25f);
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
			Transform thing = thingsToFling[index];
			initRotOfThings.Add(thing.rotation);
			// initRotOfThings[index] = thing.rotation;
		}
	}

    public void LegFling()
	{
		for (int index = 0; index < thingsToFling.Count; index++)
		{
			Transform thing = thingsToFling[index];
			thing.rotation = initRotOfThings[index] * Quaternion.Euler(Random.Range(-flingAmount, flingAmount), Random.Range(-flingAmount, flingAmount), Random.Range(-flingAmount, flingAmount));// Random.rotation;
		}
	}
}
