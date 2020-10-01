using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

namespace Niall
{
    public class EyeWander : MonoBehaviour
    {
        public float PerlinY;
        public float PerlinZ;


        private void Update()
        {
            PerlinY = Mathf.PerlinNoise(0, Time.time);
            PerlinZ = Mathf.PerlinNoise(Time.time, 0);
            
            // TODO something cleaner than this?
            
            if (PerlinY <= 0.49f)
            {
                PerlinY = -PerlinY;
            }
            else
            {
                PerlinY = +PerlinY;
            }
            
            if (PerlinZ <= 0.49f)
            {
                PerlinZ = -PerlinZ;
            }
            else
            {
                PerlinZ = +PerlinZ;
            }

            transform.Rotate(0, PerlinY, PerlinY);
            
            //TODO Clamp rotation
            


        }
    }
}
