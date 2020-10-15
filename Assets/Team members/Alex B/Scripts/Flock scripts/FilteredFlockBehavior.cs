using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEngine;

namespace AJ
{
    public abstract class FilteredFlockBehavior : FlockBehavior
    {
        public ContextFilter filter;
    }
}

