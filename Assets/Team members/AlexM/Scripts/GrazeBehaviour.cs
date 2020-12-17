using System;
using System.Collections;
using System.Collections.Generic;
using AlexM;
using AnthonyY;
using UnityEngine;

public class GrazeBehaviour : MonoBehaviour
{
   //If wolves are close, apply forces
   //if they arent? stop.

   [HideInInspector]
   public bool isGrazing;

   private float wolfDistance;
   private WolfDetector _wolfDetector;
   private Movement_ForwardAM _moveController;
   private Sheep _sheep;

   private void OnEnable()
   {
      _wolfDetector = GetComponent<WolfDetector>();
      _moveController = GetComponent<Movement_ForwardAM>();
      _sheep = GetComponent<Sheep>();
   }


   void Graze()
   {
      wolfDistance = 0;
      foreach (PlayerBehaviour wolf in _wolfDetector.GetNearbyWolves())
      {
         wolfDistance += Vector3.Distance(wolf.transform.position, transform.position);
      }
      wolfDistance /= _wolfDetector.GetNearbyWolves().Count;

      // if (wolfDistance > 1)
      {
         _moveController.zForce = _wolfDetector.radius - wolfDistance;
      }
   }

   private void FixedUpdate()
   {
      Graze();
   }
}
