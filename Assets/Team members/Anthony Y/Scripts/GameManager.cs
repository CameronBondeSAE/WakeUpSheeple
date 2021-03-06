﻿using System;
using System.Collections.Generic;
using AlexM;
using Mirror;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : NetworkBehaviour
{
	public GameObject CameraPlayerFollowPrefab;

	[SerializeField]
	private GameNetworkManager gameNetworkManager;

	///Players spawned
	public event Action<NetworkIdentity> playersSpawnedEvent;

	///Actually starting the game
	public event Action GamestartedEvent;

	///Win the game
	public event Action WonEvent;

	///Lose the Game
	public event Action LostEvent;

	///Map mechanics
	public event Action MapOverviewEvent;

	///Game Done, Happens whether you won or lost
	public event Action GameOverEvent;

	///Happens when a sheep is saved
	public event Action SheepSavedEvent;

	///Happens when  a sheep died
	public event Action SheepDiedEvent;

	private EndGoalChecker endGoalChecker;

	[Header("Sheep in Level")]
//Will be linked to sheep spawn manager later (TOTAL SHEEP)
	public List<Spawner> spawnerList;

	public List<EndGoalChecker> endGoals;
	public List<Sheep>          allSheep  = new List<Sheep>();
	public List<Sheep>          deadSheep = new List<Sheep>();

	[SyncVar]
	public int totalSheep;

	[SerializeField]
	bool goalsMet = true;


	[Header("Percentage of Sheep")]
	private float percentageOfSheepNeeded;

	public  float       percentage         = 75;
	private float       percentageIncrease = 0.01f;
	public  LevelLoader levelLoader;


	GameObject cameraFollow;


	void Awake()
	{
		gameNetworkManager = FindObjectOfType<GameNetworkManager>();
		// Forward on the event from Networkmanager to the normal gamemanager for convenience
		if (!(gameNetworkManager is null))
		{
			gameNetworkManager.PhysicalPlayerSpawned += identity => PlayersSpawned(identity);
		}
		// DontDestroyOnLoad(this.gameObject);


		// Proper follow camera for this gamemode (full screen)
		// cameraFollow = Instantiate(CameraPlayerFollowPrefab);
		// CameraPlayer cameraPlayer = FindObjectOfType<CameraPlayer>();
		// if (!(cameraPlayer is null))
		// {
		// 	cameraFollow = cameraPlayer.gameObject;
		// }
		// else
		// {
		// 	Debug.LogError("Needs a cameraFollow prefab", this);
		// }

		foreach (Spawner spawner in spawnerList)
		{
			if (spawner == null)
			{
				Debug.LogWarning("YOU DONT HAVE THE SHEEP SPAWNER IN THE GAME MANAGER!");
			}

			if (!(spawner is null))
			{
				totalSheep += spawner.amount;

				spawner.SpawnedEvent += SpawnSheep;
			}
		}

		// foreach (Sheep sheep in allSheep)
		// {
		//     allSheep.Add(sheep);
		//     totalSheep += allSheep.Count;
		//     Debug.Log(allSheep.Count.ToString());
		// }
		foreach (EndGoalChecker endGoal in endGoals)
		{
			if (endGoal == null)
			{
				Debug.LogWarning("You NEED TO ADD AN END GOAL INTO THE SCENE");
			}

			endGoal.SheepMadeitEvent += SheepTracker;
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();

		PlayPhaseStarted();
	}


	private void OnEnable()
	{
		// WonEvent += EndGoalTrackerWin;
		// LostEvent += EndGoalTrackerLost;
		// // GamestartedEvent += Playing;
		// playersSpawnedEvent += PlayersSpawned;
		// // MapOverviewEvent += OverviewOfMap;
		// // GameOverEvent += GameOver;
		// gameNetworkManager.PhysicalPlayerSpawned += PlayersSpawned;
	}

	private void OnDisable()
	{
		//     WonEvent -= EndGoalTrackerWin;
		//     LostEvent -= EndGoalTrackerLost;
		//     // GamestartedEvent -= Playing;
		//     playersSpawnedEvent -= PlayersSpawned;
		//     // MapOverviewEvent -= OverviewOfMap;
		//     // GameOverEvent -= GameOver;
		// gameNetworkManager.PhysicalPlayerSpawned -= PlayersSpawned;
	}

	private void Update()
	{
	}

	public void OverviewOfMap()
	{
		//CONTROLLING THE CAMERA TO SHOW NEW MECHANICS IN THE GAME
		MapOverviewEvent?.Invoke();
		Debug.Log("SHOWING OVERVIEW OF MAP");
	}

	public void PlayersSpawned(NetworkIdentity networkIdentity)
	{
		// RPCPlayersSpawned(networkIdentity);
		// GetComponent<PlayerBehaviour>()?.controls.Movement.Movement.Disable();
		// networkManager.SpawnPlayer(conn);
	}

	// Mostly used for things like clientside cameras (Could use the OnClient functions from mirror too)
	// [ClientRpc]
	// public void RPCPlayersSpawned(NetworkIdentity networkIdentity)
	// {
	// playersSpawnedEvent?.Invoke(networkIdentity);
	// Debug.Log("GameManager Event: PLAYERS SPAWNED but cannot move");
	// }

	public void PlayPhaseStarted()
	{
		RpcPlayPhaseStarted();
		// GetComponent<PlayerBehaviour>()?.controls.Movement.Movement.Enable();
		//who spawned
	}

	[ClientRpc]
	void RpcPlayPhaseStarted()
	{
		GamestartedEvent?.Invoke();
		Debug.Log("GameManager Event: PLAYERS are Playing & player can be moved");
	}

	void SpawnSheep(CharacterBase character)
	{
		//TODO
		//KEEP TRACK OF SHEEP HERE LINKING IT TO THE SPAWN MANAGER
		//SPAWN MANAGER WILL KEEP TRACK WILL SPAWN THE AMOUNT OF SHEEP NEEDED
		if (character is Sheep)
		{
			allSheep.Add(character as Sheep);
		}
	}

//TOTAL SHEEP/DYING SHEEP
	public void SheepTracker(NetworkIdentity networkIdentity)
	{
		Debug.Log("Sheep tracker called");
		
		//Remove sheep from list when it dies
		if (networkIdentity != null && networkIdentity.GetComponent<Health>().currentHealth < 0)
		{
			if (networkIdentity is Sheep)
			{
				allSheep.Remove(networkIdentity.GetComponent<Sheep>());
				deadSheep.Add(networkIdentity.GetComponent<Sheep>());
			}

			SheepDiedEvent?.Invoke();
		}


		foreach (var goalChecker in endGoals)
		{
			if (goalChecker.safeSheep.Count < goalChecker.sheepRequired)
			{
				goalsMet = false;

				break;
			}
		}

		foreach (var goalChecker in endGoals)
		{
			if (goalChecker.safeSheep.Count >= goalChecker.sheepRequired)
			{
				EndGoalTrackerWin();
				goalsMet = true;

				levelLoader.LoadLevel();
			}
		}

		percentageOfSheepNeeded = totalSheep * percentage * percentageIncrease;


		if (totalSheep <= 0)
		{
			EndGoalTrackerLost(networkIdentity);
		}
	}


	public bool hasWon = false;

	//Fire event when all required reach the level
	public void EndGoalTrackerWin()
	{
		hasWon = true;

		//SAFE SHEEP
		WonEvent?.Invoke();
		Debug.Log("GAME MANAGER: YOU WON THE  GAME ._.");
	}

	public void EndGoalTrackerLost(NetworkIdentity networkIdentity)
	{
		SheepTracker(networkIdentity);
		LostEvent?.Invoke();
		Debug.Log("GAME MANAGER: YOU LOST THE GAME :(");
		hasWon = false;
		hasWon = false;
	}

	public void EndGoalNotReached()
	{
		if (endGoalChecker.safeSheep.Count < percentageOfSheepNeeded)
		{
			//I dont know how this may work because this will keep spamming the event if there isn't enough sheep
			//in the list
		}
	}

	[ClientRpc]
	public void RpcGameOver()
	{
		if (deadSheep.Count < endGoalChecker.sheepRequired / 2)
		{
			GameOverEvent?.Invoke();

			//MusicAudioManager.PlaySFX("GameOverMusic"); 
			Debug.Log("GAME OVER!");
		}
	}

	//*****SERVER CODE*********
	[Command]
	public void CmdGameOver()
	{
		RpcGameOver();
	}
}