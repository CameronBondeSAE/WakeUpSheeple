using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall
{
    public class Neighbours : MonoBehaviour
    {
        public List<GameObject> neighbours = new List<GameObject>();

        void Update()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Bird")
            {
                neighbours.Add(other.gameObject);
                Debug.Log(other.gameObject + " Entered Trigger");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Bird")
            {
                neighbours.Remove(other.gameObject);
                Debug.Log(other.gameObject + " Exited Trigger");
            }
        }
    }
    
}