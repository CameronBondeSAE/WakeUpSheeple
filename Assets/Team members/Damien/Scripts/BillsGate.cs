using System;
using System.Collections;
using System.Collections.Generic;
using AlexM;
using AnthonyY;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Damien
{
//Find all players in level
//Determine the nearest player
//See if nearest player is within range
//Do something if player in within range

    public class BillsGate : MonoBehaviour
    {
        
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
            
        }
        private void OnTriggerEnter(Collider target)
        {
            AdministerVaccine();
        }
        void OnDrawGizmosSelected()
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, range);
            }
        void AdministerVaccine()
        {
            Debug.Log("Administer Vaccine");
        }
        void UpdateInRange()
        {
            //Find nearest player
            PlayerBehaviour[] players = Sheep.FindObjectsOfType<PlayerBehaviour>();
            float shortestDistance = Mathf.Infinity;
            PlayerBehaviour nearestPlayer = null;
            foreach (PlayerBehaviour player in players)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
                if (distanceToPlayer < shortestDistance)
                {
                    shortestDistance = distanceToPlayer;
                    nearestPlayer = player;
                }
            }
            if (nearestPlayer != null && shortestDistance <= range)
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
            
        }
    }
}