using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall
{
    public class Wander : MonoBehaviour
    {
        public float PerlinY;

        
        void Update()
        {
            PerlinY = Mathf.PerlinNoise(0, Time.time / 10f);


            PerlinY = ((PerlinY * 2f) - 1f);

            transform.Rotate(0, PerlinY, 0);
        }
    }
}