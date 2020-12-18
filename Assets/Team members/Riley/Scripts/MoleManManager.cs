using System;
using System.Collections;
using System.Collections.Generic;
using System.Media;
using AlexM;
using Mirror;
using UnityEngine;
using UnityEngine.Serialization;

//Problem & Needed code (Solution)

//Mole needs to be unobstructed when coming out of the ground (Use a capsule that runs into the sheep where the mole effect runs along the ground)
//This method adds a problem where the mole cant come out of the ground if there is something directly above (it also fixes this however)
//Movement (Waypoint to a group, check if there are multiple in a radius, then make a path based on the distance that moves in a curve)

public class MoleManManager : NetworkBehaviour
{
    //----------------------------------GENERAL VARIABLES----------------------------------//
    public DelegateStateManager stateManager = new DelegateStateManager();
    public DelegateState standing = new DelegateState();
    public DelegateState jump = new DelegateState();
    public AudioSource soundPlayer;
    public int timeWait; //Time counter for waiting whenever a timer is needed
    private float verticalMovementSpeed = 0.03f;
    public AudioClip jumpAudioClip;
    public AudioClip burrowAudioClip;
    //----------------------------------GENERAL VARIABLES----------------------------------//
    //----------------------------------WAYPOINT VARIABLES----------------------------------//
    public DelegateState moveToWaypoint = new DelegateState();
    public GameObject mainGameManager;
    private Vector3 currentWaypoint;
    private float safeDistance = 2f;
    public GameObject raycastHandler;
    public bool particleOnOff;
    private float distanceToPlatform;
    private CoreSheepFinder gameManager;
    private Vector3 velocity = Vector3.zero;
    private float particleDistanceSafety = 25f;
    //----------------------------------WAYPOINT VARIABLES----------------------------------//
    //----------------------------------EVENT VARIABLES----------------------------------//
    public event Action tmpEventStand;
    public event Action tmpEventJump;
    public event Action tmpEventWaypoint;
    //----------------------------------EVENT VARIABLES----------------------------------//
    //----------------------------------UPDATE/START----------------------------------//
    void Start()
    {
        timeWait = 0;
        //----------------------------------STATE MANAGER VARIABLES----------------------------------//
        moveToWaypoint.Enter = moveToWaypointStart;
        moveToWaypoint.Update = moveToWaypointUpdate;
        moveToWaypoint.Exit = moveToWaypointExit;
        standing.Enter = standingStart;
        standing.Update = standingUpdate;
        standing.Exit = standingExit;
        jump.Enter = jumpStart;
        jump.Update = jumpUpdate; 
        jump.Exit = jumpExit;
        gameManager = mainGameManager.GetComponent<CoreSheepFinder>();
        stateManager.ChangeState(standing); //on start set the default state to standing
        tmpEventStand?.Invoke();
        //----------------------------------STATE MANAGER VARIABLES----------------------------------//
        //----------------------------------INACTIVE VARIABLES----------------------------------//
        //sheepWaypoint = GameObject.FindObjectOfType<Sheep>().gameObject; //HACK for adding sheep
        //waypointsList.Add(sheepWaypoint.transform); //HACK for adding sheep
        //TriggerScriptR = GetComponent<TriggerMoleR>();
        //----------------------------------INACTIVE VARIABLES----------------------------------//
    }
    void Update()
    {
        if (mainGameManager == null)
        {
            Debug.LogWarning("GameManager must be added to mainGameManager");
            return;
        }
        currentWaypoint = gameManager.centerofSheepFlock;
        stateManager.UpdateCurrentState();
        distanceToPlatform = raycastHandler.GetComponent<RaycastHandler>().distanceToPlatformInfo;
    }
    private void FixedUpdate()
    {
        timeWait = timeWait + 1;
    }
    //----------------------------------UPDATE/START----------------------------------//
    //----------------------------------STANDING----------------------------------//
    private void standingStart()
    {
        timeWait = 0;
        tmpEventStand?.Invoke();
        particleOnOff = false;
    }
    private void standingUpdate()
    {
        if (isServer)
        {
            if (distanceToPlatform > 100f)
            {
                float distanceToPlatformExact = distanceToPlatform - 100f;
                Vector3 mainObjectNewLocal = new Vector3(transform.position.x, transform.localPosition.y - distanceToPlatformExact, transform.localPosition.z);
                transform.localPosition = Vector3.Lerp(transform.localPosition, mainObjectNewLocal, verticalMovementSpeed);
            }
            else
            {
                if (timeWait > 400)
                {
                    stateManager.ChangeState(moveToWaypoint);
                }
            }
        }
       
    }
    private void standingExit(){}
    //----------------------------------STANDING----------------------------------//
    //----------------------------------JUMP----------------------------------//
    private void jumpStart()
    {
        soundPlayer.clip = jumpAudioClip;
        soundPlayer.volume = 1f;
        soundPlayer.Play();
        timeWait = 0; //reset our timewait to 0 whenever we start the jump function
        tmpEventJump?.Invoke();
        particleOnOff = false;
    }
    private void jumpUpdate()
    {
        if (distanceToPlatform < 101.75f)
        {
            Vector3 mainObjectNewLocal = new Vector3(transform.localPosition.x, transform.localPosition.y + 1f, transform.localPosition.z);
            transform.localPosition = Vector3.Lerp(transform.localPosition, mainObjectNewLocal, verticalMovementSpeed);
        }
        if (timeWait > 200)
        {
            stateManager.ChangeState(standing);
        }
    }
    private void jumpExit(){}
    private void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(1000);
        }
    }
    //----------------------------------JUMP----------------------------------//
    //----------------------------------WAYPOINT----------------------------------//
    private void moveToWaypointStart()
    {
        soundPlayer.clip = burrowAudioClip;
        soundPlayer.volume = 0.5f;
        soundPlayer.Play();
        tmpEventWaypoint?.Invoke();
        timeWait = 0;
    }
    private void moveToWaypointUpdate()
    {
        if (Vector3.Distance(transform.position, currentWaypoint) < particleDistanceSafety)
        {
            particleOnOff = true;
        }
        if (Vector3.Distance(transform.position, currentWaypoint) > safeDistance)
        {
            Vector3 currentWaypointNoHeight = new Vector3(currentWaypoint.x, transform.position.y, currentWaypoint.z);
            transform.LookAt(currentWaypointNoHeight);
            transform.position = Vector3.SmoothDamp(transform.position, currentWaypointNoHeight, ref velocity, 1.5f);
        }
        else
        {
            if (timeWait > 1000)
            {
                stateManager.ChangeState(jump);
            }
        }
    }
    private void moveToWaypointExit(){}
    //----------------------------------WAYPOINT----------------------------------//
    //----------------------------------BUTTON FUNCTIONS----------------------------------//
    public void ForceJumpState()
    {
        stateManager.ChangeState(jump);
    }
    public void ForceWaypointState()
    {
        stateManager.ChangeState(moveToWaypoint);
    }
    //----------------------------------BUTTON FUNCTIONS----------------------------------//
}
