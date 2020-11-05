using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{

    public Health health;
[Tooltip("True = receiving damage. False = dealing damage")]
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
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (Damagee == false)
        {
            other.gameObject.GetComponent<Health>()?.Damage(50);
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
