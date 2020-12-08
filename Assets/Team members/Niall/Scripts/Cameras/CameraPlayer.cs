using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AnthonyY;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace Niall
{
    [RequireComponent(typeof(Camera))]
    public class CameraPlayer : MonoBehaviour
    {
        public Transform OwnPlayer;
        public float smoothSpeed;
        public Vector3 offset;

        private Vector3 velocity;

        private void Awake()
        {
            FindObjectOfType<GameManager>().playersSpawnedEvent += OnPlayersSpawnedEvent;
        }

        private void OnPlayersSpawnedEvent(PlayerBehaviour player)
        {
             if (player.isLocalPlayer)
              {
                  OwnPlayer = player.transform;
               }
            // else
            // OwnPlayer = player.transform;
        }


        private void LateUpdate()
        {
            Move();
        }

        void Move()
        {
			if (OwnPlayer == null)
			{
				return;
			}
			
            transform.position = Vector3.SmoothDamp(transform.position, OwnPlayer.transform.position + offset,
                ref velocity, smoothSpeed);
        }
    }
}