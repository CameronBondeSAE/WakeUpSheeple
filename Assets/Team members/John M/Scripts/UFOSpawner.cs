using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    public GameObject UFOPrefab;
    
    public List <Transform> SpawnLocations;
    public List <Transform> WaitLocations;
    public List <Transform> ExitLocations;

    public int RandomSpawn;
    public int RandomWait;
    public int RandomExit;
    
  
    public void SpawnNewUFO()
    {
        GameObject go = Instantiate(UFOPrefab, new Vector3(-75, 3, 0), Quaternion.identity);
        
        RandomSpawn = Random.Range(0, SpawnLocations.Count);
        RandomWait = Random.Range(0, WaitLocations.Count);
        RandomExit = Random.Range(0, ExitLocations.Count);
        
        go.GetComponent<UFOBehaviour>().SpawnLocations = SpawnLocations;
        go.GetComponent<UFOBehaviour>().WaitLocations = WaitLocations;
        go.GetComponent<UFOBehaviour>().ExitLocations = ExitLocations;
        go.GetComponent<UFOBehaviour>().RandomSpawn = RandomSpawn;
        go.GetComponent<UFOBehaviour>().RandomWait = RandomWait;
        go.GetComponent<UFOBehaviour>().RandomExit = RandomExit;
    }
}
