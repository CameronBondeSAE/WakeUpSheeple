using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AlexM
{
    public class AvoidanceBehavior : MonoBehaviour
    
    {
        private FlockBehavior _flockBehaviorImplementation;

        public  Vector3 CalculateMove(List<Transform> neigbours, Flock flock)
        {
            if (neigbours.Count == 0)
                return Vector3.zero;
            
            Vector3 avoidanceMove = Vector3.zero;
            foreach (Transform item in neigbours)
            {
                if (Vector3.SqrMagnitude(item.position - transform.position) < flock.SquareAvoidanceRadius)
                {
                    avoidanceMove += (Vector3)(transform.position - item.position);
                }
                
            }
            avoidanceMove /= neigbours.Count;

            return avoidanceMove;

        }
    }
}

