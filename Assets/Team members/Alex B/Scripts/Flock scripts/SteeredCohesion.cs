using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEngine;

namespace AJ
{
    [CreateAssetMenu(menuName = "Flock/Behavior,Steered Cohesion")]
    public class SteeredCohesion : FlockBehavior
    {
        Vector2 currentVelocity;
        //how long it takes the agent to get from it's current state to calculated state.
        public float agentSmoothTime = 0.5f;
        
        private FlockBehavior _flockBehaviorImplementation;

        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            //if no neighbors, return no adjustments
            if (context.Count == 0)
                return Vector2.zero;
            
            //add all points together and average
            Vector2 cohesionMove = Vector2.zero;
            foreach (Transform item in context)
            {
                cohesionMove += (Vector2) item.position;
            }
            cohesionMove /= context.Count;

            //create offset from agent position
            cohesionMove -= (Vector2) agent.transform.position;
            cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref cohesionMove, agentSmoothTime);
            return cohesionMove;

        }
        
    }
}