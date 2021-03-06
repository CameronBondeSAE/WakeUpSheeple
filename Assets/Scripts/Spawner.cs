﻿using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : NetworkBehaviour
{
	public GameObject                  prefab;
	public float                       radius;
	public int                         amount;
	public event Action<CharacterBase> SpawnedEvent;

	// Start is called before the first frame update
	public override void OnStartServer()
	{
		base.OnStartServer();
		for (int i = 0; i < amount; i++)
		{
			Vector2 insideUnitCircle       = Random.insideUnitCircle;
			Vector3 randomInsideUnitCircle = new Vector3(insideUnitCircle.x, 0, insideUnitCircle.y);

			GameObject newGo = Instantiate(prefab, transform.position + (randomInsideUnitCircle * radius), Quaternion.Euler(0, Random.Range(0, 360), 0));


			newGo.name = prefab.name + " " + i.ToString("##");

			NetworkServer.Spawn(newGo);

			SpawnedEvent?.Invoke(newGo.GetComponent<CharacterBase>());
		}
	}
}