using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Zach
{


    public class ZachActionController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ZachSettings zachSettings = new ZachSettings();
            zachSettings.Zach.WASD.started += walkOnStarted;
        }

        private void walkOnStarted(InputAction.CallbackContext obj)
        {
            if(InputSystem.GetDevice<Keyboard>().wKey.wasPressedThisFrame)
            {
                
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
        
    }
}
