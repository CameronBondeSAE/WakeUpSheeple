using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllCharacters : MonoBehaviour
{
	List<CharacterBase> CharacterBases;
	
	void OnTriggerEnter(Collider other)
	{
		CharacterBase characterBase = other.GetComponent<CharacterBase>();
		
		if (characterBase)
		{
			Destroy(other.gameObject);

			if (characterBase as CamsDude_Model)
			{
				
			}
		}
	}
}
