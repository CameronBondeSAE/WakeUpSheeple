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
    public class PlayerBehaviour : NetworkBehaviour,IOwnable
    {
        [SyncVar]
        public float movementSpeed;

        public Health health;

        public PlayerControls controls;
        public AudioSource dogBark;
        public AudioSource wolfHowl;

        [SerializeField]
        private bool amIWolf = false;
    
        private void Awake()
        {
            controls = new PlayerControls();
        }
    
    
        private void OnEnable()
        {
            controls.Dog.Enable();
            controls.Wolf.Enable();
            controls.Movement.Enable();
            health.DeathEvent += Death;
            controls.Dog.Bark.performed += _  => RpcBark();
            controls.Wolf.Howl.performed += _ => RpcHowl();
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
    
    
            transform.Translate(movement * (movementSpeed * Time.deltaTime), Space.World);
            transform.rotation = Quaternion.LookRotation(movement);
            transform.forward = GetComponent<Rigidbody>().velocity;
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
