using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace AJ
{
    public class MusicAudioManager : MonoBehaviour
    {
        public GameManager gameManager;

        static AudioSource audioSource;
        public static AudioClip WonEventMusic, LostEventMusic, GameOverMusic;


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
            MusicAudioManager.PlaySFX("WonMusic");
            Debug.Log("Play Music");
        }

        public void OnLostEvent()
        {
            MusicAudioManager.PlaySFX("LostMusic");
            Debug.Log("Play Music");
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
            Debug.Log("Play Music");
        }
    }
}

