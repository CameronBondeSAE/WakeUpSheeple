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
    
    //Big changes made to code of the UFO - now functions better by detecting the flock of sheep rather than having set positions
    //previous code has been commented out at bottom of script
    
    public GameObject UFO;
    public GameManager gameManager;
    public CoreSheepFinder coreSheepFinder;
    private Vector3 startPosition;
    private Vector3 exitPosition;
    public float move;
    public float sheepMove;
    
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        UfoBehaviour();
    }

    public void UfoBehaviour()
    {
        StartCoroutine(UFORoutine());
    }

    IEnumerator UFORoutine()
    {
        coreSheepFinder = gameManager.GetComponent<CoreSheepFinder>();
        startPosition = coreSheepFinder.centerofSheepFlock + new Vector3(-100, 100, -50);
        exitPosition = coreSheepFinder.centerofSheepFlock + new Vector3(100, 100, 100);
        transform.position = Vector3.Lerp(transform.position, coreSheepFinder.centerofSheepFlock, (move * Time.deltaTime));
        yield return new WaitForSeconds(4);
        transform.position = Vector3.Lerp(transform.position, exitPosition,(move * Time.deltaTime));
        Destroy(UFO);

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
    
    /*public List <Transform> SpawnLocations;
    public List <Transform> WaitLocations;
    public List <Transform> ExitLocations;
    DelegateStateManager FlyingState = new DelegateStateManager();
    DelegateState spawning = new DelegateState();
    DelegateState waiting = new DelegateState();
    DelegateState exiting = new DelegateState();
    public float move;
    public float sheepMove;
    float timer;
    public float PickUpradius;
   
    public void Awake()
    {
        //spawning.Update = ToSpawn;
        //waiting.Update = WaitingUFO;
        //exiting.Update = ExitUFO;
        //RandomSpawn = Random.Range(0, SpawnLocations.Count);
        //RandomWait = Random.Range(0, WaitLocations.Count);
        //RandomExit = Random.Range(0, ExitLocations.Count);
        //timer = Random.Range(2,5);
        //FlyingState.ChangeState(spawning);
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
    */
}
