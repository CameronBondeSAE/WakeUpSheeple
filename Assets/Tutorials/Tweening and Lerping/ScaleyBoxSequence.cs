using DG.Tweening;
using Mirror;
using System.Collections;
using UnityEngine;

public class ScaleyBoxSequence : NetworkBehaviour
{
	Sequence sequence;

    IEnumerator Start()
	{
		// Create empty sequence
		sequence = DOTween.Sequence();
		
		// Assemble the functions (it doesn't run straight away, unlike a normal DoTween)
		// Note: the 'SetDelay' function I'm using a random number. This is one of the powerful things you can't really do with keyframed animation easily
		// Note: don't hardcode the values like I have!
		sequence.Append(transform.DOScale(new Vector3(5, 5, 5), 4f).SetEase(Ease.OutElastic));
		sequence.Append(transform.DOScale(new Vector3(1, 1, 1), 2f).SetEase(Ease.OutElastic));
		sequence.SetLoops(-1);
		sequence.OnComplete(DoneAThing);
		

		if (isServer)
		{
			yield return new WaitForSeconds(Random.Range(0, 10f));
			RpcFreakOut();
		}

		// if (isClient)
			// GetComponent<Collider>().enabled = false;
	}

	[ClientRpc]
	public void RpcFreakOut()
	{
		// Actually start the sequence
		sequence.Play();
	}

	void DoneAThing()
	{
	    
	}
}
