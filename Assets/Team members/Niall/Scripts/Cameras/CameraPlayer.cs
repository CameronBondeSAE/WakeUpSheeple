using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AnthonyY;
using Cinemachine;
using DG.Tweening;
using Mirror;
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
		GameManager     gameManager;

        private void OnEnable()
		{
			// gameManager                     =  FindObjectOfType<GameManager>();
			// if (gameManager)
			// {
				// gameManager.playersSpawnedEvent += OnPlayersSpawnedEvent;
			// }
		}

		void OnDisable()
		{
			// if (gameManager)
			// {
				// gameManager.playersSpawnedEvent -= OnPlayersSpawnedEvent;
			// }
		}

		private void OnPlayersSpawnedEvent(NetworkIdentity player)
        {
            if (player.isClient)
            {
                OwnPlayer = player.transform;
            }

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