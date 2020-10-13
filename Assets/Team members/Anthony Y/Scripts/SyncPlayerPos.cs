using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class SyncPlayerPos : NetworkBehaviour
{
    [SyncVar]
    private Vector2 syncPos;

    [SyncVar]
    private Quaternion syncRot;

    [SerializeField]
    private Transform player;

    private void FixedUpdate()
    {
        TransmitPosition();
        LerpPosition();
    }

    void LerpPosition()
    {
        if (!isLocalPlayer)
        {
            player.position = syncPos;
            player.rotation = syncRot;
        }
    }

    [Command]
    void CMDProvidePositionToServer(Vector3 pos, Quaternion rot)
    {
        syncPos = pos;
        syncRot = rot;
    }

    [ClientCallback]
    void TransmitPosition()
    {
        if (isLocalPlayer)
        {
            CMDProvidePositionToServer(player.position,player.rotation);
        }
    }
}
