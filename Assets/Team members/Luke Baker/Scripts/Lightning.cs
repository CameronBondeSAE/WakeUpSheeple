using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEditor;
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
        /// Angle of each 2 points of the strike
        public float strikeAngle;

        // Start is called before the first frame update
        void Start()
        {
       
            StartCoroutine(LightningStrikes());
           
        }
            
        public IEnumerator LightningStrikes()
        {
            float y = 0;

            lineRenderer.positionCount = maxVerticesAmount;
            
            //looping through the points to the max amount of points
            for (int x = 0; x < Random.Range(3, maxVerticesAmount); x++)
            {
                y = y + acceleration * scale;
                
                //branching the lightning by chance
                int chanceOfBranch = Random.Range(0, 10);
                Debug.Log(chanceOfBranch);

                // if (chanceOfBranch > 6)
                // {
                //     for (int a = 0; a < Random.Range(2, maxVerticesAmount); a++)
                //     {
                //         LineRenderer branchLine = new LineRenderer();
                //         lineRenderer.gameObject.AddComponent<LineRenderer>().;
                //         branchLine.SetPosition(x, new Vector3(a, y, Random.Range(80, strikeAngle)));
                //         yield return new WaitForSeconds(strikeDelay);
                //     }
                // }

                //visualise
                lineRenderer.SetPosition(x, new Vector3(x, y, Random.Range(0, strikeAngle)));
                yield return new WaitForSeconds(strikeDelay);

            }
        }
    }
}
