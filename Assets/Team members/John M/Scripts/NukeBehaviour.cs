using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NukeBehaviour : MonoBehaviour
{
    
    public GameObject nuke;
    //particle effect to be added here
    public float power;
    public float radius;
    public float upForce;
    public int NukeDamage;
    
   
    

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
                hit.GetComponent<Health>().Damage(NukeDamage);
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
