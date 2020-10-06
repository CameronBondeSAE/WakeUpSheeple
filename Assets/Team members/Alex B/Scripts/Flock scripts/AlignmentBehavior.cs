using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEngine;

namespace AJ
{
    [CreateAssetMenu(menuName = "Flock/Behavior,Alignment")]
    public class AlignmentBehavior : FlockBehavior
    {
        private FlockBehavior _flockBehaviorImplementation;

        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0)
                return agent.transform.up;
            
            Vector2 alignmentMove = Vector2.zero;
            foreach (Transform item in context)
            {
                alignmentMove += (Vector2) item.transform.transform.up;
            }

            alignmentMove /= context.Count;

            return alignmentMove;

        }
        
    }
}


