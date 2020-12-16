using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace AJ
{
    public class MusicAudioManager : MonoBehaviour
    {
        private GameManager gameManager;

        static AudioSource audioSource;
        public AudioClip WonEventMusic, LostEventMusic, GameOverMusic;


        public void OnEnable()
        {
            //Subscribe to event
            FindObjectOfType<GameManager>().WonEvent += OnWonEvent;
            FindObjectOfType<GameManager>().LostEvent += OnLostEvent;
        }
        
        public void OnDisable()
        {
            //Unsubscribe to event
            FindObjectOfType<GameManager>().WonEvent -= OnWonEvent;
            FindObjectOfType<GameManager>().LostEvent -= OnLostEvent;
        }

        public void OnWonEvent()
        {
            audioSource.clip = WonEventMusic;
            audioSource.Play();
            Debug.Log("Play Music");
        }

        public void OnLostEvent()
        {
            audioSource.clip = LostEventMusic;
            audioSource.Play();
            Debug.Log("Play Music");
        }

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>(); //Need to add music for the "game over music" maybe?
        }

        public static void PlaySFX(string clip)
        {
            Debug.Log("Play Music");
        }
    }
}

