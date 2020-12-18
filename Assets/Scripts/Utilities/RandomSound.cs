using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEngine;

namespace AJ
{
    public class RandomSound : MonoBehaviour
    {
        public float value = 0f;
        public float probability = 9f;
        static AudioSource audioSource;
        public AudioClip WonEventMusic, LostEventMusic, GameOverMusic;

        void Update()
        {
            if (Random.value > probability)
            {
                
            }
        }
    }
}

