﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
	public GameObject Sheep;
	public TextMeshProUGUI  debug_Velocity;
	
	private void OnEnable()
	{
		Sheep.GetComponent<Movement_ForwardAM>().velEvent += OnvelEvent;
	}

	private void OnvelEvent(Vector3 obj)
	{
		debug_Velocity.SetText(obj.ToString());
	}

	private void OnDisable()
	{
		Sheep.GetComponent<Movement_ForwardAM>().velEvent -= OnvelEvent;
	}
}
