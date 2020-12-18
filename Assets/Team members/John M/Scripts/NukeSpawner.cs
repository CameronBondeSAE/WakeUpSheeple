﻿using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeSpawner : NetworkBehaviour
{
    public GameObject nukePrefab;
    
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    AudioClip lastClip;
    
    public GameManager gameManager;
    public CoreSheepFinder coreSheepFinder;
    private Vector3 spawnPosition;
    public float DropRadius;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

	public override void OnStartServer()
	{
		base.OnStartServer();
		
		DropTheNuke();
	}

	public void DropTheNuke()
    {
        StartCoroutine(NukeRoutine());
    }

    IEnumerator NukeRoutine()
    {
		while (true)
		{
			coreSheepFinder = gameManager.GetComponent<CoreSheepFinder>();
			audioSource.PlayOneShot(RandomClip());
			//find the centre of the sheep flock at the current time and add random variance to it. Location is then set for spawn once alarm finished
			yield return new WaitForSeconds(12);

			if (isServer)
			{
				spawnPosition = transform.position + new Vector3(DropRadius, 75, DropRadius);
				GameObject newNukeClone = Instantiate(nukePrefab);
				newNukeClone.transform.position = spawnPosition;
				
				NetworkServer.Spawn(newNukeClone);
			}
			//nuke then drops from set location leading to explosion code
			yield return new WaitForSeconds(12);			
		}
        
        
        
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
