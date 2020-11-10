using System;
using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.RigidbodyPhysics;
using UnityEngine;

namespace LukeBaker
{
    public class SimpleStateTest : MonoBehaviour
    {
        //Useful variables
        public DelegateState currentState;

        public DelegateState idle = new DelegateState();
        public DelegateState spin = new DelegateState();
        public float force;

        //These will help point to a function
        [Serializable]
        public class DelegateState
        {
            public Action Enter;
            public Action Exit;
            public Action Update;
            public bool active;
        }

        //Change state manager
        public void ChangeState(DelegateState newState)
        {
            if (currentState != null)
            {
                currentState.active = false;
                currentState.Exit?.Invoke();
            }

            if (newState != null)
            {
                newState.active = true;
                newState.Enter?.Invoke();
                currentState = newState;
            }
        }

        public void UpdateCurrentState()
        {
            currentState?.Update?.Invoke();
        }
        //

        void Start()
        {
            //doesn't run the functions just remembers it
            idle.Enter = OnIdleEnter;
            idle.Update = OnIdleUpdate;
            idle.Exit = OnIdleExit;

            spin.Enter = OnSpinEnter;
            spin.Update = OnSpinUpdate;

            ChangeState(idle);
        }

        // Update is called once per frame
        void Update()
        {
            UpdateCurrentState();
        }

        //enter, exit and update states of the object
        private void OnSpinEnter()
        {
            Debug.Log("OnSpinEnter");
        }

        private void OnSpinUpdate()
        {
            Debug.Log("OnSpinExecute");

            transform.Rotate(0, force, 0);

            //To stop rotation and leave the spin state
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeState(idle);
            }
        }

        private void OnIdleEnter()
        {
            Debug.Log("OnIdleEnter");
            transform.Rotate(0, -force, 0);
        }

        private void OnIdleUpdate()
        {
            Debug.Log("OnIdleExecute");

            //InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame doesn't work??
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeState(spin);
            }
        }

        private void OnIdleExit()
        {
            Debug.Log("OnIdleExit");
        }

    }
}