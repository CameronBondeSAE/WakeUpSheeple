using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEngine;

namespace AlexM
{
	public class AlignmentBehavior : MonoBehaviour
	{
		public NeigboursDetector NeighboursDetector;
		public float force;

		public void Update()
		{
			Vector3 alignmentMove = Vector3.zero;

			// Average all the directions
			List<Sheep> nearbyObjects = NeighboursDetector.GetNearbySheep();

			// If no neighbours, direction would be ZERO (invalid)
			if (nearbyObjects.Count <= 0)
			{
				return;
			}
			
			foreach (Sheep item in nearbyObjects)
			{
				alignmentMove += item.transform.forward;
			}
			alignmentMove /= nearbyObjects.Count;

			// For rotation you CAN get away with overrighting the forward direction ONLY if you tween towards it. Hard setting will override any other behaviours that are trying to steer your guy
			//transform.forward = Vector3.MoveTowards(transform.forward, alignmentMove, Time.deltaTime);
			
			Vector3 cross = Vector3.Cross(transform.forward, alignmentMove);
			GetComponent<Rigidbody>().AddTorque(cross * (force * Time.deltaTime));
		}
	}
}