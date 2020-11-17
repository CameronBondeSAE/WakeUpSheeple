using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AnthonyY;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraPlayer : MonoBehaviour
{
    public Transform target;
    public Camera cam;
    public float smoothSpeed;
    public Vector3 offset;
    
    private Vector3 velocity;

    private void Awake()
    {
        FindObjectOfType<GameManager>().playersSpawnedEvent += OnPlayersSpawnedEvent;
        cam = GetComponent<Camera>();
    }

    private void OnPlayersSpawnedEvent(PlayerBehaviour player)
    {
       // if (player.isLocalPlayer)
      //  {
     //      target = player.transform;
     //   }
        
       target = player.transform;
        
    }

    private void LateUpdate()
    {
        
        
        
        if (target != null)
        {
            
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position + offset,
                ref velocity, smoothSpeed);
            
        }
    }
}
