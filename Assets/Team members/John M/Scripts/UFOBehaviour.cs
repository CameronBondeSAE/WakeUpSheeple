using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using UnityEngine;
using Random = UnityEngine.Random;

public class UFOBehaviour : MonoBehaviour
{
    //GAME OBJECT HAS BEEN REPURPOSED INTO UFO OBJECT
    //NO LONGER A HELICOPTER
    //RENAME OF FUNCTIONS AND SCRIPT MAY BE REQUIRED
    
    public GameObject UFO;
    
    public List <Transform> SpawnLocations;
    public List <Transform> WaitLocations;
    public List <Transform> ExitLocations;
    
    DelegateStateManager FlyingState = new DelegateStateManager();
    DelegateState spawning = new DelegateState();
    DelegateState waiting = new DelegateState();
    DelegateState exiting = new DelegateState();
    public float move;
    public float sheepMove;
    float timer;

    public int RandomSpawn;
    public int RandomWait;
    public int RandomExit;

    public float PickUpradius;
    //add funnctionality to suck up sheep UFO abduction style
    
    
    
    public void Awake()
    {
        spawning.Update = ToSpawn;
        waiting.Update = WaitingUFO;
        exiting.Update = ExitUFO;
        RandomSpawn = Random.Range(0, SpawnLocations.Count);
        RandomWait = Random.Range(0, WaitLocations.Count);
        RandomExit = Random.Range(0, ExitLocations.Count);
        timer = Random.Range(2,5);
        FlyingState.ChangeState(spawning);
        
        
    }
    void Update()
    {
        FlyingState.UpdateCurrentState();
    }

    

    void ToSpawn()
    {
        transform.position = Vector3.Lerp(transform.position, SpawnLocations[RandomSpawn].position, (move * Time.deltaTime));
        if (Vector3.Distance(transform.position, SpawnLocations[RandomSpawn].position) < 0.1f)
        {
            FlyingState.ChangeState(waiting);
        }
    }

    void WaitingUFO()
    {
       
            transform.position = Vector3.Lerp(transform.position, WaitLocations[RandomWait].position, (move * Time.deltaTime));
            if (Vector3.Distance(transform.position, WaitLocations[RandomWait].position) < 0.1f)
            {
                FlyingState.ChangeState(exiting);
            }  
        
    }

    void ExitUFO()
    {
        timer = timer - Time.deltaTime;
        if (timer < 0)
        {
            transform.position = Vector3.Lerp(transform.position, ExitLocations[RandomExit].position, (move * Time.deltaTime));
        }
        if (Vector3.Distance(transform.position, ExitLocations[RandomExit].position) < 0.1f)
        {
            Destroy(gameObject);
        }  
    }
    //need to have sheep position slowly changed to match the helicopters position when heli goes over the sheep
    //use collider to scan for sheep on the ground
    //sheep caught in collider can use dotween to change position to helicopter position
    void OnTriggerStay(Collider other)
    {
        other.gameObject.transform.position = Vector3.MoveTowards(other.gameObject.transform.position,UFO.transform.position,sheepMove);

        if (Vector3.Distance(transform.position, other.transform.position) < 2f)
        {
            Destroy(other);
        }
        
    
    }
}
