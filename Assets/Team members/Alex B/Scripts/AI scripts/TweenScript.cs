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
            var tweenerCore = cubeTransform
                .DOMoveY(5f, animDuration)
                .SetDelay(Random.Range(0, 2f))
                .SetEase(animEase)
                .SetLoops(-1);
            //tweenerCore.Pause();
            //yield return new WaitForSeconds(Random.Range(0, 2f));
            //tweenerCore.Play();
            //.SetLoops(-1, LoopType.Incremental);
        }
        
    }
}

