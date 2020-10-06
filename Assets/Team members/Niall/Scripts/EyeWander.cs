using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

namespace Niall
{
    public class EyeWander : MonoBehaviour
    {
        public float perlinY;

        public float speed = 1f;


        private void Update()
        {
            perlinY = Mathf.PerlinNoise(0, Time.time);

            perlinY = ((perlinY * 2f) - 1f) * speed;

            transform.Rotate(0, perlinY, perlinY);

            //TODO Clamp rotation
        }
    }
}