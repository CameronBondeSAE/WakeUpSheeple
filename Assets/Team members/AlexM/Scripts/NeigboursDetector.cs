using System.Collections.Generic;
using UnityEngine;

namespace AlexM
{
	public class NeigboursDetector : MonoBehaviour
	{
		public float radius = 5f;
		public int lastAmountOfSheep;

		public List<Sheep> GetNearbyObjects()
		{
			List<Sheep> neighbours = new List<Sheep>();
			Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

			foreach (Collider c in colliders)
			{
				// Is a sheep?
				if (c.GetComponent<Sheep>())
				{
					neighbours.Add(c.GetComponent<Sheep>());
				}
			}

			lastAmountOfSheep = neighbours.Count;
			return neighbours;
		}
	}
}