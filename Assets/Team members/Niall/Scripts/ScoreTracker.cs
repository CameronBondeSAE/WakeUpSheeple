using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{

    public GameManager gm;
    public EndGoalChecker endGoalCheck;
    public GameObject endGoal;
    
    public int tSheep;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI totalText;


    public void OnEnable()
    {
        endGoal = GameObject.Find("EndGoal");
        endGoalCheck = endGoal.GetComponent<EndGoalChecker>();
        tSheep = gm.totalSheep;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (totalText != null) totalText.text = tSheep.ToString();
    }
}
