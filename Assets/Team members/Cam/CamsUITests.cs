using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class CamsUITests : MonoBehaviour
{
	public TextMeshProUGUI textMeshPro;
	public TMP_FontAsset[]   fonts;
	public TMP_FontAsset[]   fonts2;

	private void Start()
	{
		InvokeRepeating("ChangeTextRandomly", 0, 0.1f);


		GameObject go           = new GameObject("Cams object");
		Rigidbody        rb = go.AddComponent<Rigidbody>();
		go.AddComponent<BoxCollider>();
	}

	// Update is called once per frame
	void ChangeTextRandomly()
	{
		textMeshPro.color = new Color(Random.value, Random.value, Random.value);
		textMeshPro.font  = fonts[Random.Range(0, fonts.Length-1)];
		// Vector3.MoveTowards()
	}
}