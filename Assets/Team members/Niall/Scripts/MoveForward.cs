using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall
{
    public class MoveForward : MonoBehaviour
    {
        public Rigidbody rb;
        public float speed;
        public float perlinY;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            perlinY = Mathf.PerlinNoise(0, Time.time/10f);


            perlinY = ((perlinY * 2f) - 1f);

            transform.Rotate(0, perlinY, 0);

            rb.AddForce(transform.forward * speed);
        }
    }
}