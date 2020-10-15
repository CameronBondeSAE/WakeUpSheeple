using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveG : MonoBehaviour
{
    //Energising is when the animals gain a speed boost???.
    //Attracting is when UFO's or helis and black sheep travel toward tower location.
    
    //Reference to the TriggerMarshallers
    public TriggerMarshaller energiserTrigger;
    public TriggerMarshaller attractorTrigger;
    
    //References
    public Collider energiserCol;
    public Collider attractorCol;
    
    //variables for event functionality
    public float attractSpeed;
    //this probably needs to be set for current parents position
    public Vector3 attractionTargetPos;

    //Subscribing
    private void OnEnable()
    {
        attractorTrigger.onTriggerStayEvent += Attraction;
        energiserTrigger.onTriggerEnterEvent += Energise;
        
    }

    //Unsubscribing
    private void OnDisable()
    {
        attractorTrigger.onTriggerStayEvent -= Attraction;
        energiserTrigger.onTriggerEnterEvent -= Energise;
    }

    // when attract event triggered, attract black sheep and UFOs when in the outer trigger
    public void Attraction(Collider trigger)
    {
        Debug.Log(trigger.name+ " triggered " + attractorCol.name);
        trigger.GetComponent<Rigidbody>().AddForce((attractionTargetPos - trigger.attachedRigidbody.transform.position).normalized * attractSpeed * Time.deltaTime);
    }

    //when energise event triggered, sheep will get a speed boost for a certain amount of time while in the inner trigger but can attract Helis???
    public void Energise(Collider trigger)
    {
        Debug.Log(trigger.name + " triggered " + energiserCol.name);
        attractorTrigger.onTriggerStayEvent -= Attraction;

        //TODO: make a component for speed in a sheep script or speed script apply this for a certain amount of time
        
        //trigger.GetComponent<Rigidbody>().AddForce((Vector3.forward * speed * Time.deltaTime).normalized);
    }
}