using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UIElements.Experimental;

namespace AJ
{
    
    public class Pathfinding : MonoBehaviour
    {
        
        public LayerMask layerMask;
        public Transform[] points;
        private int destPoint = 0;
        public Rigidbody rb;
        
       

        public void Update()
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * 4f);
        }

       

        private void FixedUpdate()
        {
            //collider hits layer 4 only
            int layerMask = 1 << 4;
            
            //if I recall correctly, does the opposite, collides into everything else rather than layer 4
            layerMask = ~layerMask;

            RaycastHit hit;
            
            //from current position, seeing if the raycast did hit something
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
                Debug.Log("Did Hit");
            }
            //from current position, it will tell me that it isn't hitting anything
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
            
            //telling me if there is an object in the way
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, fwd, 10))
                print("There is something in front of the object!");
        }
    }
}



