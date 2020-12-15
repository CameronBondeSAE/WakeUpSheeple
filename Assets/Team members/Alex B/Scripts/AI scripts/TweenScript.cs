using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace AJ
{
    public class TweenScript : MonoBehaviour
    {
        public Transform cubeTransform;
        public Ease animEase;
        public float animDuration;
        // Start is called before the first frame update
        void Start()
        {
            cubeTransform
                .DOMoveY(5f, animDuration)
                .SetEase(animEase)
                .SetLoops(-1, LoopType.Incremental);
        }
    }
}

