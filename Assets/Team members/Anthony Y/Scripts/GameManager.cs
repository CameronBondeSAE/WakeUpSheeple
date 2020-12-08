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
private EndGoalChecker endGoalChecker;
   


    [Header("Sheep in Level")]
//Will be linked to sheep spawn manager later (TOTAL SHEEP)
    public List<Spawner> spawnerList;
    public List<EndGoalChecker> endGoals;
    public List<Sheep> allSheep = new List<Sheep>();
    public List<Sheep> deadSheep = new List<Sheep>();
    public int totalSheep;
    
    
    [Header("Percentage of Sheep")]
   [SerializeField]
    private float percentage;
    public float percentageofSheepNeeded = 75;
    private float percentageIncrease = 0.01f;

   


    void Awake()
    {
       gameNetworkManager = FindObjectOfType<GameNetworkManager>();
       foreach (Spawner spawner in spawnerList)
       {
           if (spawner == null)
           {
               Debug.LogWarning("YOU DONT HAVE THE SHEEP SPAWNER IN THE GAME MANAGER!");
           }
         
           totalSheep += spawner.amount ;
          
           spawner.SpawnedEvent += SheepTracker;
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

    private void Update()
    {
        
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

    [ClientRpc]
   

    [Command]
    void CmdPlayersSpawned(PlayerBehaviour player)
    {
        
    }
    

    public void PlayPhaseStarted()
    {
        GamestartedEvent?.Invoke();
        Debug.Log("GameManager Event: PLAYERS are Playing & player can be moved");
        // GetComponent<PlayerBehaviour>()?.controls.Movement.Movement.Enable();
        //who spawned
    }

//TOTAL SHEEP/DYING SHEEP
    public void SheepTracker(CharacterBase character)
    {
        //TODO
        //KEEP TRACK OF SHEEP HERE LINKING IT TO THE SPAWN MANAGER
        //SPAWN MANAGER WILL KEEP TRACK WILL SPAWN THE AMOUNT OF SHEEP NEEDED
        if (character is Sheep)
        {
            allSheep.Add(character as Sheep);
        }
        

        //Remove sheep from list when it dies

        // foreach ( Sheep sheep in allSheep)
        // {
        //     if ()
        //     {
        //         if (character is Sheep)
        //         {
        //             allSheep.Remove(character as Sheep);
        //             deadSheep.Add(character as Sheep);
        //         }
        //         SheepDiedEvent?.Invoke();
        //     }
        //     
        // }
        
        
        bool goalsMet = true;
        foreach (var goalChecker in endGoals)
        {
            if (goalChecker.safeSheep.Count < goalChecker.sheepRequired)
            {
                goalsMet = false;
                break;
            }
        }

        if (goalsMet)
        {
            EndGoalTrackerWin();
        }
        
        percentage = totalSheep * percentageofSheepNeeded * percentageIncrease;  
        

        if (totalSheep < 0)
        {
            EndGoalTrackerLost(character);
        }
    }

    //Fire event when all required reach the level
    public void EndGoalTrackerWin()
    {
        //SAFE SHEEP
        WonEvent?.Invoke();
        Debug.Log("GAME MANAGER: YOU WON THE  GAME ._.");
    }
    public void EndGoalTrackerLost(CharacterBase character)
    {
        SheepTracker(character);
        LostEvent?.Invoke();
        Debug.Log("GAME MANAGER: YOU LOST THE GAME :(");
    }

    public void EndGoalNotReached()
    {
        if (endGoalChecker.safeSheep.Count < percentage)
        {
            //I dont know how this may work because this will keep spamming the event if there isn't enough sheep
            //in the list
        }
    }
[ClientRpc]
    public void RpcGameOver()
    {
        GameOverEvent?.Invoke();
        Debug.Log("GAME OVER!");
    }
    
    //*****SERVER CODE*********
    [Command]
    public void CmdGameOver()
    {
        RpcGameOver();
    }
}