using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.Examples.Chat;
using UnityEngine;

public class BasicNetworkManager : NetworkManager
{
    public void SetHostName(string hostName)
    {
        networkAddress = hostName;
    }

    public override void OnStartServer()
    {
        Debug.Log("Server Started:" + networkAddress);
        base.OnStartServer();
    }

    public override void OnClientConnect(NetworkConnection conn)
    { 
        Debug.Log(" Connected to server at :" + networkAddress);
        
        base.OnClientConnect(conn);
    }
    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        if (numPlayers >= maxConnections)
        {
            conn.Disconnect();
            return;
        }

    }
}
