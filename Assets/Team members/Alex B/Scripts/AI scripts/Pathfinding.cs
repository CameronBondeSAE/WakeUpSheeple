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
        public float speed = 1.0f;
        public Transform target;
        public float degreesPerSecond = 50f;
        public bool canTurnLeft, canTurnRight;

        public void Update()
        {
            //Vector3 TurnForce = Vector3.RotateTowards()
            //transform.Rotate(Vector3.left* degreesPerSecond * Time.deltaTime,Space.Self);
            GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f,0f,10f) * speed);
        }
        private void FixedUpdate()
        {
            //GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f,0f,10f) * speed);
            //collider hits layer 4 only
            int layerMask = 1 << 4;
            //if I recall correctly, does the opposite, collides into everything else rather than layer 4
            layerMask = ~layerMask;
            RaycastHit hit;
            RaycastHit hitLeft;
            RaycastHit hitRight;
            
            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitLeft,1.5f, layerMask))
            {
                canTurnLeft = true;
            }
            else
            {
                canTurnLeft = false;
            }
            
            if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitRight,1.5f, layerMask))
            {
                canTurnRight = true;
            }
            else
            {
                canTurnRight = false;
            }
            
            //from current position, seeing if the raycast did hit something
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,1.5f, layerMask))
            {

                if (canTurnLeft)
                {
                    transform.Rotate(new Vector3(0f,-90f,0f));
                }
                
                if (canTurnRight)
                {
                    transform.Rotate(new Vector3(0f,100f,0f));
                }

                if (!canTurnLeft && !canTurnRight)
                {
                    transform.Rotate(new Vector3(0f,180f,0f));
                }

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,Color.blue); Debug.Log("Did Hit");
                
                //GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f,0f,-9f) * speed);
            }
            //from current position, it will tell me that it isn't hitting anything
            //telling me if there is an object in the way
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
        }
    }
}




