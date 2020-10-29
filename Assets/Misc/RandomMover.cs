using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMover : MonoBehaviour
{
	public bool  randomWibble = true;
	Vector3      startPos;
	public float amount = 3f;

	// Start is called before the first frame update
    void Start()
	{
		startPos = transform.position;
	}

    // Update is called once per frame
    void Update()
    {
		if (randomWibble)
		{
			transform.position = startPos + new Vector3(-amount/2f,0,-amount/2f) + new Vector3(Mathf.PerlinNoise(0, Time.time), 0, Mathf.PerlinNoise(0, 10000+Time.time)) * amount;
		}
	}
}
