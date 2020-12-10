using System;
using System.Collections;
using System.Collections.Generic;
using System.Media;
using AlexM;
using UnityEngine;
using UnityEngine.Serialization;

//Problem & Needed code (Solution)

//Mole needs to be unobstructed when coming out of the ground (Use a capsule that runs into the sheep where the mole effect runs along the ground)
//This method adds a problem where the mole cant come out of the ground if there is something directly above (it also fixes this however)
//Movement (Waypoint to a group, check if there are multiple in a radius, then make a path based on the distance that moves in a curve)

public class MoleManManager : MonoBehaviour
{
    public DelegateStateManager stateManager = new DelegateStateManager();
    public DelegateState standing = new DelegateState();
    public DelegateState jump = new DelegateState();
    [FormerlySerializedAs("pauseStateR")] public DelegateState pauseStateMole = new DelegateState();
    [FormerlySerializedAs("bPSR")] public bool boolPauseState; //Bool for out "pausedstate" so we can determine if we are already paused or not
    public AudioSource soundPlayer;
    public GameObject MainObject;
    public int timeWait; //Time wait int for the jump function to determine how long the mole is out of the ground
    [FormerlySerializedAs("timeSWaitR")] public int timeSWait; //Time wait for the pause button so when we click pause it doesn't instantly unpause
    public int timeHoverWait;
    private float verticalMovementSpeed = 0.03f;
    //----------------------------------WAYPOINT VARIABLES
    public DelegateState moveToWaypoint = new DelegateState();
    public List<Transform> waypointsList = new List<Transform>();
    public GameObject mainObjective;
    private Transform currentWaypoint;
    private int currentWaypointIndex;
    private float safeDistance = 1.5f;
    private int previousWaypointIndex;
    private float horizontalMovementSpeed = 0.0075f;
    public bool waypointFirstRound;
    private GameObject sheepWaypoint;
    public GameObject raycastHandler;
    public bool particleOnOff;
    private float distanceToPlatform;
    //----------------------------------WAYPOINT VARIABLES
    //----------------------------------EVENT VARIABLES
    public event Action tmpEventStand;
    public event Action tmpEventJump;
    public event Action tmpEventWaypoint;
    //----------------------------------EVENT VARIABLES
    //----------------------------------TRIGGER VARIABLES
    //private TriggerMoleR TriggerScriptR;
    //----------------------------------TRIGGER VARIABLES
    //----------------------------------UPDATE/START
    void Start()
    {
        //----------------------------------WAYPOINT VARIABLES
        moveToWaypoint.Enter = moveToWaypointStart;
        moveToWaypoint.Update = moveToWaypointUpdate;
        moveToWaypoint.Exit = moveToWaypointExit;
        currentWaypointIndex = 0;
        currentWaypoint = waypointsList[currentWaypointIndex];
        waypointFirstRound = false;
        //sheepWaypoint = GameObject.FindObjectOfType<Sheep>().gameObject; //HACK!!!!!!!!
        //waypointsList.Add(sheepWaypoint.transform);
        //----------------------------------WAYPOINT VARIABLES
        standing.Enter = standingStart;
        standing.Update = standingUpdate;
        standing.Exit = standingExit;
        jump.Enter = jumpStart;
        jump.Update = jumpUpdate; 
        jump.Exit = jumpExit;
        pauseStateMole.Enter = PauseStateMoleStart;
        pauseStateMole.Update = PauseStateMoleUpdate;
        pauseStateMole.Exit = PauseStateMoleExit;
        //FindObjectOfType<PauseManager>().PauseEvent += pauseEventMole; //Find the pause manager and whenever PauseEvent is called run pauseEventR
        stateManager.ChangeState(standing); //on start set the default state to standing
        boolPauseState = false;
        //----------------------------------TRIGGER VARIABLES
        //TriggerScriptR = GetComponent<TriggerMoleR>();
        //----------------------------------TRIGGER VARIABLES
        tmpEventStand?.Invoke();
    }
    void Update()
    {
        if (waypointsList == null)
        {
            Debug.LogWarning("Waypoints MUST be added to the waypointsList");
            return;
        }
        stateManager.UpdateCurrentState();
        distanceToPlatform = raycastHandler.GetComponent<RaycastHandler>().distanceToPlatformInfo;
    }
    //----------------------------------UPDATE/START
    //----------------------------------STANDING
    private void standingStart()
    {
        timeHoverWait = 0;
        tmpEventStand?.Invoke();
        particleOnOff = false;
    }
    private void standingUpdate()
    {
        if (distanceToPlatform > 100f)
        {
            float distanceToPlatformExact = distanceToPlatform - 100f;
            if (!(MainObject is null))
            {
                Vector3 mainObjectNewLocal = new Vector3(MainObject.transform.position.x, MainObject.transform.localPosition.y - distanceToPlatformExact, MainObject.transform.localPosition.z);
                MainObject.transform.localPosition = Vector3.Lerp(MainObject.transform.localPosition, mainObjectNewLocal, verticalMovementSpeed);
            }
            else
            {
                Debug.Log("Main Object is not assigned");
            }
        }
        else
        {
            timeHoverWait = timeHoverWait + 1;
            if (timeHoverWait > 600 && boolPauseState != true)
            {
                stateManager.ChangeState(moveToWaypoint);
            }
        }
    }
    private void standingExit()
    {
        
    }
    //----------------------------------STANDING
    //----------------------------------JUMP
    private void jumpStart()
    {
        soundPlayer.Play();
        timeWait = 0; //reset our timewait to 0 whenever we start the jump function
        tmpEventJump?.Invoke();
        particleOnOff = false;
    }
    private void jumpUpdate()
    {
        if (distanceToPlatform < 101.75f) //NEEDS AMENDING, this makes the player bob at this height
        {
            Vector3 mainObjectNewLocal = new Vector3(MainObject.transform.localPosition.x, MainObject.transform.localPosition.y + 1f, MainObject.transform.localPosition.z);
            MainObject.transform.localPosition = Vector3.Lerp(MainObject.transform.localPosition, mainObjectNewLocal, verticalMovementSpeed);
        }
        else
        {
            timeWait = timeWait + 1;
        }
        if (timeWait > 300 && boolPauseState != true)
        {
            stateManager.ChangeState(standing);
        }
    }
    private void jumpExit()
    {
        waypointFirstRound = false;
    }
    //----------------------------------JUMP
    //----------------------------------WAYPOINT
    private void moveToWaypointStart()
    {
        timeHoverWait = 0;
        if (currentWaypointIndex == 0 && waypointFirstRound == false)
        {
            waypointFirstRound = true;
            currentWaypointIndex = 0;
            currentWaypoint = waypointsList[currentWaypointIndex];
        }
        else
        {
            currentWaypointIndex = currentWaypointIndex + 1;
            currentWaypoint = waypointsList[currentWaypointIndex];
        }
        tmpEventWaypoint?.Invoke();
        particleOnOff = true;
    }
    private void moveToWaypointUpdate()
    {
        //if (Trigger is active) {timeHoverWait = timeHoverWait + 1;} 
        timeHoverWait = timeHoverWait + 1; //Once trigger is implemented this needs to be changed to another else so it will change the sheep if the timer changes after specified time
        if (!(currentWaypoint is null) && Vector3.Distance(MainObject.transform.position, currentWaypoint.position) > safeDistance)
        {
            Vector3 currentWaypointNoHeight = new Vector3(currentWaypoint.position.x, MainObject.transform.position.y, currentWaypoint.position.z);
            transform.LookAt(currentWaypointNoHeight);
            MainObject.transform.position = Vector3.Lerp(MainObject.transform.position, currentWaypointNoHeight, horizontalMovementSpeed);
        }
        if (timeHoverWait > 1600 && boolPauseState == false)
        {
            stateManager.ChangeState(jump);
            timeHoverWait = 0;
        }
    }
    //
    // Move to a different sheep after a specified set time to add randomness (Also use a trigger to detect how many sheep are in range to activate the popup)
    //
    private void moveToWaypointExit()
    {
        
    }
    //----------------------------------WAYPOINT
    //----------------------------------PAUSE
    private void pauseEventMole()
    {
        if (boolPauseState == false)
        {
            Debug.Log("PausedR");
            boolPauseState = true; //This tells us we are paused
            stateManager.ChangeState(pauseStateMole);
        }
    }
    private void PauseStateMoleStart()
    {
        timeSWait = 0;
        MainObject.transform.position = MainObject.transform.up;
    }
    private void PauseStateMoleUpdate()
    {
        timeSWait = timeSWait + 1; //This is the timer we wait for when we pause to prevent pressing p and instantly un-pausing after a pause (Could be changed)
        if (Input.GetKeyDown(KeyCode.P) && timeSWait > 100)
        {
            stateManager.ChangeState(standing);
            Debug.Log("Exiting Pause");
        }
    }
    private void PauseStateMoleExit()
    {
        boolPauseState = false; //Reset our BoolPauseStateR to false so we can use pause again
    }
    //----------------------------------PAUSE
    //----------------------------------BUTTON FUNCTIONS
    public void ForceJumpState()
    {
        stateManager.ChangeState(jump);
    }

    public void ForceWaypointState()
    {
        stateManager.ChangeState(moveToWaypoint);
    }
    //----------------------------------BUTTON FUNCTIONS
    private void OnDisable()
    { 
        //FindObjectOfType<PauseManager>().PauseEvent -= pauseEventMole;
    }
    
}
