using System;
using UnityEngine;

namespace Zach
{
    public class Lava : MonoBehaviour
    {
        public int lavaDamage = 50;
        public float deathJump = 200;

        private void OnCollisionEnter(Collision other)
        {
            TouchedLava(other.collider);
        }

        private void OnTriggerStay(Collider other)
        {
            TouchedLava(other);
        }

        private void TouchedLava(Collider other)
        {
            var health = other.GetComponent<Health>();
            var jump = other.GetComponent<Rigidbody>();

            if (health != null && jump != null)
            {
                jump.AddForce(0, deathJump, 0);
                if (health.currentHealth > 0)
                {
                    health.Damage(lavaDamage);
                }
            }
        }
    }
}