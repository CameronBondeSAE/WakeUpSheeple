using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace LukeBaker
{
    public class ApplyEnergise : MonoBehaviour
    {
        //This script needs work, figure out what energise does and it would make it easier.
        //variables
        public TriggerMarshaller energiserTrigger;
        public Collider energiserCol;
        public bool isEnergised;

        //Event Subscription
        private void OnEnable()
        {
            energiserTrigger.onTriggerEnterEvent += EnergiseObject;
        }

        private void OnDisable()
        {
            energiserTrigger.onTriggerExitEvent -= EnergiseObject;
            isEnergised = false;
        }
        
        public void EnergiseObject(Collider trigger)
        {
            // isEnergised = true;
            // while (isEnergised = true)
            // {
            //     //apply buff or de-buff
            // }
        }
    }
}