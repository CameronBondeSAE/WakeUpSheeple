using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.RigidbodyPhysics;
using UnityEngine;
using UnityEngine.AI;

public class AIMoveforward : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;
    

    private int waypointIndex;
    private float dist;
    void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    
    void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (dist < 1f)
        {
            IncreaseIndex();
        }
        Patrol();
    }

    void Patrol()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward*3);
        
        //(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }
}
