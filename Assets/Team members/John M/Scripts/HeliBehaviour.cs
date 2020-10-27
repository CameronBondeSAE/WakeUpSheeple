using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HeliBehaviour : MonoBehaviour
{

    public List <Transform> SpawnLocations;
    public List <Transform> WaitLocations;
    public List <Transform> ExitLocations;
    
    DelegateStateManager FlyingState = new DelegateStateManager();
    DelegateState spawning = new DelegateState();
    DelegateState waiting = new DelegateState();
    DelegateState exiting = new DelegateState();
    float move;
    float timer;

    public int RandomSpawn;
    public int RandomWait;
    public int RandomExit;
    
    
    public void Awake()
    {
        spawning.Update = ToSpawn;
        waiting.Update = WaitingHeli;
        exiting.Update = ExitHeli;
        RandomSpawn = Random.Range(0, SpawnLocations.Count);
        RandomWait = Random.Range(0, WaitLocations.Count);
        RandomExit = Random.Range(0, ExitLocations.Count);
        timer = Random.Range(5, 10);
        FlyingState.ChangeState(spawning);
        
    }
    void Update()
    {
        move = 15 * Time.deltaTime;
        FlyingState.UpdateCurrentState();
        
    }

    

    void ToSpawn()
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
        if (Vector3.Distance(transform.position, ExitLocations[RandomExit].position) == 0)
        {
            Destroy(gameObject);
        }  
    }
}
