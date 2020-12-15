using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class WeatherManagerAJ : MonoBehaviour
    {
        // Range over which height varies.
        float heightScale = 1.0f;

        // Distance covered per second along X axis of Perlin plane.
        float xScale = 1.0f;
        
        //Things that need to use this manager
        public Rain rain;


        void Update()
        {
            float height = heightScale * Mathf.PerlinNoise(Time.time * xScale, 0.0f);
            Vector3 pos = transform.position;
            pos.y = height;
            transform.position = pos;
        }
    }

    public class Rain
    {
        
    }
}

