using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeSpawner : MonoBehaviour
{
    public GameObject nukePrefab;
    public AudioSource nukeSiren;
    
    
    public void DropTheNuke()
    {
        StartCoroutine(NukeRoutine());
    }

    IEnumerator NukeRoutine()
    {
        nukeSiren.Play();
        yield return new WaitForSeconds(14);
        Instantiate(nukePrefab);
    }
}
