using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManaUI : MonoBehaviour
{
	public TextMeshProUGUI TextMeshProUGUI;

	public ScaleyBoxAdvanced ScaleyBoxAdvanced;
	
	// HACK: UI code (Should be event driven)
	void Update()
	{
		if (!(ScaleyBoxAdvanced is null))
		{
			TextMeshProUGUI.text = ScaleyBoxAdvanced.mana.ToString("#");
		}
	}

}
