using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Rigidbody))]
public class Movement_ForwardAM : MonoBehaviour
{
#region Variables

   [Header("Settings")]
   private Rigidbody _rB;

   [Tooltip("Adjust these to make the object move in the given direction")]
   public float zForce;
   private Vector3 forceApplied;
   [Tooltip("Tick this to have more fine control over movement.")]
   public bool clampSpeed;
   [Tooltip("if Clamp Speed is true, the max 'forward' speed will be capped to this value")]
   public float maxSpeed;

   public event Action<Vector3> velEvent;
   
   //Debugging
   private Vector3 vel;
   

#endregion

   private void Awake()
   {
      if (_rB == null)
      {
         Debug.Log("MV_Fwd: Assigning Rigidbody..");
         _rB = GetComponent<Rigidbody>();

         if (_rB.constraints != RigidbodyConstraints.FreezeRotationX)
         {
            _rB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
         }
      }
   }

   private void Update()
   {
      Debugging();
      //Move();
      GoForward();
      DoStop();
      
   }

   private void FixedUpdate()
   {
      //GoForward();
   }

   public void GoForward()
   {
      forceApplied.z = zForce;
      Vector3 localSpeed = transform.InverseTransformDirection(forceApplied);

      if (clampSpeed)
      {
         //Negatives arent clamped for now...
         if (localSpeed.z > maxSpeed)
         {
            _rB.velocity = new Vector3(vel.x, vel.y, maxSpeed);
         }
         else
         {
            _rB.AddRelativeForce(0,0,forceApplied.z);
         }
      }
      else
      {
         _rB.AddRelativeForce(0,0,forceApplied.z);
      }
   }

   void DoStop()
   {
      if (zForce == 0)
      {
         _rB.velocity = Vector3.zero;
      }
   }

   private void Debugging()
   {
      vel = _rB.velocity;
      velEvent?.Invoke(vel);
   }
   
   // public void Move()
   // {
   //    Vector3 localSpeed = transform.InverseTransformDirection(forceApplied);
   //    if (_rB)
   //    {
   //       if (clampSpeed)
   //       {
   //          if (localSpeed.z > maxSpeed)
   //          {
   //             Vector3 worldSpeed = transform.TransformDirection(localSpeed);
   //             _rB.velocity = new Vector3(worldSpeed.x ,worldSpeed.y, maxSpeed);
   //          }
   //       }
   //       _rB.AddRelativeForce(forceApplied.normalized, ForceMode.VelocityChange);
   //       velocity = _rB.velocity;
   //    }
   //    else
   //    {
   //       Debug.Log("MV_Fwd: Rigidbody not found! Please attach one");
   //       return;
   //    }
   // }
   
   

   
   
   
   
}
