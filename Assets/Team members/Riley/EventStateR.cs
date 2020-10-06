using System;
using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;

public class EventStateR : MonoBehaviour
{
    public DelegateStateManager stateManager = new DelegateStateManager(); //create a delegatestatemanager to the term stateManager
    public DelegateState standing = new DelegateState(); //make two delegatestates from the delegatestate script called standing and jump to use in our functions from the script
    public DelegateState jump = new DelegateState();
    //
    public DelegateState forward = new DelegateState();
    public DelegateState left = new DelegateState();
    public DelegateState right = new DelegateState();
    public DelegateState back = new DelegateState();
    //
    public DelegateState rileyPState = new DelegateState();
    public bool bPSR;

    public AudioSource soundPlayer;
    public float force = 5.0f;
    public Rigidbody rb;

    public int timeWait;
    public int timeSWaitR;
    void Start() // Start is called before the first frame update
    {
        standing.Enter = standingStart; //sets the standing function enter called standingEnter
        standing.Update = standingUpdate;
        standing.Exit = standingExit;
        jump.Enter = jumpStart;
        jump.Update = jumpUpdate;
        jump.Exit = jumpExit;
        //Unneeded Movement using state
        forward.Enter = forwardStart;
        forward.Update = forwardUpdate;
        forward.Exit = forwardExit;
        left.Enter = leftStart;
        left.Update = leftUpdate;
        left.Exit = leftExit;
        right.Enter = rightStart;
        right.Update = rightUpdate;
        right.Exit = rightExit;
        back.Enter = backStart;
        back.Update = backUpdate;
        back.Exit = backExit;
        //Unneeded Movement using state
        rileyPState.Enter = rileyPStateStart;
        rileyPState.Update = rileyPStateUpdate;
        rileyPState.Exit = rileyPStateExit;
        //Find the pause manager and whenever PauseEvent is called run pauseEventR
        FindObjectOfType<PauseManager>().PauseEvent += pauseEventR;
        //on start set the default state to standing
        stateManager.ChangeState(standing); 
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    private void pauseEventR() //Makes functions run whenever PauseEvent is called
    {
        if (bPSR == false) //This allows us to only use BoolPauseStateR to determine if we are already paused or not
        {
            Debug.Log("PausedR"); //Our debug message for paused
            bPSR = true; //This tells us we are paused
            stateManager.ChangeState(rileyPState); //This sends us to the paused state
        }
    }
    void Update()
    {
        stateManager.UpdateCurrentState(); //refreshes our state each frame of the script running (Delta time)
    }
    private void standingStart() //makes the previously assigned "standing.Enter" function
    {
        bPSR = false;
    }
    private void standingUpdate() //our standing update constantly refreshes
    {
        if (Input.GetKeyDown(KeyCode.Space)) //when we press space the next function activates
        {
            stateManager.ChangeState(jump); //change our current state to "jump"
        }
        //
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            stateManager.ChangeState(forward);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            stateManager.ChangeState(left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            stateManager.ChangeState(right);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            stateManager.ChangeState(back);
        }
        //
    }
    private void standingExit()
    {
        
    }
    private void jumpStart()
    {
        soundPlayer.Play();
        timeWait = 0;
    }
    private void jumpUpdate() //our jump state update constantly refreshes
    {
        if (transform.position.y < 0.8f)
        {
            rb.AddForce(transform.up * force);
        }
        else
        {
            timeWait = timeWait + 1;
        }
        if (timeWait > 300)
        {
            stateManager.ChangeState(standing);//we can change our state back to standing here
        }
    }
    private void jumpExit()
    {
        
    }
    //
    private void forwardStart()
    {
        
    }
    private void forwardUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            stateManager.ChangeState(standing);    
        }
        else
        {
            rb.AddForce(transform.forward * force);
        }
    }
    private void forwardExit()
    {
        
    }
    private void leftStart()
    {
        
    }
    private void leftUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            stateManager.ChangeState(standing);    
        }
        else
        {
            rb.AddForce(transform.right * -force);
        }
    }
    private void leftExit()
    {
        
    }
    private void rightStart()
    {
        
    }
    private void rightUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            stateManager.ChangeState(standing);    
        }
        else
        {
            rb.AddForce(transform.right * force);
        }
    }
    private void rightExit()
    {
        
    }
    private void backStart()
    {
        
    }
    private void backUpdate()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            stateManager.ChangeState(standing);    
        }
        else
        {
            rb.AddForce(transform.forward * -force);
        }
    }
    private void backExit()
    {
        
    }
    //
    private void rileyPStateStart()
    {
        //Making the initial timer value worth 0 whenever we enter pause
        timeSWaitR = 0;
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
    }
    private void rileyPStateUpdate()
    {
        //This is the timer we wait for when we pause
        timeSWaitR = timeSWaitR + 1;
        //If we get the pause key again but this time we have a time delay so it wont activate and deactivate instantly
        if (Input.GetKeyDown(KeyCode.P) && timeSWaitR > 50)
        {
            //Change our state back to standing so we can return the system however we want.
            stateManager.ChangeState(standing);
            //Give a debug so we know the system is working
            Debug.Log("Exiting Pause");
        }
    }
    private void rileyPStateExit()
    {
        //Reset our BoolPauseStateR to false
        bPSR = false;
        rb.constraints = RigidbodyConstraints.None;
    }

    private void OnDisable()
    {
        FindObjectOfType<PauseManager>().PauseEvent -= pauseEventR;
    }
}
