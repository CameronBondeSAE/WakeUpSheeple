using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Mirror;
using UnityEngine;

namespace AnthonyY
{
    public class PlayerRotate : NetworkBehaviour
    {
        [SyncVar]
        public float rotateForce = 2f;

        [SyncVar]public float direction = 50;
        
        
        public Rigidbody rb;

        private PlayerControls controls;
    
        private void OnEnable()
        {
            controls.GamePlayer.Enable();
        }
    
        private void OnDisable()
        {
            controls.GamePlayer.Disable();   
        }

        void Update()
        { 
           Debug.Log(isLocalPlayer);
           
            // rb.AddTorque(0,rotateForce,0);
            if (isLocalPlayer)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    CmdRotate();
                }
                
            }
            
        }
        [ClientRpc]
        private void RPCRotate()
        {
           transform.Rotate(Vector3.up,rotateForce * Time.deltaTime);
        } 
        
        //******************SERVER CODE********************************
        [Command]
        public void CmdRotate()
        {
            RPCRotate();

        }
       
    }

}
