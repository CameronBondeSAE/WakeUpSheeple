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
    [FormerlySerializedAs("bPSR")] public bool bPS; //Bool for out "pausedstate" so we can determine if we are already paused or not
    public AudioSource soundPlayer;
    public float force = 5.0f;
    public Rigidbody rb;
    public int timeWait; //Time wait int for the jump function to determine how long the mole is out of the ground
    [FormerlySerializedAs("timeSWaitR")] public int timeSWait; //Time wait for the pause button so when we click pause it doesn't instantly unpause
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
    private GameObject sheepWaypoint;
    //----------------------------------WAYPOINT VARIABLES
    //----------------------------------EVENT VARIABLES
    public event Action tmpEventStand;
    public event Action tmpEventJump;
    public event Action tmpEventWaypoint;
    //----------------------------------EVENT VARIABLES
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
        sheepWaypoint = GameObject.FindObjectOfType<Sheep>().gameObject; //HACK!!!!!!!!
        waypointsList.Add(sheepWaypoint.transform);
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
        FindObjectOfType<PauseManager>().PauseEvent += pauseEventMole; //Find the pause manager and whenever PauseEvent is called run pauseEvent
        stateManager.ChangeState(standing); //on start set the default state to standing
        rb = GetComponent<Rigidbody>();
        bPS = false;
        //----------------------------------TRIGGER VARIABLES
        //TriggerScriptR = GetComponent<TriggerMoleR>();
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
        if (transform.position.y > -1f) //Changes players height to above / below ground
        {
            rb.AddForce(-transform.up * force);
        }
        else
        {
            timeHoverWait = timeHoverWait + 1;
        }
        if (timeHoverWait > 600 && bPS != true)
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
        if (transform.position.y < 0.3f) //Changes players height to above / below ground
        {
            rb.AddForce(transform.up * force);
        }
        else
        {
            timeWait = timeWait + 1;
        }
        if (timeWait > 300 && bPS != true)
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
    }
    private void moveToWaypointUpdate()
    {
        timeHoverWait = timeHoverWait + 1; //Once trigger is implemented this needs to be changed to another else so it will change the sheep if the timer changes after specified time
        if (Vector3.Distance(transform.position, currentWaypoint.position) > safeDistance) //Takes the distance of our mole to object and compares if it is bigger than safe distance
        {
            Vector3 currentWaypointNoHeight = new Vector3(currentWaypoint.position.x, transform.position.y, currentWaypoint.position.z); //Takes the waypoint position
            transform.LookAt(currentWaypointNoHeight); //Looks at the waypoint
            rb.AddRelativeForce(Vector3.forward * movementSpeed, ForceMode.Force); //Applies force
        }
        else
        { //This is to stop our mole
            rb.isKinematic = true;
            if (timeHoverWait > 1600 && bPS == false)
            {
                stateManager.ChangeState(jump);
                timeHoverWait = 0;
            }
        }
        //
        // Move to a different sheep after a specified set time to add randomness (Also use a trigger to detect how many sheep are in range to activate the popup)
        //
    }
    private void moveToWaypointExit()
    {
        
    }
    //----------------------------------WAYPOINT
    //----------------------------------PAUSE
    private void pauseEventMole()
    {
        if (bPS == false)
        {
            Debug.Log("PausedR");
            bPS = true; //This tells us we are paused
            stateManager.ChangeState(pauseStateMole);
        }
    }
    private void PauseStateMoleStart()
    {
        timeSWait = 0;
        rb.constraints = RigidbodyConstraints.FreezeAll; //Something similar to this can be used above "AMENDMENT"
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
        bPS = false; //Reset our BoolPauseStateR to false so we can use pause again
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
        FindObjectOfType<PauseManager>().PauseEvent -= pauseEventMole;
    }
}
