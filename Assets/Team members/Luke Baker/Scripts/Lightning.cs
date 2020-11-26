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
            for (int x = 1; x < 10; x++)
            {
                
                 for (int i = x; i < 10; i++)
                 {
                     //visualise
                     lineRenderer.SetPosition(i, new Vector3(Random.Range(-strikeAngle, strikeAngle)* scale, y * scale,
                         Random.Range(-strikeAngle, strikeAngle) * scale) + lineRenderer.GetPosition(i-1));
                     lineRenderer.startWidth = startStrikeWidth;
                     lineRenderer.endWidth = endWidthStrike;
                 }
                 y = y + acceleration;
            }
            
            //TODO figure out how to use OverlapSphere and what I am suppose to do with it.
            //find the current strike point
            Vector3 finalStrikePoint = lineRenderer.transform.position;
            Physics.OverlapSphere(finalStrikePoint, lightningHitRange);

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
        
        public void LightningOff()
        {
            gameObject.SetActive(false);
        }
    }
}
