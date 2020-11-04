using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEngine;

namespace AlexM
{
    [CreateAssetMenu(menuName = "Boid/Behavior/Cohesion")]
    public class CohesionBehavior : FilteredFlockBehavior
    {
        private FlockBehavior _flockBehaviorImplementation;

        public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0)
                return Vector3.zero;
            
            Vector3 cohesionMove = Vector3.zero;
            List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
            foreach (Transform item in filteredContext)
            {
                cohesionMove += (Vector3) item.position;
            }

            cohesionMove /= context.Count;

            cohesionMove -= (Vector3) agent.transform.position;
            return cohesionMove;

        }
        
    }
}

