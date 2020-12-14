using System;
using Mirror;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;

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

		private static readonly int     Colour = Shader.PropertyToID("Color_9A1239AC");
		public                  Vector3 movement;
		public                  Vector3 movementInput;

		// HACK
		public GameObject cameraPrefab;

		private void Awake()
		{
			// amIWolf = false;
		}

		public override void OnStartClient()
		{
			base.OnStartClient();
		}

		public override void OnStartLocalPlayer()
		{
			base.OnStartLocalPlayer();
			controls = new PlayerControls();
			controls.Dog.Enable();
			controls.Wolf.Enable();
			controls.Movement.Enable();
			health.DeathEvent            += Death;
			controls.Dog.Bark.performed  += _ => RpcBark();
			controls.Wolf.Howl.performed += _ => RpcHowl();

			// HACK
			// Destroy all existing cameras
			// HACK: There could be a time where you want other cameras in the scene, so this is too brute force
			foreach (Camera cam in FindObjectsOfType<Camera>())
			{
				Destroy(cam.gameObject);
			}
			GameObject instantiate = Instantiate(cameraPrefab);
			instantiate.GetComponent<Niall.CameraPlayer>().OwnPlayer = transform;
			
			
			
			// if (networkIdentity.isLocalPlayer)
			// {

			// cameraFollow.GetComponent<CameraPlayer>().target = networkIdentity.transform;
			// }
		}


		private void OnEnable()
		{
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
			// Debug.Log(Owner.GetComponent<NetworkGamePlayer>().playerColor + ": "+Owner.GetComponent<NetworkGamePlayer>().displayName);
			
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
			if (isLocalPlayer)
			{
				if (controls != null) movementInput = controls.Movement.Movement.ReadValue<Vector2>();
				CmdMove(movementInput);
			}


			// Move the dog
			Rigidbody rb = GetComponent<Rigidbody>();

			// transform.Translate(movement * (movementSpeed * Time.deltaTime), Space.World);
			rb.AddForce(movement * (movementSpeed * Time.deltaTime), ForceMode.VelocityChange);

			
			Vector3 playerVelocity = rb.velocity;
			playerVelocity.y = 0;

			// Are we moving AT ALL?
			if (playerVelocity.magnitude > 2.5f)
			{
				// transform.rotation = Quaternion.LookRotation(movement);
				transform.forward = new Vector3(playerVelocity.x, playerVelocity.y, playerVelocity.z);
			}


		}

		[ClientRpc]
		private void RpcMove(Vector2 movementInput)
		{
			movement = new Vector3
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
				if (controls != null)
				{
					controls.Wolf.Disable();
					controls.Dog.Enable();
				}

				clay.SetColor(Colour, Color.green);
			}
		}

		public void TurnIntoWolf()
		{
			amIWolf = true;
			if (amIWolf)
			{
				Debug.Log("I am now a wolf");
				if (controls != null)
				{
					controls.Wolf.Enable();
					controls.Dog.Enable();
				}

				clay.SetColor(Colour, Color.cyan);
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
			// Debug.Log("movementInput = " + movementInput);
			RpcMove(movementInput);
		}
	}
}