using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexM
{
    public abstract class ContextFilter : MonoBehaviour
    {
        public virtual List<Transform> Filter(FlockAgent agent, List<Transform> original)
        {
            return Filter(agent, original);
        }
    }
}

