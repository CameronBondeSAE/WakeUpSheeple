using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveG : MonoBehaviour
{
    //Energising is when the animals gain a speed boost.
    //Attracting is when UFO's and black sheep travel toward tower location.
    
    //Reference to the TriggerMarshallers
    public TriggerMarshaller energiserTrigger;
    public TriggerMarshaller attractorTrigger;
    
    //References
    public Collider energiserCol;
    public Collider attractorCol;
    
    //variables for event functionality
    public float speed;
    public float timeEffected;
    public Vector3 attractionTargetPos;
    public bool canAttract = false;
    public bool canEnergise = false;

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
        canAttract = true;
        
        float step = speed * Time.deltaTime;
        trigger.GetComponent<Rigidbody>().AddForce((attractionTargetPos - trigger.attachedRigidbody.transform.position).normalized * speed * Time.deltaTime);
    }

    //when energise event triggered, sheep will get a speed boost for a certain amount of time while in the inner trigger but can attract UFO's???
    public void Energise(Collider trigger)
    {
        Debug.Log(trigger.name + " triggered " + energiserCol.name);
        canEnergise = true;
        
        //TODO: make a direction variable the sheep are facing or speed change to energise within 5g collider
        
        trigger.GetComponent<Rigidbody>().AddForce((Vector3.forward * speed * Time.deltaTime).normalized);
    }
}