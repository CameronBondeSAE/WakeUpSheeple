using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

// PickARandomAngle
// Move to the edge of the level
// Find the center of the biggest flock

public class CamsDude_Model : CharacterBase
{
	public event Action<string> doSomethingEvent;
	public Material             clay;
	public event Action         JumpEvent;

	public float health;
	
	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("Test");
	}
	
	// Update is called once per frame
	void Update()
	{
		if(health<=0)
			Destroy(gameObject);
		
		
		if (Input.GetKeyDown(KeyCode.C))
		{
			GetBigOrDieTrying();
			doSomethingEvent?.Invoke("Cam woz ere!");
			JumpEvent?.Invoke();
		}
		
		
		GetComponent<Renderer>().material.SetInt("RotationAmount", Random.Range(0, 360));
		// clay.SetInt("RotationAmount", Random.Range(0,360));
	}

	public void GetBigOrDieTrying()
	{
		transform.localScale = new Vector3(4f, 4f, 4f);
	}
}