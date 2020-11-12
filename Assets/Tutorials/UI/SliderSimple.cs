using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSimple : MonoBehaviour
{
	public Slider    slider;
	public Light     light;
	public Transform cubeTransform;

	TweenerCore<Vector3,Vector3,VectorOptions> tweenerCore;

	/// <summary>
	/// Event driven workflow. USE THIS.
	/// </summary>
	// Note: This uses "UnityEvent", which works similar to C# events, but with differnt syntax
	void OnEnable()
	{
		slider.onValueChanged.AddListener(OnSliderMoved);
	}

	void OnDisable()
	{
		slider.onValueChanged.RemoveListener(OnSliderMoved);
	}

	void OnSliderMoved(float arg0)
	{
		light.intensity = arg0 * 10f;
		Debug.Log("Slider value = "+arg0);

		cubeTransform.localScale = new Vector3(2f, 2f, 2f);

		tweenerCore.Kill();
		tweenerCore = cubeTransform.DOScale(new Vector3(1f, 1f, 1f), 1f);
	}


	/// <summary>
	/// Polling example. Slow, annoying, don't use
	/// </summary>
	// void Update()
	// {
		// Debug.Log("Polled slider value = "+slider.value);
	// }
}
