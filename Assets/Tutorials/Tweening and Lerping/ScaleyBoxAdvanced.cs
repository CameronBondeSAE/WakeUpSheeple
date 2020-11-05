using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScaleyBoxAdvanced : MonoBehaviour
{
	public float           mana;
	public ParticleSystem  ParticleSystem;

	// Start is called before the first frame update
	void Start()
	{
		DOTween.To(Getter, Setter, 100f, 12f).SetEase(Ease.OutQuad).OnUpdate(DiamondBonus);
	}

	float Getter()
	{
		return mana;
	}

	void Setter(float pnewvalue)
	{
		mana = pnewvalue;
	}

	void DiamondBonus()
	{
		ParticleSystem.Emit(1);
	}
}
