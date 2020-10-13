using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HeliBehaviour : MonoBehaviour
{
    public Transform[] SpawnLocations;
    public Transform[] WaitLocations;
    public Transform[] ExitLocations;
    
    public DelegateStateManager FlyingState = new DelegateStateManager();
    public DelegateState spawning = new DelegateState();
    public DelegateState waiting = new DelegateState();
    public DelegateState exiting = new DelegateState();
    public float move;
    public float timer = 100;

    public int RandomSpawn;
    public int RandomWait;
    public int RandomExit;
    
    
    //transform.position = Vector3.MoveTowards(transform.position, WaitLocations[1].position, move);
    public void Start()
    {
        //spawning.Enter = SpawnHeli;
        spawning.Update = SpawnHeli;
        waiting.Update = WaitingHeli;
        exiting.Update = ExitHeli;
        
        FlyingState.ChangeState(spawning);

        RandomSpawn = Random.Range(0, SpawnLocations.Length);
        RandomWait = Random.Range(0, WaitLocations.Length);
        RandomExit = Random.Range(0, ExitLocations.Length);
    }
    void Update()
    {
        move = 15 * Time.deltaTime;
        FlyingState.UpdateCurrentState();
    }
    
    void SpawnHeli()
    {
        transform.position = Vector3.MoveTowards(transform.position, SpawnLocations[RandomSpawn].position, move);
        if (Vector3.Distance(transform.position, SpawnLocations[RandomSpawn].position) == 0)
        {
            FlyingState.ChangeState(waiting);
        }
    }

    void WaitingHeli()
    {
       
            transform.position = Vector3.MoveTowards(transform.position, WaitLocations[RandomWait].position, move);
            if (Vector3.Distance(transform.position, WaitLocations[RandomWait].position) == 0)
            {
                FlyingState.ChangeState(exiting);
            }  
        
    }

    void ExitHeli()
    {
        timer = timer - Time.deltaTime;
        if (timer < 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, ExitLocations[RandomExit].position, move);
        }
    }
        






}
