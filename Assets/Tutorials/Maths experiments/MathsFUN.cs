using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathsFUN : MonoBehaviour
{
	public LineRenderer LineRenderer;

	public float scale = 5f;

	void Update()
	{
		float y = 0;

		LineRenderer.positionCount = 10;

		float acceleration = 0;

		for (int x = 0; x < 11; x++)
		{
			acceleration = acceleration + 1f;

			y = y + acceleration * scale;

			// Visualise
			LineRenderer.SetPosition(x, new Vector3(x, y, 0));
		}
	}
}