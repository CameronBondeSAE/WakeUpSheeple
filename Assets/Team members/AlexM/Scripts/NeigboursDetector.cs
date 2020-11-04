using System.Collections.Generic;
using UnityEngine;

namespace AlexM
{
	public class NeigboursDetector : MonoBehaviour
	{
		private float neighborRadius;

		List<Transform> GetNearbyObjects(FlockAgent agent)
		{
			List<Transform> context = new List<Transform>();
			Collider[] contextCOlliders = Physics.OverlapSphere(agent.transform.position, neighborRadius);
			foreach (Collider c in contextCOlliders)
			{
				//THIS IS THE LINE TO CHANGE. CHECK FOR SHEEP HERE.
				if (c != agent.AgentCollider)
				{
					context.Add(c.transform);
				}
			}

			return context;
		}
	}
}