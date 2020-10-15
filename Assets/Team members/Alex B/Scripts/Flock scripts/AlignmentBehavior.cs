using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEngine;

namespace AJ
{
    [CreateAssetMenu(menuName = "Flock/Behavior,Alignment")]
    public class AlignmentBehavior : FilteredFlockBehavior
    {
        private FlockBehavior _flockBehaviorImplementation;

        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0)
                return agent.transform.up;
            
            Vector2 alignmentMove = Vector2.zero;
            List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
            foreach (Transform item in filteredContext)
            {
                alignmentMove += (Vector2) item.transform.transform.up;
            }

            alignmentMove /= context.Count;

            return alignmentMove;

        }
        
    }
}


