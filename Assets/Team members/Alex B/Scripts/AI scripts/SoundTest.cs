using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class SoundTest : MonoBehaviour
    {
        public AudioSource playSound;

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PlayerTest"))
            {
                playSound.Play();
                
            }
           
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("PlayerTest"))
            {
                playSound.Stop();
                
            }
        }
    }

    
}
