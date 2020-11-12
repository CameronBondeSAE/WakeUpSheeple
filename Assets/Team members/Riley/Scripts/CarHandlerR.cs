using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarHandlerR : MonoBehaviour
{
    public GameObject carRespawnObject;
    private Vector3 carRespawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        carRespawnPoint = new Vector3(carRespawnObject.transform.position.x, carRespawnObject.transform.position.y + 1.5f, carRespawnObject.transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    private void OnTriggerExit(Collider other)
    {
        other.transform.position = carRespawnPoint;
    }
}
