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
	  List<PlayerBehaviour> nearbyWolves = _wolfDetector.GetNearbyWolves();

	  if (nearbyWolves.Count <= 0)
	  {
		  _moveController.speedScale = 0;
		  return;
	  }
	  
	  foreach (PlayerBehaviour wolf in nearbyWolves)
      {
         wolfDistance += Vector3.Distance(wolf.transform.position, transform.position);
      }

	  wolfDistance /= nearbyWolves.Count;
      // if (wolfDistance > 1)
      {
		  // Scale 0 to 1
         _moveController.speedScale = (_wolfDetector.radius - wolfDistance)/_wolfDetector.radius;
      }
   }

   private void FixedUpdate()
   {
      Graze();
   }
}
