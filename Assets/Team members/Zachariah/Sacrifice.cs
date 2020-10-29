using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Sacrifice : MonoBehaviour
{
    public Health health;
    public Rigidbody rb;
    public int deathJump;
    public float deathTimer;
    private void OnEnable()
    {
        health.DeathEvent += HealthOnDeathEvent;
    }
    private void OnDisable()
    {
        health.DeathEvent -= HealthOnDeathEvent;
    }
    
    private void HealthOnDeathEvent(Health obj)
    {
        rb.velocity = new Vector3(0,deathJump,0);
        Destroy(gameObject,deathTimer);
    }
}

