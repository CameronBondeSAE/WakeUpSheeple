using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedSequenceFeatures : MonoBehaviour
{
	public GameObject     wolfSkin;
	public GameObject     dogSkin;
	public ParticleSystem ParticleSystem;
	
	void Start()
	{

		// Create empty sequence
		Sequence sequence = DOTween.Sequence();

		// Note the "AppendCallback" is just a normal function call you can insert anywhere in a sequence.
		sequence.Append(transform.DOScale(new Vector3(2, 2, 2), 3f).SetEase(Ease.OutQuad).SetDelay(Random.Range(0, 2f)));
		sequence.AppendCallback(ChangeToWolf);
		sequence.Append(transform.DOScale(new Vector3(1, 1, 1), 1f).SetEase(Ease.OutElastic));
		
		// Actually start the sequence
		sequence.Play();
	}

	void ChangeToWolf()
	{
		ParticleSystem.Emit(25);
		dogSkin.SetActive(false);
		wolfSkin.SetActive(true);
	}
}
