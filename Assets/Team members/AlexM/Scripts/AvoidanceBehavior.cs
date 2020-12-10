using System;
using UnityEngine;


namespace AlexM
{
    public class AvoidanceBehavior : MonoBehaviour

    {
        public float SquarAvoidanceRadius;
        public  Vector3 CalculateMove()
        {
            var neighbours = GetComponent<NeigboursDetector>().GetNearbySheep();
            
            if (neighbours.Count == 0)
                return Vector3.zero;
            
            Vector3 avoidanceMove = Vector3.zero;
            foreach (Sheep item in neighbours)
            {
                if (Vector3.SqrMagnitude(item.transform.position - transform.position) < SquarAvoidanceRadius)
                {
                    avoidanceMove += (Vector3)(transform.position - item.transform.position);
                }
                
            }
            avoidanceMove /= neighbours.Count;

            return avoidanceMove;

        }

        //Put this here as just a test. Delete it
        private void FixedUpdate()
        {
            CalculateMove();
        }
    }
}

