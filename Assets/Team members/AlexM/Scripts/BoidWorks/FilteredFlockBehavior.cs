using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEngine;

namespace AlexM
{
    public abstract class FilteredFlockBehavior : FlockBehavior
    {
        public ContextFilter filter;
    }
}

