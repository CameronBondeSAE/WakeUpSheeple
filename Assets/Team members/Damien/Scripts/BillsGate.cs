using System;
using System.Collections;
using System.Collections.Generic;
using AlexM;
using AnthonyY;
using UnityEngine;

namespace Damien
{
//Find all players in level
//Determine the nearest player
//See if nearest player is within range
//Do something if player in within range

    public class BillsGate : MonoBehaviour
    {
        public LayerMask layerMask;
        private Transform inRange;

        public float range = 7f;
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
            Collider[] overlapSphere =
                Physics.OverlapSphere(transform.position, range, layerMask, QueryTriggerInteraction.Ignore);

            float shortestDistance = Mathf.Infinity;
            PlayerBehaviour nearestPlayer = null;
            if (overlapSphere.Length > 0)
            {
                //opening gate
                if (partToRotate.transform.localRotation.eulerAngles.y < openAngle)
                {
                    //  Debug.Log("Rotation is less than 90");
                    partToRotate.transform.Rotate(0f, rotateAngle * Time.deltaTime, 0f);
                }
            }

            if (overlapSphere.Length == 0)
            {
                //closing gate
                if (partToRotate.transform.eulerAngles.y > 0f)
                {
                    //   Debug.Log("Rotation is more than 0");
                    partToRotate.transform.Rotate(0f, -rotateAngle * Time.deltaTime, 0f);
                }
            }
        }
    }
}