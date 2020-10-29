using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public event Action gamestartedEvent;
    public event Action gameOverEvent;
    
    
    

    private void Awake()
    {
        gamestartedEvent?.Invoke();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGoalTracker()
    {
        GetComponent<EndGoalChecker>().EndGoalReached();
        gameOverEvent?.Invoke();
    }
}
