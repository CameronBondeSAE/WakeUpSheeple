using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class MusicAudioManager : MonoBehaviour
    {
        public GameManager gameManager;

        static AudioSource audioSource;
        public static AudioClip WonEventMusic, LostEventMusic, GameOverMusic;


        private void OnEnable()
        {
            //Subscribe to event
            FindObjectOfType<GameManager>().WonEvent += OnWonEvent;
            FindObjectOfType<GameManager>().LostEvent += OnLostEvent;
        }
        
        private void OnDisable()
        {
            // UNsubscribe to event
            FindObjectOfType<GameManager>().WonEvent -= OnWonEvent;
            FindObjectOfType<GameManager>().LostEvent -= OnLostEvent;
        }

        private void OnWonEvent()
        {
            MusicAudioManager.PlaySFX("WonMusic");
        }

        private void OnLostEvent()
        {
            MusicAudioManager.PlaySFX("LostMusic");
        }

        // Start is called before the first frame update
        void Start()
        {
            WonEventMusic = Resources.Load<AudioClip>("WonMusic");
            LostEventMusic = Resources.Load<AudioClip>("LostMusic");
            GameOverMusic = Resources.Load<AudioClip>("GameOverMusic");
            audioSource = GetComponent<AudioSource>(); //Need to add music for the "game over music" maybe?
        }

        public static void PlaySFX(string clip)
        {
            
        }
    }
}

