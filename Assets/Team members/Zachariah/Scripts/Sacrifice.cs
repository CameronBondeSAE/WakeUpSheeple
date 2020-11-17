using UnityEngine;

namespace Zach
{
    public class Sacrifice : MonoBehaviour
    {
        public Health health;
        public float deathTimer;

        private void OnEnable()
        {
            health.DeathEvent += HealthOnDeathEvent;
        }

        private void OnDisable()
        {
            health.DeathEvent -= HealthOnDeathEvent;
        }

        private void HealthOnDeathEvent(Health obj)
        {
            Destroy(gameObject, deathTimer);
        }
    }
}