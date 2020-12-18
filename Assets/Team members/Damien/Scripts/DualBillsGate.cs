using System;
using AnthonyY;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Damien
{
//Find all players in level
//Determine the nearest player
//See if nearest player is within range
//Do something if player in within range

    public class DualBillsGate : MonoBehaviour
    {
        public LayerMask layerMask;
        private Transform inRange;

        public float range = 7f;
        private float openAngle = 90f;
        public float rotateSpeed = 5f;

        public Transform partToRotate1;
        public Transform partToRotate2;

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
                partToRotate1.localRotation = Quaternion.Euler(0,
                    Mathf.Lerp(partToRotate1.transform.localRotation.eulerAngles.y, openAngle,
                        Time.deltaTime * rotateSpeed), 0);
                
                
                partToRotate2.localRotation = Quaternion.Euler(0,
                    Mathf.Lerp(partToRotate2.transform.localRotation.eulerAngles.y, -openAngle,
                        Time.deltaTime * rotateSpeed), 0);
                
                // Debug.Log(partToRotate1.transform.localRotation.eulerAngles.y);
               // Debug.Log(partToRotate2.transform.localRotation.eulerAngles.y);
            }
            else
            {
                partToRotate1.localRotation = Quaternion.Euler(0,
                    Mathf.Lerp(partToRotate1.transform.localRotation.eulerAngles.y, 0f,
                        Time.deltaTime * rotateSpeed), 0);
                partToRotate2.localRotation = Quaternion.Euler(0,
                    Mathf.Lerp(partToRotate2.transform.localRotation.eulerAngles.y, 0f,
                        Time.deltaTime * rotateSpeed), 0);
             //   Debug.Log(partToRotate1.transform.localRotation.eulerAngles.y);
             //  Debug.Log(partToRotate2.transform.localRotation.eulerAngles.y);
            }
        }
    }
}