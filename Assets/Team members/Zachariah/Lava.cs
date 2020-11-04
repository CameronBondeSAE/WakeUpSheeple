using UnityEngine;

namespace Zach
{
    public class Lava : MonoBehaviour
    {
        public int lavaDamage;
        public float deathJump;

        private void OnTriggerEnter(Collider other)
        {
            var health = other.GetComponent<Health>();
            var jump = other.GetComponent<Rigidbody>();

            if (health != null && jump != null)
            {
                jump.AddForce(0, deathJump, 0);
                health.Damage(lavaDamage);
            }
        }
    }
}