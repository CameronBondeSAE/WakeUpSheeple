using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damien
{
//Find all sheep in level
//Determine the nearest sheep
//See if nearest sheep is within range
//Do something if sheep in within range

    public class BillsGate : MonoBehaviour
    {
        
        public string sheepTag = "sheep";

        private Transform inRange;
        public float range = 3f;
        private float openAngle = 90f;
        public float rotateAngle = 15f;
        public Transform partToRotate;
        
        // Start is called before the first frame update
        void Start()
        {
          
        }

        private void Update()
        {
            UpdateInRange();
            if (inRange == null)
            {
                //Debug.Log("The Sheep is not in range");
            }
        }

        void UpdateInRange()
        {
            //Find nearest sheep
           //TODO: Hack Replace with sheep manager
            GameObject[] sheeps = GameObject.FindGameObjectsWithTag(sheepTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestSheep = null;
            foreach (GameObject sheep in sheeps)
            {
                float distanceToSheep = Vector3.Distance(transform.position, sheep.transform.position);
                if (distanceToSheep < shortestDistance)
                {
                    shortestDistance = distanceToSheep;
                    nearestSheep = sheep;
                }
            }
            
            if (nearestSheep != null && shortestDistance <= range)
            {
                //Debug.Log("Sheep is in Range");
                if (partToRotate.transform.localRotation.eulerAngles.y <openAngle)
                {
                  //  Debug.Log("Rotation is less than 90");
                    partToRotate.transform.Rotate(0f, rotateAngle * Time.deltaTime, 0f); 
                }
            }
            else 
            {
                //Debug.Log("Sheep is not in Range");
                if(partToRotate.transform.rotation.y > 0f)
                {
                 //   Debug.Log("Rotation is more than 0");
                    partToRotate.transform.Rotate(0f, -rotateAngle * Time.deltaTime, 0f); 
                }
            }
            void OnDrawGizmosSelected()
            {
                Gizmos.DrawWireSphere(transform.position, range);
            }
        }
    }
}