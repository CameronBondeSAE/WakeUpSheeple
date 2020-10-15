using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEngine;

namespace AJ
{
    [CreateAssetMenu(menuName = "Flock/Behavior,Cohesion")]
    public class CohesionBehavior : FilteredFlockBehavior
    {
        private FlockBehavior _flockBehaviorImplementation;

        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0)
                return Vector2.zero;
            
            Vector2 cohesionMove = Vector2.zero;
            List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
            foreach (Transform item in filteredContext)
            {
                cohesionMove += (Vector2) item.position;
            }

            cohesionMove /= context.Count;

            cohesionMove -= (Vector2) agent.transform.position;
            return cohesionMove;

        }
        
    }
}

