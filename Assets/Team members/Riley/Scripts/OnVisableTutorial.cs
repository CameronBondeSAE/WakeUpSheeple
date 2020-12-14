using System;
using System.Collections;
using System.Collections.Generic;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;
public class OnVisableTutorial : MonoBehaviour
{
    private bool firstVisablity;
    private GameNetworkManager gameNetworkManager;
    private Vector3 playerCoords;
    private float tutorialSafeDistance;
    private void Start()
    {
        firstVisablity = false;
        gameNetworkManager = FindObjectOfType<GameNetworkManager>();
        tutorialSafeDistance = 10;
    }
    private void Update()
    {
        if (gameNetworkManager == null || gameNetworkManager.localPlayer == null)
        {
            Debug.Log("The NetworkManager does NOT exist in this scene");
            return;
        }
        playerCoords = gameNetworkManager.localPlayer.transform.position;
        if (Vector3.Distance(transform.position, playerCoords) < tutorialSafeDistance && firstVisablity == false)
        {
            firstVisablity = true;
            StartCoroutine(FirstTutorial());
        }
    }
    private IEnumerator FirstTutorial()
    {
        Debug.Log("This things does this thing!"); //Enable message here
        yield return new WaitForSeconds(10f); //Wait to remove message
        //Remove message here
    }
}
