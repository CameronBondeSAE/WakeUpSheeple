using System;
using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.RigidbodyPhysics;
using UnityEngine;
using DG.Tweening;
using Mirror;

namespace LukeBaker
{
    public class Launcher : MonoBehaviour
    {
        public float launchPower;
        public int launchDelay;
        public int launchDamage;

        public void OnTriggerEnter(Collider other)
        {
            Health health = other.GetComponent<Health>();
            
            StartCoroutine(Launch(other.attachedRigidbody));
            
            //Health script for if the object has health apply some damage to it
            if (health != null)
            {
                health.Damage(launchDamage);
            }
        }

        ///Launch the object that has entered
        IEnumerator Launch(Rigidbody rb)
        {
            yield return new WaitForSeconds(launchDelay);
            rb.velocity = transform.up * launchPower;
        }
    }
}
