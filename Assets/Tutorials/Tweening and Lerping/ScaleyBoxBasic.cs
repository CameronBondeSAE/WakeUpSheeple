using DG.Tweening;
using UnityEngine;

public class ScaleyBoxBasic : MonoBehaviour
{
	public Ease ease = Ease.OutElastic;

	void Start()
	{
		// Note: You can chain up function calls with DOTween, because they RETURN their main object 'TweenerCore' for EVERY function call.
		// So you can easily get access to the main object it creates on the first 'DO'. Pretty weird but more convenient than putting them on separate lines

		// Using a helper function from transform. There's loads for most Unity classes
		transform.DOScale(new Vector3(5, 5, 5), 4f).SetEase(ease).OnComplete(DoneAThing).SetLoops(100);
	}

	void DoneAThing()
	{
	    Debug.Log("FINISHED TWEENING!");
	}
}
