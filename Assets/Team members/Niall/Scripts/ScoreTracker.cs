using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : NetworkBehaviour
{
    // public GameNetworkManager gameNetworkManager;
    public GameManager gm;
    public EndGoalChecker endGoal;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI totalText;
    [SyncVar]
    public int safeSheepN;
    [SyncVar]
    public int goalSheep;
    [SyncVar]
    public int tSheep;
    

    public override void OnStartServer()
    {
       
      
    }
    void Awake()
    {
        endGoal= FindObjectOfType<EndGoalChecker>();

        gm = FindObjectOfType<GameManager>();
    }

    void Start()
    {
       
    }
    

    // Update is called once per frame
    void Update()
    {
        tSheep = gm.allSheep.Count;
        goalSheep = endGoal.sheepRequired;
        safeSheepN = endGoal.safeSheep.Count;
        
        if (totalText != null) totalText.text = "Remaining Sheep: " + tSheep;
        if (scoreText != null) scoreText.text = "Score: " + safeSheepN + "/" + goalSheep;
    }
}