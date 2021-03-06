using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.RigidbodyPhysics;
using UnityEngine;
using UnityEngine.AI;

namespace AJ
{
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
            if (dist < 100f)
            {
                IncreaseIndex();
            }
            Patrol();
        }
        void Patrol()
        {
            GetComponentInChildren<Rigidbody>().AddForce(transform.forward*speed);
        
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
}

