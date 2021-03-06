﻿using System;
using System.Collections.Generic;
using System.Linq;
using AnthonyY;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Student_workspace.Dylan.Scripts.NetworkLobby
{
    // Spawn player non-physical representation
    // Change scene to main
    // 

    public class GameNetworkManager : NetworkManager
    {
        [SerializeField]
        private int minPlayer = 2;

        [Scene]
        [SerializeField]
        private string menuScene = string.Empty;

        [Scene]
        [SerializeField]
        private string gameScene = string.Empty;

        //[Header("Room")] [SerializeField] private NetworkLobbyPlayer lobbyPlayerPrefab = null;
        [Header("Game")]
        [SerializeField]
        private NetworkGamePlayer lobbyPlayerPrefab = null;

        public GameObject physicalPlayerPrefab;

        public bool allowHotJoining;

        [SerializeField]
        private GameObject playerSpawnSystem;

        public static event Action OnClientConnected;
        public static event Action OnClientDisconnected;

        //[SyncEvent]
        public static event Action OnGameStart;

        public static event Action<NetworkConnection> OnServerReadied;

		public event Action<NetworkIdentity> PhysicalPlayerSpawned;
		
		
        public List<NetworkLobbyPlayer> RoomPlayers { get; } = new List<NetworkLobbyPlayer>();
        public List<NetworkGamePlayer> GamePlayers { get; } = new List<NetworkGamePlayer>();

        [Tooltip("Not floating network dude")]
        public List<PlayerBehaviour> physicalPlayers = new List<PlayerBehaviour>();

        [Header("Lobby")]
        public GameObject lobbyUI;

        public GameObject nameInputUI;
        public GameObject mainMenu;

        public bool useSameScene;

        [Scene]
        [SerializeField]
        public List<string> levels;

        public GameManager gameManager;

        private int pickAWolfIndex;

		public PlayerBehaviour localPlayer;

        public override void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
            base.Awake();
        }

        public override void Start()
        {
            // Debug.Log("Level Loaded");
            // TODO move to UI ViewModel
            NetworkGamePlayer.OnInstantiated += UIOff;
            LevelLoader.LoadLevelEvent += LoadLevel;
            // For debugging, use the same scene that you're testing easily
            if (useSameScene)
            {
                if (string.IsNullOrEmpty(gameScene))
                {
                    gameScene = SceneManager.GetActiveScene().path;
                }

                if (string.IsNullOrEmpty(menuScene))
                {
                    menuScene = SceneManager.GetActiveScene().path;
                    onlineScene = menuScene;
                }
            }

            // TODO Move to UI ViewModel
            if (SceneManager.GetActiveScene().path == menuScene)
            {
                lobbyUI.SetActive(true);
            }
            else
            {
                // this never runs even when i am not ignoring or skipping the menus. this just never runs ever.
                // It will run if same scene isn't active.  but if samescene is active, this will never run. but if you add that bool to the if statement, This will run instantly at start.
                // and then the menu will never show. same scene is not the same as skip lobby ui.

                //run this on an event, invoke the event
                UIOff();
            }


            // Need to subscribe before network starts
            base.Start();
        }
		
		public void LoadLevel(string levelToLoadName, bool loadNextLevel)
        {
            //possible issues might come up with gamescene not being this new scene
            //if so just assign game scene to this new scene when we load it here
            if (loadNextLevel)
            {
                if (NextLevel() != null)
                {
                    ServerChangeScene(NextLevel());
                }
            }
            else
            {
                
                ServerChangeScene(levelToLoadName);

            }

            nextIndex = 0;
            LevelLoader.LoadLevelEvent -= LoadLevel;
            //should be done in start method if not can be uncommented
            LevelLoader.LoadLevelEvent += LoadLevel;
        }

        public string NextLevel()
        {
            string currentLevel = SceneManager.GetActiveScene().path;
            int currentlevelIndex = levels.IndexOf(currentLevel);

            return (currentlevelIndex < levels.Count) ? levels[currentlevelIndex + 1] : null;
        }

        void UIOff(NetworkGamePlayer ngp)
        {
            lobbyUI.SetActive(false);
        }

        void UIOff()
        {
            lobbyUI.SetActive(false);
        }

    

        /// <summary>
        ///when using prefabs to spawn objects you need to load them in when you start or connect to the server
        /// </summary>
        // public override void OnStartServer() =>
        //     spawnPrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs").ToList();
        //
        // /// <summary>
        // ///when using prefabs to spawn objects you need to load them in when you start or connect to the server
        // /// </summary>
        // public override void OnStartClient()
        // {
        //     var spawnablePrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs");
        //
        //     foreach (var prefab in spawnablePrefabs)
        //     {
        //         ClientScene.RegisterPrefab(prefab);
        //     }
        // }
        public override void OnClientConnect(NetworkConnection conn)
        {
            base.OnClientConnect(conn);
            OnClientConnected?.Invoke();
        }

        public override void OnStopClient()
        {
            RoomPlayers.Clear();
            GamePlayers.Clear();
            physicalPlayers.Clear();
            StopConnection();
            base.OnStopClient();
        }

        public override void OnClientDisconnect(NetworkConnection conn)
        {
            base.OnClientDisconnect(conn);
            OnClientDisconnected?.Invoke();
        }

        public override void OnServerConnect(NetworkConnection conn)
        {
            base.OnServerConnect(conn);
            if (numPlayers >= maxConnections)
            {
                conn.Disconnect();
                return;
            }

            // TODO comment WHY. Maybe changescene on client if wrong
            //this does stop joining in progress will need to change depending on game requirement
            if (SceneManager.GetActiveScene().path != menuScene || !allowHotJoining)
            {
                conn.Disconnect();
                return;
            }
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            if (SceneManager.GetActiveScene().path == menuScene)
            {
                bool isLeader = RoomPlayers.Count == 0;

                NetworkLobbyPlayer lobbyPlayerInstance =
                    Instantiate(lobbyPlayerPrefab).GetComponent<NetworkLobbyPlayer>();

                lobbyPlayerInstance.IsLeader = isLeader;

                NetworkServer.AddPlayerForConnection(conn, lobbyPlayerInstance.gameObject);
                lobbyPlayerInstance.GetComponent<BChatNetworkHandler>().enabled = true;
            }
        }


        public override void OnServerDisconnect(NetworkConnection conn)
        {
            if (conn.identity != null)
            {
                var player = conn.identity.GetComponent<NetworkLobbyPlayer>();

                RoomPlayers.Remove(player);

                NotifyPlayersOfReadyState();
            }

            base.OnServerDisconnect(conn);
        }

        public override void OnStopServer()
        {
            RoomPlayers.Clear();
            GamePlayers.Clear();
            physicalPlayers.Clear();
            StopConnection();
            base.OnStopServer();
        }


        public void StopConnection()
        {
            lobbyUI.SetActive(true);
            mainMenu.SetActive(true);
            nameInputUI.SetActive(false);
            nextIndex = 0;
        }


        public void NotifyPlayersOfReadyState()
        {
            foreach (var player in RoomPlayers)
            {
                player.HandleReadyToStart(IsReadyToStart());
            }
        }

        private bool IsReadyToStart()
        {
            if (numPlayers < minPlayer)
            {
                return false;
            }

            foreach (var player in RoomPlayers)
            {
                if (!player.IsReady)
                {
                    return false;
                }
            }


            return true;
        }


        public void StartGame()
        {
            if (SceneManager.GetActiveScene().path == menuScene)
            {
                if (!IsReadyToStart())
                {
                    return;
                }

                ServerChangeScene(gameScene);
                // Spawn physical player
            }
        }


        public override void ServerChangeScene(string newSceneName)
        {
            // TODO comment
            if (SceneManager.GetActiveScene().path == menuScene && newSceneName.StartsWith(gameScene))
            {
                for (int i = RoomPlayers.Count - 1; i >= 0; i--)
                {
                    var conn = RoomPlayers[i].connectionToClient;
                    // TODO comment, real guy?
                    var gameplayerInstance = RoomPlayers[i].GetComponent<NetworkGamePlayer>();
                    gameplayerInstance.SetPlayerInfo(RoomPlayers[i].DisplayName, RoomPlayers[i].PlayerColor);

                    //NetworkServer.Destroy(conn.identity.gameObject);

                    // NetworkServer.ReplacePlayerForConnection(conn, gameplayerInstance.gameObject, true);
                }
            }

            //Changing scenes is deleting the physical player that gets spawned on start game..
            // and it also deletes them even if they're spawned in OnServerChangeScene
            base.ServerChangeScene(newSceneName);
        }

        public void RestartLevel()
        {
            ServerChangeScene(SceneManager.GetActiveScene().name);
            physicalPlayers.Clear();
            nextIndex = 0;
        }


        public override void OnServerChangeScene(string sceneName)
        {
            physicalPlayers.Clear();
        }


        // The physical players need to be spawned here, so that they don't get removed on scene change. Because OnServerChangeScene and StartGame are called before changing scenes.
        public override void OnServerSceneChanged(string sceneName)
        {
            foreach (NetworkGamePlayer gamePlayer in GamePlayers)
            {
                SpawnPlayer(gamePlayer.connectionToClient, gamePlayer.netIdentity);
            }
            
            OnGameStart?.Invoke();
            OnStartPickWolf();
           

            base.OnServerSceneChanged(sceneName);
        }

        public void OnStartPickWolf()
        {
            pickAWolfIndex = Random.Range(0, physicalPlayers.Count);
            
            for (int i = 0; i < physicalPlayers.Count; i++)
            {
                if (i == pickAWolfIndex)
                {
                    physicalPlayers[pickAWolfIndex].GetComponent<PlayerBehaviour>().RpcTurnIntoWolf();
                }
                else
                {
                    physicalPlayers[pickAWolfIndex].GetComponent<PlayerBehaviour>().RpcTurnIntoDog();
                }
            }
        }

        public override void OnClientSceneChanged(NetworkConnection conn)
        {
            OnGameStart?.Invoke();

            base.OnClientSceneChanged(conn);
        }


        /// <summary>
        /// Spawn physical player at Spawn point
        /// </summary>
        private static List<Transform> spawnPoints = new List<Transform>();

        private int nextIndex = 0;

        [SerializeField]
        private float heightOffset;

        public void SpawnPlayer(NetworkConnection conn, NetworkIdentity gamePlayer)
        {
            Transform spawnPoint = spawnPoints.ElementAtOrDefault(nextIndex);

            if (spawnPoint == null)
            {
                Debug.LogError($"Missing spawn point for player {nextIndex}");
                return;
            }

            Vector3 spawnOffset = new Vector3(spawnPoints[nextIndex].position.x,
                spawnPoints[nextIndex].position.y + heightOffset, spawnPoints[nextIndex].position.z);

            GameObject playerInstance = Instantiate(physicalPlayerPrefab, spawnOffset, spawnPoints[nextIndex].rotation);
            
           float maxHeight = 0, minHeight = 0;

            foreach (Collider c in playerInstance.GetComponentsInChildren<Collider>())
            {
                if (c.bounds.max.y > maxHeight)
                {
                    maxHeight = c.bounds.max.y;
                }

                if (c.bounds.min.y < minHeight)
                {
                    minHeight = c.bounds.min.y;
                }
            }

            float totalHeight = maxHeight - minHeight;



			playerInstance.GetComponent<PlayerBehaviour>().Owner = gamePlayer;
			
			
			
			// replace room player with game player
			NetworkServer.ReplacePlayerForConnection(conn, playerInstance, true);

            // NetworkServer.Spawn(playerInstance, conn);
            // gameManager.PlayersSpawned();


            physicalPlayers.Add(playerInstance.GetComponent<PlayerBehaviour>());
            
			
			// Keep track of local player for convenience
			if (playerInstance.GetComponent<NetworkIdentity>().isLocalPlayer)
			{
				localPlayer = playerInstance.GetComponent<PlayerBehaviour>();
			}
            
            nextIndex++;

            if (nextIndex >= spawnPoints.Count)
            {
                nextIndex = 0;
            }
            
			PhysicalPlayerSpawned?.Invoke(playerInstance.GetComponent<NetworkIdentity>());
           
            
        }	

        public static void AddSpawnPoint(Transform transform)
        {
            spawnPoints.Add(transform);
            spawnPoints = spawnPoints.OrderBy(x => x.GetSiblingIndex()).ToList();
        }

        public static void RemoveSpawnPoint(Transform transform)
        {
            spawnPoints.Remove(transform);
        }
    }
}