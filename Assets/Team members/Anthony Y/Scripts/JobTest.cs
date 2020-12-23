using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

namespace AnthonyY
{
    public struct JobTest : IJob
    {
        public void Execute()
        {
            float answer = 0;
            float otherstuff= 0;
       
            for (int i = 0; i < 100000000; i++)
            {
                answer += Mathf.PingPong(50, 1000);
                otherstuff += Mathf.PerlinNoise(0, 1);
            }
    
            Debug.Log("I did something! : " +answer);
            Debug.Log(otherstuff);

        }
    }
    
}

