﻿using System;
using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    void Awake()
    {
        PlayerSpawnSystem.AddSpawnPoint(transform);
    }

    private void OnDestroy()
    {
        PlayerSpawnSystem.RemoveSpawnPoint(transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position,1f);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position,transform.position+ transform.forward * 2);
    }
}
