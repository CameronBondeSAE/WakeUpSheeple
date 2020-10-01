using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Movement_ForwardAM : MonoBehaviour
{
   [Header("Settings")]
   private Rigidbody _rB;
   [Tooltip("Adjust these to make the object move in the given direction")]
   public Vector3 forceApplied;
   [Tooltip("Tick this to have more fine control over movement.")]
   public bool clampSpeed;
   [Tooltip("if Clamp Speed is true, the max 'forward' speed will be capped to this value")]
   public float maxSpeed;
   
   [Header("Debug")]
   public Vector3 velocity;
   private void Start()
   {
      if (_rB == null)
      {
         Debug.Log("MV_Fwd: Assigning Rigidbody..");
         _rB = GetComponent<Rigidbody>();
         _rB.freezeRotation = true;
      }
   }

   private void FixedUpdate()
   {
      Move();
   }

   public void Move()
   {
      if (_rB)
      {
         _rB.AddForce(forceApplied, ForceMode.Impulse);
         if (clampSpeed)
         {
            if (_rB.velocity.z > maxSpeed)
            {
               _rB.velocity = new Vector3(_rB.velocity.x ,_rB.velocity.y, maxSpeed);
            }
         }
         velocity = _rB.velocity;
      }
      else
      {
         Debug.Log("MV_Fwd: Rigidbody not found! Please attach one");
      }
   }

   
   
   
   
}
