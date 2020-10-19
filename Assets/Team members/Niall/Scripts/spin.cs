using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall
{
    public class spin : MonoBehaviour
    {

        [Range(0, 10)] public float speed;

            void Update()
        {
            transform.Rotate(0,speed, 0);
        }
    }
}
