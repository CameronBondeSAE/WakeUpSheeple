using UnityEngine;


namespace Tim
{
    

public class StatemachineTest : CharacterBase
{
    public DelegateStateManager DelegateStateManager = new DelegateStateManager();

    public DelegateState idle = new DelegateState();
    public DelegateState jump = new DelegateState();
    public DelegateState movement = new DelegateState();
    
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(message:"Press space to test if code works");
        idle.Enter = OnIdleEnter;
        idle.Update = OnIdleUpdate;
        idle.Exit = OnIdleExit;

        jump.Enter = OnJumpEnter;
        jump.Update = OnJumpUpdate;
        jump.Exit = OnJumpExit;

        movement.Enter = OnMovementEnter;
        movement.Update = OnMovementUpdate;
        movement.Exit = OnMovementExit;
        
        
        DelegateStateManager.ChangeState(idle);

    }
    
    // private void OnPauseEvent()
    // {
    //     Debug.Log("Tim Pause");
    // }
    // private void OnEnable()
    // {
    //     FindObjectOfType<PauseManager>().PauseEvent += OnPauseEvent;
    // }
    //
    // private void OnDisable()
    // {
    //     FindObjectOfType<PauseManager>().PauseEvent -= OnPauseEvent;
    // }

    private void OnMovementExit()
    {
        Debug.Log("OnMovementExit");
    }

    private void OnMovementUpdate()
    {
        Debug.Log("OnMovementUpdate");
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(5, 0, 0, ForceMode.VelocityChange);
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, 5, ForceMode.VelocityChange);
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -5, ForceMode.VelocityChange);
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(-5, 0, 0, ForceMode.VelocityChange);
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DelegateStateManager.ChangeState(jump);
        }
    }

    private void OnMovementEnter()
    {
        Debug.Log("OnMovementEnter");
    }


    private void OnJumpExit()
    {
        Debug.Log("OnJumpExit");
        
    }

    private void OnJumpUpdate()
    {
        Debug.Log("OnJumpUpdate");
        
            GetComponent<Rigidbody>().AddForce(0, 5, 0, ForceMode.VelocityChange);
            DelegateStateManager.ChangeState(movement);
        
        
    }

    private void OnJumpEnter()
    {
        Debug.Log("OnJumpEnter");
        
    }

    private void OnIdleExit()
    {
        Debug.Log("OnIdleExit");
    }

    private void OnIdleUpdate()
    {
        Debug.Log("OnIdleUpdate");
        GetComponent<Renderer>().material.color = Color.red;
        DelegateStateManager.ChangeState(movement);
    }

    private void OnIdleEnter()
    {
        Debug.Log(message:"OnIdleEnter");
        
    }

    // Update is called once per frame
    void Update()
    {
        DelegateStateManager.UpdateCurrentState();
    }
}

}

