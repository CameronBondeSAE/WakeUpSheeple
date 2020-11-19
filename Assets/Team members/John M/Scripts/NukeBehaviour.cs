using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeBehaviour : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem = null;

    public GameObject radiationZone;
    
    
    // FUNCTIONS REQUIRED
    
    // if nuke collides with the ground, trigger explosion
    // explode the nuke
    // leave behind radiation zone after explosion
    // radiation zone disappears over time
    
    void Start()
    {
        particleSystem.Stop();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nuke"))
        {
            Detonate();
            other.gameObject.SetActive(false);
            Debug.Log("Collision detected");
        }
    }

    void Detonate()
    {
        particleSystem.Play();
        Debug.Log("The nuke has landed!");
        Instantiate(radiationZone);
    }
    
}
