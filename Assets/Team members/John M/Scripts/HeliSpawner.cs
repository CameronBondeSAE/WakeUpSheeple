using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliSpawner : MonoBehaviour
{
    public GameObject HelicopterPrefab;
    
    public List <Transform> SpawnLocations;
    public List <Transform> WaitLocations;
    public List <Transform> ExitLocations;

    public int RandomSpawn;
    public int RandomWait;
    public int RandomExit;
    
   void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpawnNewHeli();
        }
    }
    
    public void SpawnNewHeli()
    {
        GameObject go = Instantiate(HelicopterPrefab, new Vector3(-75, 3, 0), Quaternion.identity);
        
        RandomSpawn = Random.Range(0, SpawnLocations.Count);
        RandomWait = Random.Range(0, WaitLocations.Count);
        RandomExit = Random.Range(0, ExitLocations.Count);
        
        go.GetComponent<HeliBehaviour>().SpawnLocations = SpawnLocations;
        go.GetComponent<HeliBehaviour>().WaitLocations = WaitLocations;
        go.GetComponent<HeliBehaviour>().ExitLocations = ExitLocations;
        go.GetComponent<HeliBehaviour>().RandomSpawn = RandomSpawn;
        go.GetComponent<HeliBehaviour>().RandomWait = RandomWait;
        go.GetComponent<HeliBehaviour>().RandomExit = RandomExit;
    }
}
