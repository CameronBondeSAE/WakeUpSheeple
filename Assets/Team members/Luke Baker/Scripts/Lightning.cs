using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

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
        /// Time between each point being drawn
        public float strikeDelay;
        /// Random angle of each 2 points of the strike
        public float strikeAngle;
        public float startStrikeWidth;
        public float endWidthStrike;

        // Start is called before the first frame update
        void Start()
        {
       
            StartCoroutine(LightningStrikes());
           
        }
            
        public IEnumerator LightningStrikes()
        {
            float y = 0;

            lineRenderer.positionCount = maxVerticesAmount;
            //Setting the first point to object position
            lineRenderer.SetPosition(0,transform.position);
            //looping through the points to the max amount of points
            for (int x = 1; x < 10; x++)
            {

                 //branching the lightning by chance
                 // int chanceOfBranch = Random.Range(0, 10);
                 // Debug.Log(chanceOfBranch);

                 // if (chanceOfBranch > 6)
                 // {
                 //     for (int a = 0; a < Random.Range(2, maxVerticesAmount); a++)
                 //     {
                 //         LineRenderer branchLine = lineRenderer.gameObject.AddComponent<LineRenderer>();
                 //         StartCoroutine(LightningStrikes());
                 //     }
                 // }
                 for (int i = x; i < 10; i++)
                 {
                     //visualise
                     lineRenderer.SetPosition(i, new Vector3(Random.Range(-strikeAngle, strikeAngle), y, Random.Range(-strikeAngle, strikeAngle)) + lineRenderer.GetPosition(i-1));
                     lineRenderer.startWidth = startStrikeWidth;
                     lineRenderer.endWidth = endWidthStrike;
                    
                 }
                 y = y + acceleration * scale;

                 yield return new WaitForSeconds(strikeDelay);
            }
        }
    }
}
