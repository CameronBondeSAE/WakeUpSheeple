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
        transform.position = new Vector3(transform.position.x + Random.Range(-rangeToMove, rangeToMove),
            transform.position.y + Random.Range(-rangeToMove, rangeToMove),
            transform.position.z + Random.Range(-rangeToMove, rangeToMove));
    }
}
