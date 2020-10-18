using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;

namespace AnthonyY
{
    public class PlayerSpawnSystem : NetworkBehaviour
    {
        [SerializeField]
        private GameObject playerPrefab = null;
        private static List<Transform> spawnPoints = new List<Transform>();
        private int nextIndex = 0; //to know where the next player needs to spawn

        public static void AddSpawnPoint(Transform transform)
        {
            spawnPoints.Add(transform);
            spawnPoints = spawnPoints.OrderBy(x => x.GetSiblingIndex()).ToList(); //makes sure the order of the list is fine
        }
//removes the spawnPoint when someone joins
        public static void RemoveSpawnPoint(Transform transform)
        {
            spawnPoints.Remove(transform);
        }
[ServerCallback]
        public override void OnStartServer()
        {
            base.OnStartServer();
            BasicNetworkManager.onServerReadiedEvent += SpawnPlayer;
        }
//taking in a connection
        [Server]
        public void SpawnPlayer(NetworkConnection conn)
        {
            //getting the next spawn point
            Transform spawnPoint = spawnPoints.ElementAtOrDefault(nextIndex);
            if (spawnPoint == null)
            {
                Debug.LogError($"missing spawn point for player{nextIndex}");
                return;
            }
//spawning the player in the right position and rotation
            GameObject playerInstance = Instantiate(playerPrefab, spawnPoints[nextIndex].position,
                spawnPoints[nextIndex].rotation);
            NetworkServer.Spawn(playerInstance,conn);

            nextIndex++;
        }
    }
    
}

