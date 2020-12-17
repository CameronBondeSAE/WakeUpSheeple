using System.Collections.Generic;
using AnthonyY;
using UnityEngine;

public class TurnAwayBehaviour : MonoBehaviour
{
	public Vector3 targetDirection;
	public Vector3 myPos;
	public PlayerBehaviour target;
	public Rigidbody rb;

	public float turnForce;
	//private float dogDistance;

	private List<PlayerBehaviour> ListOfWolves;
	private float wolfDist;
	private WolfDetector _wolfDetector;

	/// <summary>
	/// Possibly change this to OnEnable, see if that fixes the issue with the game manager restarting the game and everything breaking.
	/// </summary>
	private void Start()
	{
		_wolfDetector = GetComponent<WolfDetector>();
		//target = FindObjectOfType<PlayerBehaviour>();
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		//Populate list of potential wolves
		ListOfWolves = _wolfDetector.GetNearbyWolves();
		//Loop Through the list.
		foreach (var Wolf in ListOfWolves)
		{
			wolfDist = new float();
			wolfDist = Vector3.Distance(transform.position, Wolf.transform.position);
			target = Wolf;
			//Debug.Log(Wolf.transform.name + " is " + wolfDist + " away.");

			if (target)
			{
				targetDirection = target.transform.position - rb.position;
			}
			else
			{
				return;
			}

			myPos = transform.forward;

			Vector3 cross = Vector3.Cross(targetDirection, myPos);

			//Debug.DrawRay(transform.position, cross, Color.red, 0f, false);
			//Debug.Log(Vector3.Dot(targetDirection, myPos));
			rb.AddTorque((cross * (turnForce * Time.deltaTime)) / (wolfDist * 2f));
		}
	}
}