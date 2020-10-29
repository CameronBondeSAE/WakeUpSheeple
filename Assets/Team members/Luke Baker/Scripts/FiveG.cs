using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Rendering;

namespace LukeBaker
{
    public class FiveG : MonoBehaviour
    {
        //Energising is when the animals gain a buff or de-buff.
        //Attracting is when UFO's or helis and black sheep travel toward tower location.

        //Reference to the TriggerMarshallers
        [Tooltip("Reference to the TriggerMarshaller script so objects with colliders can subscribe to the events")]
        
        public TriggerMarshaller attractorTrigger;

        //References to 5g colliders
        [Tooltip("The colliders attached to the 5G Tower")]
        public Collider attractorCol;

        //variables for event functionality
        [Range(550,5000),Tooltip("Adjust the strength of the attraction pull on the entering object")]
        public float attractSpeed;

        //Subscribing
        public void OnEnable()
        {
            attractorTrigger.onTriggerStayEvent += Attraction;
        }

        //Unsubscribing
        public void OnDisable()
        {
            attractorTrigger.onTriggerExitEvent -= Attraction;
        }

        // when attract event triggered, attract black sheep, UFOs and/or heli's when in the outer trigger
        public void Attraction(Collider attractedCollider)
        {
            attractedCollider.GetComponent<Rigidbody>().AddForce(
                (gameObject.transform.position - attractedCollider.attachedRigidbody.transform.position).normalized *
                attractSpeed * Time.deltaTime);
        }
        public void AttractOn()
        {
            attractorCol.enabled = true;
        }

        public void AttractOff()
        {
            attractorCol.enabled = false;
        }
    }
}