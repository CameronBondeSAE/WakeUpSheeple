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
    public GameNetworkManager gameNetworkManager;
    public EndGoalChecker endGoal;

    public int tSheep;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI totalText;
    public int safeSheepN;
    public int goalSheep;

    public override void OnStartServer()
    {
        endGoal= FindObjectOfType<EndGoalChecker>();

        gameNetworkManager = FindObjectOfType<GameNetworkManager>();

        
        tSheep = gameNetworkManager.gameManager.allSheep.Count;
        goalSheep = endGoal.sheepRequired;
    }
    

    // Update is called once per frame
    void Update()
    {
        
        safeSheepN = endGoal.safeSheep.Count;
        
        if (totalText != null) totalText.text = "Remaining Sheep: " + tSheep;
        if (scoreText != null) scoreText.text = "Score: " + safeSheepN + "/" + goalSheep;
    }
}