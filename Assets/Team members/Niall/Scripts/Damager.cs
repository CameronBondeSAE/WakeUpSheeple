using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{

    public Health health;

    public bool Damagee;
    void Awake()
    {
        if (Damagee)
        {
            health.DeathEvent += Deathhh;
        }
        
    }



    void Deathhh(Health health)
    {
        Destroy(this);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (Damagee == false)
        {
            other.gameObject.GetComponent<Health>().Damage(20);
        }
    }


    private void OnDestroy()
    {
        if (Damagee)
        {
            health.DeathEvent -= Deathhh;
        }
    }
}
