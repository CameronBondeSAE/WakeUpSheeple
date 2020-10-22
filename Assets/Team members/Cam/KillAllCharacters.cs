using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllCharacters : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		CharacterBase characterBase = other.GetComponent<CharacterBase>();
		characterBase.isAwesome = false;
		
		if (characterBase)
		{
			Destroy(other.gameObject);
		}
	}
}
