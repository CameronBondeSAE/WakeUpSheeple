using System.Collections;
using UnityEngine;

namespace LukeBaker
{
    public class Launcher : MonoBehaviour
    {
        public float launchPower;
        public int launchDelay;
        public int launchDamage;
        public AudioSource launcherSound;

        public void OnTriggerEnter(Collider other)
        {
            Health health = other.GetComponent<Health>();
            
            StartCoroutine(Launch(other.attachedRigidbody));
            
            //Health script for if the object has health apply some damage to it
            if (health != null)
            {
                if (health.currentHealth > 0f)
                {
                    health.Damage(launchDamage);
                }
            }
        }

        ///Launch the object that has entered
        IEnumerator Launch(Rigidbody rb)
        {
            yield return new WaitForSeconds(launchDelay);
            
            //sound play
            launcherSound.Play();
            
            rb.velocity = transform.up * launchPower;
        }
    }
}
