using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMarshaller : MonoBehaviour
{
    //Reusable code for collider trigger events
    public event Action<Collider> triggerEnterEvent;
    void OnTriggerEnter (Collider trigger)
    {
        triggerEnterEvent?.Invoke(trigger);
    }
}
