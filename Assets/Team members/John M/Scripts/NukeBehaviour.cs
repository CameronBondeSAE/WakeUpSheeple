using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeBehaviour : MonoBehaviour
{
    // FUNCTIONS REQUIRED
    
    // if nuke collides with the ground, trigger explosion
    // explode the nuke
    // leave behind radiation zone after explosion
    // radiation zone disappears over time
    
    void Update()
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                Detonate();
            }
        }

        void Detonate()
        {
            
        }



    }

    
}
