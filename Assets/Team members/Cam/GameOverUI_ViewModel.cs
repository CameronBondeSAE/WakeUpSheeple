using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI_ViewModel : MonoBehaviour
{
	GameManager       gameManager;
	public GameObject UI;

	void Awake()
	{
		gameManager = FindObjectOfType<GameManager>();
		UI?.SetActive(false);
	}

	void OnEnable()
	{
		gameManager.GameOverEvent += GameManagerOnGameOverEvent;
	}

	void OnDisable()
	{
		gameManager.GameOverEvent -= GameManagerOnGameOverEvent;
	}

	void GameManagerOnGameOverEvent()
	{
		UI?.SetActive(true);
	}
}
