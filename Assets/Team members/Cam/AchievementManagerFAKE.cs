using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManagerFAKE : MonoBehaviour
{
	public CamsDude_Model CamsDudeModel;
	public ParticleSystem ParticleSystem;
	
	private void OnEnable()
	{
		CamsDudeModel.JumpEvent += CamsDudeModelOnJumpEvent;

		// DANGEROUS: Static access of a GLOBAL variable
		// FakeSheep.sheepDeathEventStatic += FakeSheepOnsheepDeathEventStatic;
	}

	private void FakeSheepOnsheepDeathEventStatic(FakeSheep fakeSheep)
	{
		Debug.Log("Sheep died : Name = "+fakeSheep.name);
	}

	private void OnDisable()
	{
		CamsDudeModel.JumpEvent -= CamsDudeModelOnJumpEvent;
	}

	private void CamsDudeModelOnJumpEvent()
	{
		ParticleSystem.Emit(10000);
		// ParticleSystem.gameObject.SetActive(true);
		// ParticleSystem.emission.enabled = true;
	}


	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
