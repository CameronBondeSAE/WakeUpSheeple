using DG.Tweening;
using UnityEngine;

public class ScaleyBoxSequence : MonoBehaviour
{
    void Start()
	{

		// Create empty sequence
		Sequence sequence = DOTween.Sequence();

		// Assemble the functions (it doesn't run straight away, unlike a normal DoTween)
		// Note: the 'SetDelay' function I'm using a random number. This is one of the powerful things you can't really do with keyframed animation easily
		// Note: don't hardcode the values like I have!
		sequence.Append(transform.DOScale(new Vector3(5, 5, 5), 4f).SetEase(Ease.OutElastic).SetDelay(Random.Range(0,2f)));
		sequence.Append(transform.DOScale(new Vector3(1, 1, 1), 2f).SetEase(Ease.OutElastic));
		sequence.SetLoops(3);
		sequence.OnComplete(DoneAThing);

		// Actually start the sequence
		sequence.Play();
	}

	void DoneAThing()
	{
	    
	}
}
