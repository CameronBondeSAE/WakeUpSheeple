using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class MusicAudioManager : MonoBehaviour
    {

        static AudioSource audioSource;
        public static AudioClip WonEventMusic, LostEventMusic, GameOverMusic;

        // Start is called before the first frame update
        void Start()
        {
            WonEventMusic = Resources.Load<AudioClip>("WonMusic");
            LostEventMusic = Resources.Load<AudioClip>("LostMusic");
            GameOverMusic = Resources.Load<AudioClip>("GameOverMusic");
            audioSource = GetComponent<AudioSource>(); //Need to add music for the game over music.
        }

        public static void PlaySFX(string clip)
        {
            switch(clip)
            {
                case "WonMusic":
                    audioSource.PlayOneShot(WonEventMusic);
                    break;

                case "LostMusic":
                    audioSource.PlayOneShot(LostEventMusic);
                    break;
                case "GameOverMusic":
                    audioSource.PlayOneShot(GameOverMusic);
                    break;
            }
        }
    }
}

