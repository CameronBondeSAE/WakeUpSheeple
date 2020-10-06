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
    public AudioSource soundPlayer;
    public float force = 5.0f;
    public Rigidbody rb;

    public int timeWait;
    void Start() // Start is called before the first frame update
    {
        standing.Enter = standingStart; //sets the standing function enter called standingEnter
        standing.Update = standingUpdate;
        standing.Exit = standingExit;
        jump.Enter = jumpStart;
        jump.Update = jumpUpdate;
        jump.Exit = jumpExit;
        //
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
        //
        stateManager.ChangeState(standing); //on start set the default state to standing
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        stateManager.UpdateCurrentState(); //refreshes our state each frame of the script running (Delta time)
    }
    private void standingStart() //makes the previously assigned "standing.Enter" function
    {
        
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
}
