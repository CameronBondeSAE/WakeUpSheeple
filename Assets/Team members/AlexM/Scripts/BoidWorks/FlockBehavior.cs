using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEngine;

namespace AlexM
{
    public abstract class FlockBehavior : MonoBehaviour
    {
        public abstract Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock);
    }
}

