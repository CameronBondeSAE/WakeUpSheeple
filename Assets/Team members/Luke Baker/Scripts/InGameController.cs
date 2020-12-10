using UnityEngine;
using UnityEngine.InputSystem;

namespace LukeBaker
{
    public class InGameController : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
            //spawning the action map
            LukesController lukesController = new LukesController();
        
            //enable the group of actions in the action map section
            lukesController.InGame.Enable();
            
            //Subscribe to event
            lukesController.InGame.Stoppinganimation.started += PingStop;
            lukesController.InGame.Launchcube.started += LaunchCube;

        }

        void PingStop(InputAction.CallbackContext obj)
        {
            if (InputSystem.GetDevice<Keyboard>().pKey.wasPressedThisFrame)
            {
                FindObjectOfType<FiveG>().fiveGPing.SetActive(false);
            }
        }

        void LaunchCube(InputAction.CallbackContext obj)
        {
            if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<Rigidbody>();
                cube.transform.position = FindObjectOfType<Launcher>().gameObject.transform.position;
            }
        }
    }
}
