using System;
using System.Collections;
using System.Collections.Generic;
using AlexM;
using AnthonyY;
using Mirror;
using Mirror.Examples.Chat;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;
using Random = System.Random;

public class GameManager : NetworkBehaviour
{
    
    [SerializeField]
    private GameNetworkManager gameNetworkManager;
    ///Players spawned
    public event Action<PlayerBehaviour> playersSpawnedEvent;

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
    
    public EndGoalChecker endGoalChecker;


    [Header("Sheep in Level")]
//Will be linked to sheep spawn manager later (TOTAL SHEEP)
    public List<Sheep> sheepInLevel;
    public List<Sheep> deadSheep;
    
    [Header("Percentage of Sheep")]
    private float percentageOfSheepNeeded;
    public float percentage = 75;
    private float percentageIncrease = 0.01f;
    

    private void OnEnable()
    {
        // WonEvent += EndGoalTrackerWin;
        // LostEvent += EndGoalTrackerLost;
        // // GamestartedEvent += Playing;
        // playersSpawnedEvent += PlayersSpawned;
        // // MapOverviewEvent += OverviewOfMap;
        // // GameOverEvent += GameOver;
        gameNetworkManager.PhysicalPlayerSpawned += PlayersSpawned;
    }

    private void OnDisable()
    {
    //     WonEvent -= EndGoalTrackerWin;
    //     LostEvent -= EndGoalTrackerLost;
    //     // GamestartedEvent -= Playing;
    //     playersSpawnedEvent -= PlayersSpawned;
    //     // MapOverviewEvent -= OverviewOfMap;
    //     // GameOverEvent -= GameOver;
    gameNetworkManager.PhysicalPlayerSpawned -= PlayersSpawned;
    }

    public void OverviewOfMap()
    {
        //CONTROLLING THE CAMERA TO SHOW NEW MECHANICS IN THE GAME
        MapOverviewEvent?.Invoke();
        Debug.Log("SHOWING OVERVIEW OF MAP");
    }

    public void PlayersSpawned(PlayerBehaviour player)
    {
        playersSpawnedEvent?.Invoke(player);
        Debug.Log("GameManager Event: PLAYERS SPAWNED but cannot move");
      
        // GetComponent<PlayerBehaviour>()?.controls.Movement.Movement.Disable();
       // networkManager.SpawnPlayer(conn);
    }

    public void PlayPhaseStarted()
    {
        GamestartedEvent?.Invoke();
        Debug.Log("GameManager Event: PLAYERS are Playing & player can be moved");
        // GetComponent<PlayerBehaviour>()?.controls.Movement.Movement.Enable();
        //who spawned
    }

//TOTAL SHEEP/DYING SHEEP
    public void SheepTracker()
    {
        //TODO
        //KEEP TRACK OF SHEEP HERE LINKING IT TO THE SPAWN MANAGER
        //SPAWN MANAGER WILL KEEP TRACK WILL SPAWN THE AMOUNT OF SHEEP NEEDED
        Debug.Log(sheepInLevel.Count.ToString());
        
       
        //Remove sheep from list when it dies

        // foreach (var sheep in sheepInLevel)
        // {
        //     if (sheep.GetComponent<Health>().Death())
        //     {
        //         sheepinLevel.Remove(sheep);
        //         deadSheep.Add();
        //     }
        // }
        
        
        percentageOfSheepNeeded = sheepInLevel.Count * percentage * percentageIncrease;  
        

        if (sheepInLevel.Count < 0)
        {
            EndGoalTrackerLost();
        }
    }

    //Fire event when all required reach the level
    public void EndGoalTrackerWin()
    {
        //SAFE SHEEP
        if (endGoalChecker.safeSheep.Count >= percentageOfSheepNeeded)
        {
            endGoalChecker.safeSheep.Count.ToString();
            WonEvent?.Invoke();
            Debug.Log("GAME MANAGER: YOU WON THE  GAME ._.");
        }
    }
    public void EndGoalTrackerLost()
    {
        SheepTracker();
        LostEvent?.Invoke();
        Debug.Log("GAME MANAGER: YOU LOST THE GAME :(");
    }

    public void EndGoalNotReached()
    {
        if (endGoalChecker.safeSheep.Count < percentageOfSheepNeeded)
        {
            //I dont know how this may work because this will keep spamming the event if there isn't enough sheep
            //in the list
        }
    }

    public void GameOver()
    {
        GameOverEvent?.Invoke();
        Debug.Log("GAME OVER!");
    }
}