using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class WeatherManagerAJ : MonoBehaviour
    {
        // Range over which height varies.
        public float Humidity = 1.0f;

        // Distance covered per second along X axis of Perlin plane.
        public float xScale = 1f;
        
        //Things that need to use this manager
        public RainHandler rainHandler;  
        public void Start()
        {
            
        }


        void Update()
        {
            Humidity = Mathf.PerlinNoise(Time.time * xScale, 0.0f);
            rainHandler.rainSlider = Humidity;
        }
    }

    public class Rain
    {
        
    }
}

