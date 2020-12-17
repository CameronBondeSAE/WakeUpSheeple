using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeSpawner : MonoBehaviour
{
    public GameObject nukePrefab;
    
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    AudioClip lastClip;
    
    public GameManager gameManager;
    public CoreSheepFinder coreSheepFinder;
    private Vector3 spawnPosition;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
   
    public void DropTheNuke()
    {
        StartCoroutine(NukeRoutine());
    }

    IEnumerator NukeRoutine()
    {
        coreSheepFinder = gameManager.GetComponent<CoreSheepFinder>();
        audioSource.PlayOneShot(RandomClip());
        //find the centre of the sheep flock at the current time and add random variance to it. Location is then set for spawn once alarm finished
        spawnPosition = coreSheepFinder.centerofSheepFlock + new Vector3(Random.Range(-30f, 30f), 75, Random.Range(-30f, 30f));
        yield return new WaitForSeconds(12);
        Instantiate(nukePrefab);
        nukePrefab.transform.position = spawnPosition;
        //nuke then drops from set location leading to explosion code
        
        
        
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
