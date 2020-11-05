using System;
using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using Mirror;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    //Event for players spawned
    public event Action playersSpawnedEvent;

    //Event for actually playing the game
    public event Action GamestartedEvent;

    public event Action YouWonEvent;
    public event Action YouLostEvent;

    public event Action MapOverviewEvent;

    public EndGoalChecker endGoalChecker;

//Will be linked to sheep spawn manager later (TOTAL SHEEP)
    public List<Movement_ForwardAM> sheepInLevel;

   [SerializeField] private GameNetworkManager networkManager;


    private void OnEnable()
    {
        YouWonEvent += EndGoalTrackerWin;
        YouLostEvent += EndGoalTrackerLost;
        GamestartedEvent += Playing;
        playersSpawnedEvent += PlayersSpawned;
        MapOverviewEvent += OverviewOfMap;
    }
    
    private void OnDisable()
    {
        YouWonEvent -= EndGoalTrackerWin;
        YouLostEvent -= EndGoalTrackerLost;
        GamestartedEvent -= Playing;
        playersSpawnedEvent -= PlayersSpawned;
        MapOverviewEvent -= OverviewOfMap;
    }

    public void OverviewOfMap()
    {
        //CONTROLLING THE CAMERA TO SHOW NEW MECHANICS IN THE GAME
        MapOverviewEvent?.Invoke();
    }

    private void PlayersSpawned()
    {
        playersSpawnedEvent?.Invoke();
        GetComponent<ClayDogBehaviour>().controls.Disable();
        // networkManager.SpawnPlayer(conn);
        Debug.Log("GameManager Event: PLAYERS SPAWNER");
    }

    public void Playing()
    {
        GamestartedEvent?.Invoke();
        GetComponent<ClayDogBehaviour>().controls.Enable();
        Debug.Log("GameManager Event: PLAYERS Player Playing");
    }

//TOTAL SHEEP/DYING SHEEP
    public void SheepTracker()
    {
        //TODO
        //KEEP TRACK OF SHEEP HERE LINKING IT TO THE SPAWN MANAGER
        //SPAWN MANAGER WILL KEEP TRACK WILL SPAWN THE AMOUNT OF SHEEP NEEDED
        Debug.Log(sheepInLevel.Count.ToString());

        //Remove sheep from list when it dies

        // foreach (var sheep in sheepinLevel)
        // {
        //     if (sheep.Death)
        //     {
        //         sheepinLevel.Remove(sheep);
        //     }
        // }

        if (sheepInLevel.Count < 0)
        {
            EndGoalTrackerLost();
        }
    }

    //Fire event when all required reach the level
    public void EndGoalTrackerWin()
    {
        //SAFE SHEEP
        endGoalChecker.safeSheep.Count.ToString();
        endGoalChecker.EndGoalReached();
        YouWonEvent?.Invoke();
        Debug.Log("GAME MANAGER: YOU WON THE  GAME ._.");
    }

    public void EndGoalTrackerLost()
    {
        SheepTracker();
        endGoalChecker.EndGoalNotReached();
        YouLostEvent?.Invoke();
        Debug.Log("GAME MANAGER: YOU LOST THE GAME :(");
    }
}