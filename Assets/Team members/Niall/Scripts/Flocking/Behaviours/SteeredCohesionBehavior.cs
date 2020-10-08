using System.Collections;
using System.Collections.Generic;
using Niall;
using UnityEngine;

namespace Niall
{

    [CreateAssetMenu(menuName =  "Niall's_Flock/Behaviour/Steered Cohesion")]
    public class SteeredCohesionBehavior : FlockBehaviour
    {
        private Vector3 currentVelocity;
        public float agentSmoothTime = 0.5f;

        public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            // if no neighbours, return no adjustment
            if (context.Count == 0)
            {
                return Vector3.zero;
            }
           
            // add all points together and average
            Vector3 cohesionMove = Vector3.zero;
            foreach (Transform item in context)
            {
                cohesionMove += item.position;
            }

            cohesionMove /= context.Count;
           
            // create offset from agent position
            cohesionMove -= agent.transform.position;
            cohesionMove = Vector3.SmoothDamp(agent.transform.forward, cohesionMove, ref currentVelocity,
                agentSmoothTime);
            return cohesionMove;
        }
    }
}