using System;
using System.Collections;
using System.Collections.Generic;
using AlexM;
using UnityEngine;
using UnityEngine.Serialization;

namespace Damien
{
    public class PropagandaTV : MonoBehaviour
    {
        public float tvInnerRadius = 10f;
        public float tvOuterRadius = 15f;
        public bool isOn = true;

        public float tvAngle;

        public GameObject sheep;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(PlayVideo());
        }

        // Update is called once per frame
        void Update()
        {
            DetectSheep();
        }

        public void DetectSheep()
        {
            Sheep[] sheeps = Sheep.FindObjectsOfType<Sheep>();
            float shortestDistance = Mathf.Infinity;
            Sheep nearestSheep = null;
            foreach (Sheep sheep in sheeps)
            {
                float distanceToSheep = Vector3.Distance(transform.position, sheep.transform.position);
                if (distanceToSheep < shortestDistance)
                {
                    shortestDistance = distanceToSheep;
                    nearestSheep = sheep;
                }
            }

            if (nearestSheep == null)
            {
                return;
            }

            if (shortestDistance <= tvInnerRadius)
            {
                StartCoroutine(HypnotiseSheep());
            }
            else if (shortestDistance <= tvOuterRadius)
            {
                StartCoroutine(LureSheep());
            }
            else
            {
                StopCoroutine(HypnotiseSheep());
                StopCoroutine(LureSheep());
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