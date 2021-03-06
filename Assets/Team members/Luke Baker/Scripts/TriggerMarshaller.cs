using System;
using UnityEngine;

namespace LukeBaker
{
    public class TriggerMarshaller : MonoBehaviour
    {
        //Reusable code for collider trigger events
        public event Action<Collider> onTriggerEnterEvent;
        public event Action<Collider> onTriggerStayEvent;
        public event Action<Collider> onTriggerExitEvent;

        void OnTriggerEnter(Collider trigger)
        {
            onTriggerEnterEvent?.Invoke(trigger);
        }

        void OnTriggerStay(Collider trigger)
        {
            onTriggerStayEvent?.Invoke(trigger);
        }

        void OnTriggerExit(Collider trigger)
        {
            onTriggerExitEvent?.Invoke(trigger);
        }
    }
}