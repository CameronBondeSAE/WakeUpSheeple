using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveG : MonoBehaviour
{
    //Energising is when the animals gain a speed boost.
    //Attracting is when UFO's and black sheep travel toward tower location.
    
    //Reference to the game objects TriggerMarshallers
    public TriggerMarshaller energiserTrigger;
    public TriggerMarshaller attractorTrigger;
    
    //References
    public Collider energiser;
    public Collider attractor;
    
    //variables for event functionality
    public float speed;
    public float timeEffected;
    public Transform target;

    //Subscribing
    private void OnEnable()
    {
        attractorTrigger.triggerEnterEvent += Attraction;
        energiserTrigger.triggerEnterEvent += Energise;
        
    }

    //Unsubscribing
    private void OnDisable()
    {
        attractorTrigger.triggerEnterEvent -= Attraction;
        energiserTrigger.triggerEnterEvent -= Energise;
        
    }

    // when attract event triggered, attract black sheep and UFOs when in the outer trigger
    public void Attraction(Collider trigger)
    {
        Debug.Log(trigger.name+ " triggered " + attractor.name);
        
    }

    //when energise event triggered, sheep will get a speed boost for a certain amount of time while in the inner trigger
    public void Energise(Collider trigger)
    {
        Debug.Log(trigger.name+ " triggered " + energiser.name);
        trigger.transform.position += transform.forward * Time.deltaTime * speed;
    }
}