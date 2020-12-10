using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AnthonyY;
using DG.Tweening;
using Mirror;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraPlayer : MonoBehaviour
{
    public Transform target;
    public Camera cam;
    public float smoothSpeed;
    public Vector3 offset;
    
    private Vector3 velocity;
	
    private void OnEnable()
    {
        FindObjectOfType<GameManager>().playersSpawnedEvent += OnPlayersSpawnedEvent;
        cam = GetComponent<Camera>();
    }

	void OnDisable()
	{
		FindObjectOfType<GameManager>().playersSpawnedEvent -= OnPlayersSpawnedEvent;
	}

	private void OnPlayersSpawnedEvent(NetworkIdentity playerNetworkIdentity)
    {
       // if (player.isLocalPlayer)
      //  {
     //      target = player.transform;
     //   }
        
       target = playerNetworkIdentity.transform;
        
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
