using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Profiling;

public class ThreadTest : MonoBehaviour
{
	public float total = 0;
	object       aLock;

    // Start is called before the first frame update
    void Start()
	{
		for (int i = 0; i < 100; i++)
		{
			Thread thread = new Thread(DoASlowThing);
			thread.Start();
		}
	}

	public void DoASlowThing()
	{
		Debug.Log("Doing a thing");

		for (int i = 0; i < 10000000; i++)
		{
			lock (aLock)
			{
				total += Mathf.PerlinNoise(i, 0);
			}
		}
	
		Debug.Log("Finished doing a thing : Total = "+total);
	}
}
