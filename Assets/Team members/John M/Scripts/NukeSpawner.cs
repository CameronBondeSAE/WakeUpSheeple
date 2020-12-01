﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeSpawner : MonoBehaviour
{
    public GameObject nukePrefab;
    
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    AudioClip lastClip;
    
    public void DropTheNuke()
    {
        StartCoroutine(NukeRoutine());
    }

    IEnumerator NukeRoutine()
    {
        audioSource.PlayOneShot(RandomClip());
        yield return new WaitForSeconds(14);
        Instantiate(nukePrefab);
        nukePrefab.transform.position = new Vector3(0,75,0);
    }
    AudioClip RandomClip()
    {
        int attempts = 2;
        AudioClip newClip = audioClipArray[Random.Range(0, audioClipArray.Length)];

        while (newClip == lastClip && attempts > 0) 
        {
            newClip = audioClipArray[Random.Range(0, audioClipArray.Length)];
            attempts--;
        }

        lastClip = newClip;
        return newClip;
    }
}
