using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGarbage : MonoBehaviour
{
	public int amount = 100;

	Vector3 v3    = new Vector3();
	Vector3 total = Vector3.zero;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		for (int i = 0; i < amount; i++)
		{
			v3.x  =  Random.Range(0, 100);
			v3.y  =  Random.Range(0, 100);
			v3.z  =  Random.Range(0, 100);
			total += v3;
		}

		Debug.Log(total);
	}
}