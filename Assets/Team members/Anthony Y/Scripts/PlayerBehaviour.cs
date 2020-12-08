using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.Examples.Chat;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AnthonyY
{
	public class PlayerBehaviour : NetworkBehaviour, IOwnable
	{
		[SyncVar]
		public float movementSpeed;

		public Health health;

		public PlayerControls controls;
		public AudioSource    dogBark;
		public AudioSource    wolfHowl;

		[SerializeField]
		public bool amIWolf = false;
		
		public Material clay;
		
		private static readonly int Colour = Shader.PropertyToID("Color_9A1239AC");

		private void Awake()
		{
			controls = new PlayerControls();
			// amIWolf = false;
		}

		public override void OnStartClient()
		{
			base.OnStartClient();
			
		}

		public override void OnStartLocalPlayer()
		{
			base.OnStartLocalPlayer();
			
			
		}


		private void OnEnable()
		{
			controls.Dog.Enable();
			controls.Wolf.Enable();
			controls.Movement.Enable();
			health.DeathEvent                       += Death;
			controls.Dog.Bark.performed             += _ => RpcBark();
			controls.Wolf.Howl.performed            += _ => RpcHowl();
			//GetComponent<PauseManager>().PauseEvent += OnPauseEvent;
			
		}

		private void OnPauseEvent()
		{
			throw new NotImplementedException();
		}

		private void OnDisable()
		{
			controls.Dog.Disable();
			controls.Wolf.Disable();
			controls.Movement.Disable();
			health.DeathEvent -= Death;
		}

		public NetworkIdentity Owner { get; set; }

		void Update()
		{
			// Debug.Log(Owner);
			// if (isClient)
			// {
			//     if (Owner != null)
			//     {
			//         if (Owner.isLocalPlayer)
			//         {
			//             Vector3 movementInput = controls.GamePlayer.Movement.ReadValue<Vector2>();
			//             CmdMove(movementInput);
			//         }
			//     }
			// }
			Vector3 movementInput = controls.Movement.Movement.ReadValue<Vector2>();
			CmdMove(movementInput);
		}

		[ClientRpc]
		private void RpcMove(Vector2 movementInput)
		{
			Vector3 movement = new Vector3
							   {
								   x = movementInput.x,
								   z = movementInput.y
							   }.normalized;


			Rigidbody rb = GetComponent<Rigidbody>();

			// transform.Translate(movement * (movementSpeed * Time.deltaTime), Space.World);
			rb.velocity = movement * (movementSpeed * Time.deltaTime);

			// Are we moving AT ALL?
			if (rb.velocity.magnitude > 0.5f)
			{
				transform.rotation = Quaternion.LookRotation(movement);
			}


			Vector3 playerVelocity = rb.velocity;
			playerVelocity.y  = 0;
			transform.forward = new Vector3(playerVelocity.x, playerVelocity.y, playerVelocity.z);
		}

		public void RpcBark()
		{
			dogBark.Play();
			Debug.Log("Dog Audio Played");
		}


		public void RpcHowl()
		{
			wolfHowl.Play();
			Debug.Log("Wolf Audio Played");
		}

		public void TurnIntoDog()
		{
			amIWolf = false;
			if (amIWolf == false)
			{
				Debug.Log("I am now a dog");
				controls.Wolf.Disable();
				controls.Dog.Enable();
				clay.SetColor(Colour,Color.green);
			}
		}

		public void TurnIntoWolf()
		{
			amIWolf = true;
			if (amIWolf)
			{
				Debug.Log("I am now a wolf");
				controls.Wolf.Enable();
				controls.Dog.Enable();
				clay.SetColor(Colour,Color.cyan);
			}
		}

		private void Death(Health health)
		{
			Destroy(gameObject);
		}

		//Actually moving the player on server
		//***************************************SERVER CODE****************************
		[Command]
		private void CmdMove(Vector2 movementInput)
		{
			RpcMove(movementInput);
		}
	}
}