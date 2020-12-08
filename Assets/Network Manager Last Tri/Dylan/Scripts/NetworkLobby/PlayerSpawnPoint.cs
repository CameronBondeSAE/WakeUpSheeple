using System;
using UnityEngine;

namespace Student_workspace.Dylan.Scripts.NetworkLobby
{
    public class PlayerSpawnPoint : MonoBehaviour
    {
		public float startRayHeightOffset = 100f;
		public float floorOffset          = 1f;
		public Vector3 finalSpawnPoint;
		
		private void Awake()
        {
            GameNetworkManager.AddSpawnPoint(transform);
			
			FindGroundSurfaceLevel();
		}

		public void FindGroundSurfaceLevel()
		{
			Ray        ray = new Ray(transform.position + new Vector3(0, startRayHeightOffset, 0), Vector3.down);
			RaycastHit hitInfo;
			
			if (Physics.Raycast(ray, out hitInfo))
			{
				finalSpawnPoint = hitInfo.point + new Vector3(0, floorOffset, 0);
			}
		}

        private void OnDestroy()
        {
			GameNetworkManager.RemoveSpawnPoint(transform);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 1f);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2f);
        }
    }
}
