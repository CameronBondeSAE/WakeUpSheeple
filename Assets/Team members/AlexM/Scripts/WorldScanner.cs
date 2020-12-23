using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexM
{

	/// <summary>
	/// What do i need?
	/// Start.
	/// End.
	/// </summary>
	public class Node
	{
		public bool isBlocked;
		public bool isGoal;
		public bool visited;
		public Vector3 myPos;
		public GameObject cube;
	}
	
	public class WorldScanner : MonoBehaviour
	{

		public Node[,]   Nodes;
		public GameObject CubeForGrid;
		public int       xNum = 50;
		public int       zNum = 50;
		public LayerMask layerMask;
		public LayerMask goalMask;
		public float sizeX = 0.8f;
		public float sizeY = 0.8f;
		public float sizeZ = 0.8f;

		private void Start()
		{
			ScanWorld();
			InstantianteGrid();
		}

		public void ScanWorld()
		{
			// Create the actual array
			Nodes = new Node[xNum,zNum];
		
			for (int x = 0; x < xNum; x++)
			{
				for (int z = 0; z < zNum; z++)
				{
					Nodes[x,z] = new Node();
				
					if (Physics.CheckBox(transform.position + new Vector3(x, 0, z), new Vector3(sizeX, sizeY, sizeZ), Quaternion.identity, layerMask.value))
					{
						Nodes[x, z].isBlocked = true;
					}
					
					if (Physics.CheckBox(transform.position + new Vector3(x, 0, z), new Vector3(sizeX, sizeY, sizeZ), Quaternion.identity, goalMask.value))
					{
						Nodes[x, z].isGoal = true;
					}
				}
			}
		}

		void InstantianteGrid()
		{
			Vector3 transformPosition = transform.position;
			Vector3 size              = new Vector3(1f, 1f, 1f);
			
			for (int x = 0; x < xNum; x++)
			{
				for (int z = 0; z < zNum; z++)
				{
					if (Nodes != null && !Nodes[x,z].isBlocked)
					{
						GameObject cube = Instantiate(CubeForGrid, transformPosition + new Vector3(x, 0, z),Quaternion.identity);
						Nodes[x, z].cube = cube;
						Nodes[x, z].cube.transform.parent = gameObject.transform;
						Nodes[x, z].cube.transform.name = " [" +  Nodes[x, z].cube.transform.position.ToString() + "] ";
						//cube.transform.parent = gameObject.transform;
						//cube.transform.name = " [" + transform.position.ToString() + "] ";
						//Nodes[x, z].myPos = transformPosition + new Vector3(x, 0, z);
					}
				}
			}
		}
		
		// void OnDrawGizmos()
		// {
		// 	
		// 	Vector3 transformPosition = transform.position;
		// 	Vector3 size              = new Vector3(0.8f, 0.8f, 0.8f);
		//
		// 	
		// 	for (int x = 0; x < xNum; x++)
		// 	{
		// 		for (int z = 0; z < zNum; z++)
		// 		{
		// 			if (Nodes != null && !Nodes[x,z].isBlocked)
		// 			{
		// 				Gizmos.color = Color.green;
		// 				Gizmos.DrawCube(transformPosition + new Vector3(x, 0, z), size);
		// 				Nodes[x, z].myPos = transformPosition + new Vector3(x, 0, z);
		// 			}
		// 			
		// 			if (Nodes != null && Nodes[x,z].isBlocked)
		// 			{
		// 				Gizmos.color = Color.red;
		// 				Gizmos.DrawCube(transformPosition + new Vector3(x, 0, z), size);
		// 				Nodes[x, z].myPos = transformPosition + new Vector3(x, 0, z);
		// 			}
		//
		// 			if (Nodes != null && Nodes[x,z].isGoal)
		// 			{
		// 				Gizmos.color = Color.yellow;
		// 				Gizmos.DrawCube(transformPosition + new Vector3(x, 0, z), size);
		// 				Nodes[x, z].myPos = transformPosition + new Vector3(x, 0, z);
		// 			}
		// 		}
		// 	}
		// }
	}
}