using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeBehaviour : MonoBehaviour
{
    
    public GameObject nuke;
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
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
            }
            //hit.GetComponent<Health>().Damage(150);
        }
        gameObject.SetActive(false);
        
    }

}
