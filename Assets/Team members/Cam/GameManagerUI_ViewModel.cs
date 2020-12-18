using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerUI_ViewModel : MonoBehaviour
{
	GameManager       gameManager;
	public GameObject GameOver;
	public GameObject gameWon;

	void Awake()
	{
		gameManager = FindObjectOfType<GameManager>();
		if (!(GameOver is null)) GameOver.SetActive(false);
		if (!(gameWon is null)) gameWon.SetActive(false);
	}

	void OnEnable()
	{
		gameManager.GameOverEvent += GameManagerOnGameOverEvent;
		gameManager.WonEvent += GameManagerOnWonEvent;
	}

	private void GameManagerOnWonEvent()
	{
		if (!(gameWon is null)) gameWon.SetActive(true);
	}

	void OnDisable()
	{
		gameManager.GameOverEvent -= GameManagerOnGameOverEvent;
		gameManager.WonEvent -= GameManagerOnWonEvent;
	}

	void GameManagerOnGameOverEvent()
	{
		GameOver?.SetActive(true);
	}
}
