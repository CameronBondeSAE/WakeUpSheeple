using System;
using System.Collections;
using System.Collections.Generic;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;
public class OnVisableTutorial : MonoBehaviour
{
	public string tutorialText;
	public float  safeDistance = 10f;
	public float  offDistance = 15f;

	PopupText PopupText;

	public bool               firstVisablity;
	public GameNetworkManager gameNetworkManager;
	public Vector3            playerCoords;
	public bool               finished;

	private void Start()
    {
        firstVisablity = false;
        gameNetworkManager = FindObjectOfType<GameNetworkManager>();

		PopupText = GetComponentInChildren<PopupText>();
	}
    private void Update()
    {
        if (gameNetworkManager == null || gameNetworkManager.localPlayer == null)
        {
            // Debug.Log("The NetworkManager does NOT exist in this scene");
            return;
        }
        playerCoords   = gameNetworkManager.localPlayer.transform.position;
		playerCoords.y = transform.position.y; // Ignore the y of the player
		
		float distance = Vector3.Distance(transform.position, playerCoords);
		
		if (firstVisablity == false)
		{
			if (distance < safeDistance)
			{
				firstVisablity = true;
				PopupText.text = tutorialText;
				PopupText.Show();
				// StartCoroutine(FirstTutorial());
			}
		}
		else
		{
			if (finished == false && distance > offDistance)
			{
				finished = true;
				PopupText.Hide();
			}
		}
		
    }
    private IEnumerator FirstTutorial()
    {
        Debug.Log("This things does this thing!"); //Enable message here
        yield return new WaitForSeconds(10f); //Wait to remove message
        //Remove message here
    }
}
