using System;
using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;

public class WolfDetector : MonoBehaviour
{
	private GameNetworkManager gameNetworkManager;
	public  float              radius = 5f;
	public  int                lastAmountOfWolves;

	private void OnEnable()
	{
		gameNetworkManager = FindObjectOfType<GameNetworkManager>();
	}

	public List<PlayerBehaviour> GetNearbyWolves()
	{
		List<PlayerBehaviour> neighbours = new List<PlayerBehaviour>();
		// Collider[] colliders; //Physics.OverlapSphere(transform.position, radius);


		foreach (PlayerBehaviour c in gameNetworkManager.physicalPlayers)
		{
			if (Vector3.Distance(c.transform.position, transform.position) < radius)
			{
				neighbours.Add(c.GetComponent<PlayerBehaviour>());
			}

			//// Is targetDirection sheep?
			// if (c.GetComponent<PlayerBehaviour>())
			// {
			// 	neighbours.Add(c.GetComponent<PlayerBehaviour>());
			// }
		}

		lastAmountOfWolves = neighbours.Count;
		return neighbours;
	}
}