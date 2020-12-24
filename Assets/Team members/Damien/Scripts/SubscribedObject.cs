using System.Collections;
using System.Collections.Generic;
using Damien;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

public class SubscribedObject : MonoBehaviour
{
    public float rangeToMove = 5f;
    
    
    void Start()
    {
        FindObjectOfType<Button>().actionButton += randomPosition;
    }
    void randomPosition()
    {
        GetComponent<Renderer>().material.color =
            new Color(Random.Range(10, 200), Random.Range(10, 200), Random.Range(10, 200), 200);
        transform.position = new Vector3(transform.position.x + Random.Range(-rangeToMove, rangeToMove), transform.position.y + Random.Range(-rangeToMove, rangeToMove), transform.position.z + Random.Range(-rangeToMove, rangeToMove));
        
    }
}
