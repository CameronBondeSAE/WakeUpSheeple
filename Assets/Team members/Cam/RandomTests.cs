using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTests : MonoBehaviour
{
	public float amount;
	public float newShade;

	public float perlinY;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		// float newShade = Random.Range(0, amount);
		newShade = Mathf.PerlinNoise(0, Time.time*1f);

		if (newShade > 0.5f)
		{
			transform.Rotate(0,Time.deltaTime*50f,0);
				
			// GetComponent<Rigidbody>().AddForce(0,jumpHeight,0, ForceMode.VelocityChange);
		}
		
		GetComponent<Renderer>().material.color = new Color(newShade, newShade, newShade);
		transform.localPosition = new Vector3(0,newShade,0);
	}
}