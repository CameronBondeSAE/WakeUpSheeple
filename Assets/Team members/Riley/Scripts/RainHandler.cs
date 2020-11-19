using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainHandler : MonoBehaviour
{
    public float rainSlider = 0.0F;
    private ParticleSystem ps;
    
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        var emission = ps.emission;
        var main = ps.main;
        main.maxParticles = Mathf.RoundToInt(rainSlider);
        emission.rateOverTime = Mathf.RoundToInt(rainSlider);
    }
    void OnGUI()
    {
        rainSlider = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), rainSlider, 0.0F, 1000.0F);
    }
}
