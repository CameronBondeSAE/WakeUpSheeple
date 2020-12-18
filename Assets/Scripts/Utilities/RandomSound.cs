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
        public AudioSource audioSource;
        public AudioClip[] Sounds;

        void FixedUpdate()
        {
            if (Random.value < probability)
            {
                audioSource.clip = Sounds[Random.Range(0, Sounds.Length)];
                audioSource.Play();
            }
        }
    }
}

