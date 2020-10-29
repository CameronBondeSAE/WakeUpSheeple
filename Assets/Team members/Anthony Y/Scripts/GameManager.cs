using System;
using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using Mirror;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action GamestartedEvent;
    public event Action YouWonEvent;
    public event Action YouLostEvent;
    public event Action playersSpawnedEvent; //Event for players spawned

    public EndGoalChecker endGoalChecker;

//Will be linked to sheep spawn manager later
    public List<Movement_ForwardAM> sheepinLevel;
    

    private void Awake()
    {
       
    }

    private void OnEnable()
    {
        YouWonEvent += EndGoalTrackerWin;
        YouLostEvent += EndGoalTrackerLost;
        GamestartedEvent+= Playing;
        playersSpawnedEvent += OnplayersSpawnedEvent;

    }

   

  

    private void OnDisable()
    {
        YouWonEvent -= EndGoalTrackerWin;
        YouLostEvent -= EndGoalTrackerLost;
    }

    private void OnplayersSpawnedEvent()
    {
        playersSpawnedEvent?.Invoke();
        GetComponent<ClayDogBehaviour>().controls.Disable();
    }
    public void Playing()
    {
        GamestartedEvent?.Invoke();
        GetComponent<ClayDogBehaviour>().controls.Enable();
    }

    public void SheepTracker()
    {
        //TODO
        //KEEP TRACK OF SHEEP HERE LINKING IT TO THE SPAWN MANAGER
        //SPAWN MANAGER WILL KEEP TRACK WILL SPAWN THE AMOUNT OF SHEEP NEEDED
        Debug.Log(sheepinLevel.Count.ToString());
        if (sheepinLevel.Count < 0)
        {
            EndGoalTrackerLost();
        }
    }
    //Fire event when all required reach the level
    public void EndGoalTrackerWin()
    { 
        endGoalChecker.safeSheep.Count.ToString();
        endGoalChecker.EndGoalReached();
        YouWonEvent?.Invoke();
    }
    public void EndGoalTrackerLost()
    {
        SheepTracker();
        endGoalChecker.EndGoalNotReached();
        YouLostEvent?.Invoke();
    }
}
