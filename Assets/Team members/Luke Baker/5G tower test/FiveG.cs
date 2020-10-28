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
        public TriggerMarshaller energiserTrigger;
        public TriggerMarshaller attractorTrigger;

        //References to 5g colliders
        [Tooltip("The colliders attached to the 5G Tower")]
        public Collider energiserCol;
        public Collider attractorCol;

        //variables for event functionality
        [Range(550,5000),Tooltip("Adjust the strength of the attraction pull on the entering object")]
        public float attractSpeed;

        //Subscribing
        private void OnEnable()
        {
            attractorTrigger.onTriggerStayEvent += Attraction;
            energiserTrigger.onTriggerEnterEvent += Energise;
        }

        //Unsubscribing
        private void OnDisable()
        {
            attractorTrigger.onTriggerExitEvent -= Attraction;
            energiserTrigger.onTriggerExitEvent -= Energise;
        }

        // when attract event triggered, attract black sheep, UFOs and/or heli's when in the outer trigger
        public void Attraction(Collider attractedCollider)
        {
            attractedCollider.GetComponent<Rigidbody>().AddForce(
                (gameObject.transform.position - attractedCollider.attachedRigidbody.transform.position).normalized *
                attractSpeed * Time.deltaTime);
        }

        // TODO energise function as a permanent rather than dynamic
        public void Energise(Collider energisedCollider)
        {
            //??????????
            // if (energisedCollider.GetComponent<EnergiseBehaviour>() == null)
            // {
            //     Debug.Log(energisedCollider.name + " already has the EnergiseBehaviour script");
            // }
            //
            // energisedCollider.gameObject.GetComponent<EnergiseBehaviour>().isEnergised = true;
            
        }

        //Buttons for the FiveGEditor which will show in the inspector
        public void AttractOn()
        {
            attractorCol.enabled = true;
        }

        public void AttractOff()
        {
            attractorCol.enabled = false;
        }

        public void EnergiseOn()
        {
            energiserCol.enabled = true;
        }

        public void EnergiseOff()
        {
            energiserCol.enabled = false;
        }
    }
}