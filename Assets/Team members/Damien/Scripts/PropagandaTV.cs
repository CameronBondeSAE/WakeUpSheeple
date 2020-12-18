using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using AlexM;
using NodeCanvas.Tasks.Actions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Damien
{
    public class PropagandaTV : MonoBehaviour
    {
        public LayerMask layerMask;
        public float tvInnerRadius = 5f;
        public float tvOuterRadius = 10f;
        public bool isOn = true;

        public float tvAngle = 45f;

        public GameObject sheep;

        public Vector3 targetDirection;
        public Vector3 myPos;
        public PropagandaTV target;

        public Rigidbody rb;

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("DetectSheep", 0, 1);
        }

        // Update is called once per frame
        void Update()
        {
            // DetectSheep();
        }

        public void DetectSheep()
        {
            Collider[] overlapSphere =
                Physics.OverlapSphere(transform.position, tvOuterRadius, layerMask, QueryTriggerInteraction.Ignore);

            Sheep[] sheeps = Sheep.FindObjectsOfType<Sheep>();
            float shortestDistance = Mathf.Infinity;
            Sheep nearestSheep = null;
            foreach (Sheep sheep in sheeps)

            {
                if (overlapSphere.Length == 0)
                {
                    float distanceToSheep = Vector3.Distance(transform.position, sheep.transform.position);

                    if (distanceToSheep <= tvInnerRadius)
                    {
                        sheep.GetComponent<Movement_ForwardAM>().enabled = false;
                        sheep.GetComponent<Rigidbody>().isKinematic = true;
                        
                        
                    }
                }

                if (overlapSphere.Length > 0)
                {
                    float distanceToSheep = Vector3.Distance(transform.position, sheep.transform.position);
                    if (distanceToSheep <= tvInnerRadius)
                        sheep.GetComponent<Movement_ForwardAM>().enabled = true;
                    sheep.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }

        public IEnumerator HypnotiseSheep()
        {
            yield return new WaitForSeconds(5f);
        }

        public IEnumerator LureSheep()
        {
            //TODO:Maybe move sheep towards inner circle?
            yield return new WaitForSeconds(5f);
        }

        public IEnumerator PlayVideo()
        {
            //TODO:PlayVideo on TV

            yield return new WaitForSeconds(10f);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, tvInnerRadius);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, tvOuterRadius);

            Vector3 fovLine1 = Quaternion.AngleAxis(tvAngle, transform.up) * transform.forward * tvInnerRadius;
            Vector3 fovLine2 = Quaternion.AngleAxis(-tvAngle, transform.up) * transform.forward * tvInnerRadius;

            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, fovLine1);
            Gizmos.DrawRay(transform.position, fovLine2);
        }
    }
}