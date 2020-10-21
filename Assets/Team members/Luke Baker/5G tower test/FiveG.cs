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

    //References to 5g colliders
    public Collider energiserCol;
    public Collider attractorCol;
    
    //variables for event functionality
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
        attractedCollider.GetComponent<Rigidbody>().AddForce((gameObject.transform.position - attractedCollider.attachedRigidbody.transform.position).normalized * attractSpeed * Time.deltaTime);
    }

    //this function will attach an energise script that is separate to this script to the object that entered the energise collider 
    public void Energise(Collider energisedCollider)
    {
        Debug.Log(energisedCollider.name+ " triggered " + energiserTrigger.name);

        if (energisedCollider.GetComponent<EnergiseBehaviour>() != null)
        {
            Debug.Log(energisedCollider.name +" already has the EnergiseBehaviour script");
        }
        
        // TODO energise function as a permanent rather than dynamic 
        else
        {
            energisedCollider.gameObject.GetComponent<EnergiseBehaviour>().isEnergised = true;
        }
    }

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