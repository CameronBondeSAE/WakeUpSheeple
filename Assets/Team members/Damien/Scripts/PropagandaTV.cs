using System;
using System.Collections;
using System.Collections.Generic;
using AlexM;
using UnityEngine;

namespace Damien
{
    public class PropagandaTV : MonoBehaviour{
        
    public float tvRadius = 10f;
    public bool isOn = true;
    
    
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
        }


        public IEnumerator PlayVideo()
        {
            //TODO:PlayVideo on TV
            
            yield return new WaitForSeconds(10f);
        }



        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, tvRadius);
        }
    }
}