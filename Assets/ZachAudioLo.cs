using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZachAudioLo : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip AudioClip;
    public float volume = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = AudioClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
