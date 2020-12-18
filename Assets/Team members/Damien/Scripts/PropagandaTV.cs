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
        public LayerMask layerMaskPlayer;
        public LayerMask layerMaskSheep;

        public float tvInnerRadius = 5f;
        public float tvOuterRadius = 10f;
        public bool isOn = true;

        public float tvAngle = 45f;

        public MeshRenderer screen;
        public Material mat1;
        public Material mat2;
        public Material mat3;


        public Transform TvTarget;

        public Rigidbody rb;

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("DetectSheep", 0, 1);
            StartCoroutine(Screenchange());
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void DetectSheep()
        {
            Collider[] overlapSphere0 =
                Physics.OverlapSphere(transform.position, tvOuterRadius, layerMaskSheep,
                    QueryTriggerInteraction.Ignore);


            Collider[] overlapSphere =
                Physics.OverlapSphere(transform.position, tvOuterRadius, layerMaskPlayer,
                    QueryTriggerInteraction.Ignore);

            Sheep[] sheeps = Sheep.FindObjectsOfType<Sheep>();
            float shortestDistance = Mathf.Infinity;
            Sheep nearestSheep = null;
            foreach (Sheep sheep in sheeps)
            {
                if (overlapSphere0.Length > 0) //sheep are in radius
                {
                    sheep.transform.LookAt(TvTarget);
                }

                if (overlapSphere.Length == 0) //no players in radius
                {
                    float distanceToSheep = Vector3.Distance(transform.position, sheep.transform.position);

                    if (distanceToSheep <= tvInnerRadius)
                    {
                        sheep.GetComponent<Movement_ForwardAM>().enabled = false;
                        sheep.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }

                if (overlapSphere.Length > 0) //players are in radius
                {
                    float distanceToSheep = Vector3.Distance(transform.position, sheep.transform.position);
                    if (distanceToSheep <= tvInnerRadius)
                        sheep.GetComponent<Movement_ForwardAM>().enabled = true;
                    sheep.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }

        public IEnumerator Screenchange()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                screen.sharedMaterial = mat1;
                yield return new WaitForSeconds(0.1f);
                screen.sharedMaterial = mat2;
                yield return new WaitForSeconds(0.1f);
                screen.sharedMaterial = mat3;
            }
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