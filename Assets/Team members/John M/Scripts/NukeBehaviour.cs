using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeBehaviour : MonoBehaviour
{
    
    public GameObject nuke;
    //particle effect to be added here
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;
    public float nukeTimer = 15;
    

    void OnCollisionEnter()
    {
        Detonate();
        Debug.Log("Collision Detected");
    }

    void Detonate()
    {
        Vector3 explosionPosition = nuke.transform.position;
        //activate particle explosion for nuke
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
		
		foreach (Collider hit in colliders)
        {
            if (hit.GetComponent<Health>())
            {
                hit.GetComponent<Health>().Damage(75);
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
                }
            }
            
        }
        Destroy(nuke);
        
    }

}
