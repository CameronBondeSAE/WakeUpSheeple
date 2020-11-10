using System;
using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;

//Problem & Needed code (Solution)

//Mole needs to be unobstructed when coming out of the ground (Use a capsule that runs into the sheep where the mole effect runs along the ground)
//This method adds a problem where the mole cant come out of the ground if there is something directly above (it also fixes this however)
//Movement (Waypoint to a group, check if there are multiple in a radius, then make a path based on the distance that moves in a curve)

public class MoleMachineR : MonoBehaviour
{
    public DelegateStateManager stateManager = new DelegateStateManager();
    public DelegateState standing = new DelegateState();
    public DelegateState jump = new DelegateState();
    public DelegateState pauseStateR = new DelegateState();
    public bool bPSR; //Bool for out "pausedstateR" so we can determine if we are already paused or not
    public AudioSource soundPlayer;
    public float force = 5.0f;
    public Rigidbody rb;
    public int timeWait; //Time wait int for the jump function to determine how long the mole is out of the ground
    public int timeSWaitR; //Time wait for the pause button so when we click pause it doesn't instantly unpause
    public int timeHoverWait;
    //----------------------------------WAYPOINT VARIABLES
    public DelegateState moveToWaypoint = new DelegateState();
    public List<Transform> waypointsList = new List<Transform>();
    private Transform currentWaypoint;
    private int currentWaypointIndex;
    private float safeDistance = 1.5f;
    private int previousWaypointIndex;
    private float movementSpeed = 0.1f;
    public bool waypointFirstRound;
    //----------------------------------WAYPOINT VARIABLES
    //----------------------------------EVENT VARIABLES
    public event Action tmpEventStand;
    public event Action tmpEventJump;
    public event Action tmpEventWaypoint;
    //----------------------------------EVENT VARIABLES
    //----------------------------------TRIGGER VARIABLES
    private TriggerMoleR TriggerScriptR;
    //----------------------------------TRIGGER VARIABLES
    //----------------------------------UPDATE/START
    void Start()
    {
        standing.Enter = standingStart;
        standing.Update = standingUpdate;
        standing.Exit = standingExit;
        jump.Enter = jumpStart;
        jump.Update = jumpUpdate; 
        jump.Exit = jumpExit;
        pauseStateR.Enter = PauseStateRStart;
        pauseStateR.Update = PauseStateRUpdate;
        pauseStateR.Exit = PauseStateRExit;
        FindObjectOfType<PauseManager>().PauseEvent += pauseEventR; //Find the pause manager and whenever PauseEvent is called run pauseEventR
        stateManager.ChangeState(standing); //on start set the default state to standing
        rb = GetComponent<Rigidbody>();
        bPSR = false;
        //----------------------------------WAYPOINT VARIABLES
        moveToWaypoint.Enter = moveToWaypointStart;
        moveToWaypoint.Update = moveToWaypointUpdate;
        moveToWaypoint.Exit = moveToWaypointExit;
        currentWaypointIndex = 0;
        currentWaypoint = waypointsList[currentWaypointIndex];
        waypointFirstRound = false;
        //----------------------------------WAYPOINT VARIABLES
        //----------------------------------TRIGGER VARIABLES
        TriggerScriptR = GetComponent<TriggerMoleR>();
        //----------------------------------TRIGGER VARIABLES
        tmpEventStand?.Invoke();
    }
    void Update()
    {
        stateManager.UpdateCurrentState();
    }
    //----------------------------------UPDATE/START
    //----------------------------------STANDING
    private void standingStart()
    {
        timeHoverWait = 0;
        tmpEventStand?.Invoke();
        rb.drag = 0.05f;
    }
    private void standingUpdate()
    {
        if (transform.position.y > -1f) //NEEDS AMENDING, this makes the player bob at this height
        {
            rb.AddForce(-transform.up * force);
        }
        else
        {
            timeHoverWait = timeHoverWait + 1;
        }
        if (timeHoverWait > 600 && bPSR != true)
        {
            stateManager.ChangeState(moveToWaypoint);
        }
    }
    private void standingExit()
    {
        
    }
    //----------------------------------STANDING
    //----------------------------------JUMP
    private void jumpStart()
    {
        rb.drag = 2.5f;
        soundPlayer.Play();
        timeWait = 0; //reset our timewait to 0 whenever we start the jump function
        rb.velocity = new Vector3(0, 0, 0);
        rb.isKinematic = false;
        tmpEventJump?.Invoke();
    }
    private void jumpUpdate()
    {
        if (transform.position.y < 0.3f) //NEEDS AMENDING, this makes the player bob at this height
        {
            rb.AddForce(transform.up * force);
        }
        else
        {
            timeWait = timeWait + 1;
        }
        if (timeWait > 300 && bPSR != true)
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
        //
        //Use a loop to add all sheep to the list of waypoints
        //
    }
    private void moveToWaypointUpdate()
    {
        //if (Trigger is active) {timeHoverWait = timeHoverWait + 1;} 
        timeHoverWait = timeHoverWait + 1; //Once trigger is implemented this needs to be changed to another else so it will change the sheep if the timer changes after specified time
        if (Vector3.Distance(transform.position, currentWaypoint.position) > safeDistance)
        {
            Vector3 currentWaypointNoHeight = new Vector3(currentWaypoint.position.x, transform.position.y, currentWaypoint.position.z);
            transform.LookAt(currentWaypointNoHeight);
            rb.AddRelativeForce(Vector3.forward * movementSpeed, ForceMode.Force);
        }
        else
        {
            rb.isKinematic = true;
            if (timeHoverWait > 1600 && bPSR == false)
            {
                stateManager.ChangeState(jump);
                timeHoverWait = 0;
            }
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
    private void pauseEventR()
    {
        if (bPSR == false)
        {
            Debug.Log("PausedR");
            bPSR = true; //This tells us we are paused
            stateManager.ChangeState(pauseStateR);
        }
    }
    private void PauseStateRStart()
    {
        timeSWaitR = 0;
        rb.constraints = RigidbodyConstraints.FreezeAll; //Something similar to this can be used above "AMENDMENT"
    }
    private void PauseStateRUpdate()
    {
        timeSWaitR = timeSWaitR + 1; //This is the timer we wait for when we pause to prevent pressing p and instantly un-pausing after a pause (Could be changed)
        if (Input.GetKeyDown(KeyCode.P) && timeSWaitR > 100)
        {
            stateManager.ChangeState(standing);
            Debug.Log("Exiting Pause");
        }
    }
    private void PauseStateRExit()
    {
        bPSR = false; //Reset our BoolPauseStateR to false so we can use pause again
        rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
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
        FindObjectOfType<PauseManager>().PauseEvent -= pauseEventR;
    }
    
}
