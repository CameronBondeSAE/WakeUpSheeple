using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace LukeBaker
{
    public class EnergiseBehaviour : MonoBehaviour
    {
        //This script needs work, figure out what energise does and it would make it easier.
        //variables
        public bool isEnergised;

        public void EnergiseObject()
        {
            while (isEnergised = true)
            {
                //apply buff or de-buff
            }
        }

        private void OnEnable()
        {
            EnergiseObject();
        }
    }
}