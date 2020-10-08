using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall
{
    public class MoveForward : MonoBehaviour
    {
        public Rigidbody rb;
        public float speed;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {

            rb.AddForce(transform.forward * speed);
        }
    }
}