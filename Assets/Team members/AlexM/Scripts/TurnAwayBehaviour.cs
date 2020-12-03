using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using AnthonyY;
using UnityEngine;

public class TurnAwayBehaviour : MonoBehaviour
{
    public Vector3 targetDirection;
    public Vector3 myPos;
    public PlayerBehaviour target;
    public Rigidbody rb;
    public float turnForce;
    public float dogDistance;

    private void Start()
    {
        target = FindObjectOfType<PlayerBehaviour>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (target)
        {
            targetDirection = target.transform.position - rb.position;
        }
        else
        {
            return;
        }
        dogDistance = Vector3.Distance(target.transform.position, transform.position);
        // Direction to target
        
        
        myPos = transform.forward;

        Vector3 cross = Vector3.Cross(targetDirection, myPos);

        //Debug.DrawRay(transform.position, cross, Color.red, 0f, false);
        //Debug.Log(Vector3.Dot(targetDirection, myPos));

        rb.AddTorque((cross * (turnForce * Time.deltaTime)) / dogDistance);
    }
}
