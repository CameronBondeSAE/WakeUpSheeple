﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.Rendering;
using Mirror;
using DG.Tweening;

namespace LukeBaker
{
    public class FiveG : MonoBehaviour
    {
        //Energising is when the animals gain a buff or de-buff?
        //Attracting is when an object within its trigger field add force towards the towers centre.

        //Reference to the TriggerMarshallers
        [Tooltip("Reference to the TriggerMarshaller script so objects with colliders can subscribe to the events")]
        
        public TriggerMarshaller attractorTrigger;

        //References to 5g colliders
        [Tooltip("The colliders attached to the 5G Tower")]
        public Collider attractorCol;

        //variables for event functionality
        [Range(550,5000),Tooltip("Adjust the strength of the attraction pull on the entering object")]
        public float attractSpeed;

        [Header("Ping animation stuff")]
        public float animationDuration;
        public GameObject attractPing;
        public Ease ease;

        public void Start()
        {
            AttractionPingVisual();
        }

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

        // when attract event triggered, attract objects entered
        public void Attraction(Collider attractedCollider)
        {
            attractedCollider.GetComponent<Rigidbody>().AddForce(
                (gameObject.transform.position - attractedCollider.attachedRigidbody.transform.position).normalized *
                attractSpeed * Time.deltaTime);
        }

        public void AttractionPingVisual()
        {
            Sequence sequence = DOTween.Sequence();
            attractPing.SetActive(true);
            sequence.Append(attractPing.transform.DOScale(attractPing.transform.localScale.normalized.magnitude,animationDuration * Time.deltaTime).SetEase(ease));
            sequence.SetLoops(-1);
        }
        
        //to turn on and off the attractor in the inspector of Unity
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