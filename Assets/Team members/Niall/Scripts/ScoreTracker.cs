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
    public GameObject gm;
    public EndGoalChecker endGoalCheck;
    public GameObject endGoal;

    public int tSheep;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI totalText;
    public int safeSheep;
    public int goalSheep;

    public override void OnStartServer()
    {
        endGoal = GameObject.Find("EndGoal");
        endGoalCheck = endGoal.GetComponent<EndGoalChecker>();

        gameNetworkManager = FindObjectOfType<GameNetworkManager>();

        safeSheep = endGoalCheck.safeSheep.Count;
        tSheep = gameNetworkManager.gameManager.allSheep.Count;
        goalSheep = endGoalCheck.sheepRequired;
    }


    // Update is called once per frame
    void Update()
    {
        if (totalText != null) totalText.text = "Remaining Sheep: " + tSheep;
        if (scoreText != null) scoreText.text = "Score: " + safeSheep + "/" + goalSheep;
    }
}