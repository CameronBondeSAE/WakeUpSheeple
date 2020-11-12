using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Cam
{
	public class Test :MonoBehaviour
	{
		void Start()
		{
			// Spawn the actionmap
			CamsControls camsControls = new CamsControls();

			// Enable the specific group of actions (you can turn them on and off at will)
			camsControls.InGame.Enable();
			camsControls.InMenu.Enable();
			
			// Subscribe to custom made events/actions
			camsControls.InGame.Bark.started   += BarkOnstarted;
			camsControls.InMenu.Select.started += SelectOnstarted;
		}

		void SelectOnstarted(InputAction.CallbackContext obj)
		{
			Debug.Log("menu select");
		}

		void BarkOnstarted(InputAction.CallbackContext obj)
		{
			Debug.Log("Bark started");
			// Debug.Log(obj.);
		}

		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		void BarkOncanceled(InputAction.CallbackContext obj)
		{
			Debug.Log("Bark canceled");
		}

		void BarkOnperformed(InputAction.CallbackContext obj)
		{
			Debug.Log("Bark performed");
		}

		void Update()
		{
			// Old system
			// Polling only
			Input.GetKeyDown(KeyCode.Space);
			Input.GetAxis("Horizontal");
			if (Input.GetButton("Fire1"))
			{
				
			}
			

			if (InputSystem.GetDevice<Keyboard>().spaceKey.isPressed)
			{
				// This is the same the old "Input.GetKey" and "Input.GetButton" with NO "Down"
			}
			if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
			{
				// This is the same the old "Input.GetKeyDown" and "Input.GetButtonDown"
			}

			// You have to choose the device, eg getting the mouse. Try other devices.
			if (InputSystem.GetDevice<Mouse>().leftButton.wasPressedThisFrame)
			{
				
			}
		}
	}
}