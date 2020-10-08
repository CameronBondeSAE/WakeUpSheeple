using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VelocityUI_ViewModel : MonoBehaviour
{
	public TextMeshProUGUI textMeshProUGUI;
	public CamsDude_Model  CamsDudeModel;


	private void OnEnable()
	{
		CamsDudeModel.JumpEvent += ShowJumpAchievement;
	}

	private void OnDisable()
	{
		CamsDudeModel.JumpEvent -= ShowJumpAchievement;
	}


	// Update is called once per frame
    void Update()
    {
		// Polling. Isn't great. I like to describe it as "ARE WE THERE YET???"
		textMeshProUGUI.text = CamsDudeModel.GetComponent<Rigidbody>().velocity.ToString();
	}

	// NOT POLLING. This ONLY GETS RUN when the character actually jumps. Efficient!
	public void ShowJumpAchievement()
	{
		Debug.Log("You jumped!");
		textMeshProUGUI.fontSize += 10;
	}
}
