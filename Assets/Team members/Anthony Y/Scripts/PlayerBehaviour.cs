using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using Mirror;
using Mirror.Examples.Chat;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEditor;
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
		public AudioSource dogBark;
		public AudioSource wolfHowl;

		[SerializeField]
		private bool amIWolf = false;

		private Vector3 movement;
		private Rigidbody rb;
		[SerializeField]
		private NetworkIdentity _owner;

		private void Awake()
		{
			controls = new PlayerControls();
		}

		private void Start()
		{
			 rb = GetComponent<Rigidbody>();
		}


		private void OnEnable()
		{
			controls.Dog.Enable();
			controls.Wolf.Enable();
			controls.Movement.Enable();
			health.DeathEvent += Death;
			controls.Dog.Bark.performed += _ => RpcBark();
			controls.Wolf.Howl.performed += _ => RpcHowl();
			// GetComponent<PauseManager>().PauseEvent += OnPauseEvent;
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

		public NetworkIdentity Owner
		{
			get => _owner;
			set => _owner = value;
		}

		void Update()
		{
			Debug.Log(Owner.isLocalPlayer);
			    if (Owner.isLocalPlayer)
				{
					Vector3 movementInput = controls.Movement.Movement.ReadValue<Vector2>();
					CmdMove(movementInput);
				}
				

				// transform.Translate(movement * (movementSpeed * Time.deltaTime), Space.World);
				rb.velocity = movement * (movementSpeed * Time.deltaTime);

				// Are we moving AT ALL?
				if (rb.velocity.magnitude > 0.5f)
				{
					transform.rotation = Quaternion.LookRotation(movement);
				}


				Vector3 playerVelocity = rb.velocity;
				playerVelocity.y = 0;
				transform.forward = new Vector3(playerVelocity.x, playerVelocity.y, playerVelocity.z);
		}

		[ClientRpc]
		private void RPCCheckNewInput(Vector2 movementInput)
		{
		 movement	= new Vector3
			{
				x = movementInput.x,
				z = movementInput.y
			}.normalized;
		 
		}

		public void RpcBark()
		{
			dogBark.Play();
			Debug.Log("Dog Audio Played");
			
		}

		public void TurnIntoDog()
		{
			amIWolf = false;
			if (amIWolf == false)
			{
				Debug.Log("I am now a dog");
			
				controls.Dog.Enable();
				controls.Wolf.Disable();
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
				
			}
			
		}


		public void RpcHowl()
		{
			wolfHowl.Play();
			Debug.Log("Wolf Audio Played");
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
			RPCCheckNewInput(movementInput);
		}
		
	}
}