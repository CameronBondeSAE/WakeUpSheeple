using System;
using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.RigidbodyPhysics;
using UnityEngine;

namespace LukeBaker
{
    public class Launcher : MonoBehaviour
    {
        public float launchPower;
        public int launchDelay;

        public void OnTriggerEnter(Collider other)
        {
            StartCoroutine(Launch(other.attachedRigidbody));
        }

        IEnumerator Launch(Rigidbody rb)
        {
            yield return new WaitForSeconds(launchDelay);
            rb.velocity = transform.forward * launchPower;
        }
    }
}
