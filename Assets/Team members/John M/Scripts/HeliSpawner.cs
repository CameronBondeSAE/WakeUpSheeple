using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliSpawner : MonoBehaviour
{
    public GameObject HelicopterPrefab;
    
   void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpawnNewHeli();
        }
    }
    
    public void SpawnNewHeli()
    {
        Instantiate(HelicopterPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
