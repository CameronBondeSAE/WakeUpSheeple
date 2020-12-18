using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace AJ
{
    public class WeatherManagerAJ : NetworkBehaviour
    {
        // Range over which height varies.
        [SyncVar]
        public float Humidity = 1.0f;
        // Distance covered per second along X axis of Perlin plane.
        public float xScale = 1f;
        //Things that need to use this manager
        public RainHandler rainHandler;
        void Update()
        {
            if (isServer)
            {
                Humidity = (Mathf.PerlinNoise(Time.time * xScale, 0.0f) * 2f) - 1f;
                Humidity = Mathf.Clamp(Humidity, 0f, 1f);
            }
            rainHandler.rainSlider = Humidity;
        }
    }
}

