using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.Examples.Chat;
using UnityEngine;

public class BasicNetworkManager : NetworkManager
{
    public static event Action OnClientConnected;
    public static event Action OnClientDisconnected;
    public static event Action<NetworkConnection> onServerReadiedEvent;

   
    
    
    public void SetHostName(string hostName)
    {
        networkAddress = hostName;
    }

    public override void OnStartServer()
    {
        Debug.Log("Server Started:" + networkAddress);
        base.OnStartServer();
    }
//When a client connects
    public override void OnClientConnect(NetworkConnection conn)
    { 
        Debug.Log(" Connected to server at :" + networkAddress);
        OnClientConnected?.Invoke();
        
        base.OnClientConnect(conn);
    }
//When a client disconnects
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Debug.Log("Player Disconnected from Server");
        OnClientDisconnected?.Invoke();
        base.OnClientDisconnect(conn);
    }
//When a client connets to the server.
    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        if (numPlayers >= maxConnections)
        {
            conn.Disconnect();
            return;
        }

    }
//When some clicks ready or joins the game
    public override void OnServerReady(NetworkConnection conn)
    {
        base.OnServerReady(conn);
        onServerReadiedEvent?.Invoke(conn);
    }

  
}
