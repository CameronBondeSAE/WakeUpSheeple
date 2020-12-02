using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LukeBaker
{
    public class Lightning : MonoBehaviour
    {
        public LineRenderer lineRenderer;
        /// Amount of lightning strike points
        public int maxVerticesAmount;
        /// Distance between each strike point
        public float acceleration;
        /// Length of strike
        public float scale;
        /// Time the strike is visible for
        public float timeStrikeIsOn;
        /// The radius of lightning hit effect
        public float lightningHitRange;
        /// Random angle of each 2 points of the strike
        public float strikeAngle;
        public float startStrikeWidth;
        public float endWidthStrike;
        
        public int damage;

        private void Start()
        {
            StartCoroutine(LightningStrike());
        }

        public IEnumerator LightningStrike()
        {
            gameObject.SetActive(true);
            float y = 0;

            
            lineRenderer.positionCount = maxVerticesAmount;
            //Setting the first point to object position
            lineRenderer.SetPosition(0,transform.position);
            //looping through the points to the max amount of points
            for (int x = 1; x < maxVerticesAmount; x++)
            {
                for (int i = x; i < maxVerticesAmount; i++)
                {
                    //visualise
                    lineRenderer.SetPosition(i, new Vector3(Random.Range(-strikeAngle, strikeAngle)* scale, y * scale,
                        Random.Range(-strikeAngle, strikeAngle) * scale) + lineRenderer.GetPosition(i-1));
                    lineRenderer.startWidth = startStrikeWidth;
                    lineRenderer.endWidth = endWidthStrike;
                }
                y = y + acceleration;
            }
            
            //find the final strike point & set the lightning collider position
            //remember index things need -1 for reference because index starts at 0
            Vector3 finalStrikePoint = lineRenderer.GetPosition(maxVerticesAmount-1);

            //TODO figure out how to use OverlapSphere and what I am suppose to do with it?
            Debug.DrawLine(finalStrikePoint,finalStrikePoint + Vector3.up, Color.green, 5f);
            Collider[] overlapSphere = Physics.OverlapSphere(finalStrikePoint, lightningHitRange);

            foreach (Collider col in overlapSphere)
            {
                if (col.GetComponent<Health>())
                {
                    
                    col.GetComponent<Health>().Damage(damage);
                }
            }

            yield return new WaitForSeconds(timeStrikeIsOn);
            
            //remove the strike
            LightningOff();
        }
        
        //Inspector UI stuff
        public void LightningOn()
        {
            gameObject.SetActive(true);
            StartCoroutine(LightningStrike());
        }
        
        //will probably need to destroy the object depending on the weather script
        public void LightningOff()
        {
            gameObject.SetActive(false);
        }
    }
}
