using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupText : MonoBehaviour
{
	public string      text;
	public TextMeshProUGUI TextMeshPro;
	public bool        testSequence = false;

	Vector3 startingScale;
	
	public void Start()
	{
		startingScale = transform.localScale;
		transform.localScale = Vector3.zero;
		Hide();
		
		if (testSequence)
		{
			StartCoroutine(TestSequence());
		}
	}

	public IEnumerator TestSequence()
	{
		yield return new WaitForSeconds(3.5f);
		while (true)
		{
			Show();
			yield return new WaitForSeconds(3.5f);
			Hide();
			yield return new WaitForSeconds(2f);
		}
	}


	public void Show()
	{
		TextMeshPro.text = text;
		// transform.localScale = Vector3.zero;
		// TextMeshPro.alignment == TextAlignmentOptions.Center;
		transform.DOScale(startingScale, 1f).SetEase(Ease.OutElastic);
	}

	public void Hide()
	{
		transform.DOScale(new Vector3(0f, 0f, 0f), 0.5f).SetEase(Ease.InQuad);
	}
}