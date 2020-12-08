using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomProbabilities : MonoBehaviour
{
	public float probability = 0.5f;


    // Update is called once per frame
    void Update()
    {
        // Don't use Update, because it's inconsistent with graphics framerates
    }

	// By default this runs around 60 times a second (regardless of computer speed)
	void FixedUpdate()
	{
		if (Random.Range(1, 6) == 1)
		{
			// Dice throw
		}

		// 'value' is 0.0 to 1.0
		if (Random.value > probability)
		{
			// 0.5 = This is total random like this 01010101110101010101010010101001010100101010010101011011101010101111101001001001001
			// 0.05 = More like this 00000000000010000000000000000000000010000000010000000000000000010000000000000000000010000000000000
		}
		
		// Perlin. This is more like a wave on water or a sound wave. Good for chunks/lumps of random
		// Value between 0.0 and 1.0
		if (Mathf.PerlinNoise(Time.time, 0) > probability)
		{
			// This is happen more like this 000000111110000000000000000111100000000011111111111111100000011111111110000000000000
		}
	}
}
