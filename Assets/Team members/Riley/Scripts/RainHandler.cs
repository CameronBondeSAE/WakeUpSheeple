using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainHandler : MonoBehaviour
{
    public float rainSlider = 0.0F;
    private ParticleSystem ps;
    private ParticleSystem cps;
    //public Transform cameraTransform;
    public GameObject childObject;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        cps = childObject.GetComponent<ParticleSystem>();
    }
    void Update()
    {
        // ----- Vars to edit our downfall rate ----- //
        var emission = ps.emission;
        var main = ps.main;
        var mainCO = cps.main;
        var emissionCO = cps.emission;
        main.maxParticles = Mathf.RoundToInt(rainSlider * 30f);
        emission.rateOverTime = Mathf.RoundToInt(rainSlider * 30f);
        mainCO.maxParticles = Mathf.RoundToInt(rainSlider * 30f);
        emissionCO.rateOverTime = Mathf.RoundToInt(rainSlider * 30f);
        // ----- Moves object to camera ----- //
        //Vector3 cameraPos = new Vector3(cameraTransform.position.x, cameraTransform.position.y + 5, cameraTransform.position.z);
        //transform.position = cameraPos;
    }
    /*void OnGUI()
    {
        // ----- Quick GUI Slider ----- //
        rainSlider = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), rainSlider, 0.0F, 1000.0F);
    }*/
}
