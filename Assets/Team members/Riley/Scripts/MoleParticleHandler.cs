using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleParticleHandler : MonoBehaviour
{
    private ParticleSystem ps;
    public bool particleIsOn;
    private ParticleSystem.EmissionModule emission;
    private ParticleSystem.MainModule main;
    public GameObject moleManMain;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        emission = ps.emission;
        main = ps.main;
    }

    // Update is called once per frame
    void Update()
    {
        particleIsOn = moleManMain.GetComponent<MoleManManager>().particleOnOff;
        if (particleIsOn == true)
        {
            main.maxParticles = Mathf.RoundToInt(50);
            emission.rateOverTime = Mathf.RoundToInt(50);
        }
        else
        {
            main.maxParticles = Mathf.RoundToInt(0);
            emission.rateOverTime = Mathf.RoundToInt(0);
        }
    }
}
