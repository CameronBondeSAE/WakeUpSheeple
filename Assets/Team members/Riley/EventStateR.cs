using System;
using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;

//Problem & Needed code (Solution)

//Mole needs to be unobstructed when coming out of the ground (Use a capsule that runs into the sheep where the mole effect runs along the ground)
//This method adds a problem where the mole cant come out of the ground if there is something directly above (it also fixes this however)
//Movement (Waypoint to a group, check if there are multiple in a radius, then make a path based on the distance that moves in a curve)

public class EventStateR : MonoBehaviour
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
    private float safeDistance = 0.8f;
    private int previousWaypointIndex;
    private float movementSpeed = 0.05f;
    public bool waypointFirstRound;
    //----------------------------------WAYPOINT VARIABLES
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
    }
    private void standingUpdate()
    {
        timeHoverWait = timeHoverWait + 1;
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
        soundPlayer.Play();
        timeWait = 0; //reset our timewait to 0 whenever we start the jump function
    }
    private void jumpUpdate()
    {
        if (transform.position.y < 0.8f) //NEEDS AMENDING, this makes the player bob at this height
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
        //else
        //{
            //currentWaypointIndex = currentWaypointIndex + 1;
            //currentWaypoint = waypointsList[currentWaypointIndex];
        //}
        
    }
    private void moveToWaypointUpdate()
    {
        timeHoverWait = timeHoverWait + 1;
        
        if (Vector3.Distance(transform.position, currentWaypoint.position) > safeDistance)
        {
            transform.LookAt(currentWaypoint);
            rb.AddRelativeForce(Vector3.forward * movementSpeed, ForceMode.Force);
        }
        else
        {
            if (timeHoverWait > 1600 && bPSR == false)
            {
                stateManager.ChangeState(jump);
            }
        }
    }
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
        rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }
    //----------------------------------PAUSE
    private void OnDisable()
    { 
        FindObjectOfType<PauseManager>().PauseEvent -= pauseEventR;
    }
}