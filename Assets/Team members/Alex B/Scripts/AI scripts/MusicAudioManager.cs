using AlexM;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace AJ
{
    public class MusicAudioManager : MonoBehaviour
    {
        private GameManager gameManager;

        public AudioSource audioSource;
        public AudioClip   WonEventMusic, LostEventMusic, GameOverMusic, sheepSavedMusic, playMusic;

        public void OnEnable()
        {
            //Subscribe to event
			GameManager gm = FindObjectOfType<GameManager>();
			gm.WonEvent += OnWonEvent;
            gm.LostEvent += OnLostEvent;
			if (gm.endGoals.Count>0)
			{
				gm.endGoals[0].SheepMadeitEvent += OnSheepMadeitEvent;
			}
			
			gm.GamestartedEvent += GmOnGamestartedEvent;
        }

		void GmOnGamestartedEvent()
		{
			audioSource.clip = playMusic;
			audioSource.Play();
		}

		void OnSheepMadeitEvent(NetworkIdentity networkIdentity)
		{
			// audioSource.clip = sheepSavedMusic;
			audioSource.PlayOneShot(sheepSavedMusic);
		}

		public void OnDisable()
        {
            //Unsubscribe to event
            // FindObjectOfType<GameManager>().WonEvent -= OnWonEvent;
            // FindObjectOfType<GameManager>().LostEvent -= OnLostEvent;
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
    }
}

