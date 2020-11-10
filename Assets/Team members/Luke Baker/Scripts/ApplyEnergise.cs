using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.SceneManagement;
using UnityEngine;
using Mirror;

namespace LukeBaker
{
    public class ApplyEnergise : MonoBehaviour
    {
        //This script needs work, figure out what energise does and it would make it easier.
        //variables
        public TriggerMarshaller energiserTrigger;
        
        //Tweening or animation variables
        [Tooltip("The duration of the energise movement")]
        public float energiseDuration;
        [Tooltip("The time waiting for the object that is energised to move")]
        public float waitForEnergise;
        [Tooltip("The animation type for the movement of the energised object")]
        public Ease ease;
        [Tooltip("When the energiser is triggered by an object, the object will moves toward the energiseEndPosition"),Header("Required")]
        public Transform energiseEndPosition;

        //Event Subscription
        private void OnEnable()
        {
            energiserTrigger.onTriggerEnterEvent += EnergiseObject;
        }

        private void OnDisable()
        {
            energiserTrigger.onTriggerExitEvent -= EnergiseObject;
        }
        
        //Function for the inner collider of the 5G tower
        void EnergiseObject(Collider trigger)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(trigger.gameObject.transform.DOMove(energiseEndPosition.position, energiseDuration *Time.deltaTime, true)).SetDelay(waitForEnergise).SetEase(ease);
        }
    }
}