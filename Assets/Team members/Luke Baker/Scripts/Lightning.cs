using System.Collections;
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
        public float lightningHitRadius;
        /// Random angle of each 2 points of the strike
        public float strikeAngle;

        public int damage;
        //public float distanceToGround;

        private void Start()
        {
            StartCoroutine(LightningStrike());
        }

        public IEnumerator LightningStrike()
        {
            float y = 0;

            lineRenderer.positionCount = maxVerticesAmount;
            //Setting the first point to object position
            lineRenderer.SetPosition(0,transform.position);
            //looping through the points to the max amount of points
            for (int x = 1; x < maxVerticesAmount; x++)
            {
                // every new segment is changing position randomly, so the linerenderer doesn't go back to 0
                for (int i = x; i < maxVerticesAmount; i++)
                {
                    //visualise
                    lineRenderer.SetPosition(i, new Vector3(Random.Range(-strikeAngle, strikeAngle)* scale, y * scale,
                        Random.Range(-strikeAngle, strikeAngle) * scale) + lineRenderer.GetPosition(i-1));
                }
                //for direction
                y = y + acceleration;
                
                //this will make a line collision check between each line
                if (Physics.Linecast(lineRenderer.GetPosition(x-1), lineRenderer.GetPosition(x)))
                {
                    //then this will check for each colliders that overlap and cause demage
                    Collider[] overlapSphere = Physics.OverlapSphere(lineRenderer.GetPosition(x), lightningHitRadius);

                    foreach (Collider col in overlapSphere)
                    {
                        if (col.GetComponent<Health>())
                        {
                    
                            col.GetComponent<Health>().Damage(damage);
                        }
                    }
                    //we hit something lightning will stop
                    continue;
                }
            }

            yield return new WaitForSeconds(timeStrikeIsOn);
            
            //TODO switch to destroy when finished if we want to make the cloud instantiate it
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
