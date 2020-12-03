// GENERATED AUTOMATICALLY FROM 'Assets/Team members/Anthony Y/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Dog"",
            ""id"": ""ba2e97a6-76d9-4ac8-91c9-288286dd9483"",
            ""actions"": [
                {
                    ""name"": ""Bark"",
                    ""type"": ""Button"",
                    ""id"": ""9caae968-c468-4f6d-a693-e56d4fe1c74e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToWolf"",
                    ""type"": ""Button"",
                    ""id"": ""636e170a-10e5-4538-a8cb-a9c31f01416c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""068df5a8-0546-4778-84b3-00a0692fd9dc"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Bark"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""921a6146-3661-4644-aed1-4a129ee411be"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToWolf"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Wolf"",
            ""id"": ""62e53835-136a-4afd-b782-d3019ed1728b"",
            ""actions"": [
                {
                    ""name"": ""Howl"",
                    ""type"": ""Button"",
                    ""id"": ""2d6ff240-dded-4f06-9903-10d9b76aaf61"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToDog"",
                    ""type"": ""Button"",
                    ""id"": ""7b3f949b-f3cc-43b4-bf27-4817dde20f54"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fed1bf11-6b56-4603-93d7-31071057ede2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Howl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58870b02-9ac0-43d3-8491-d88b725038e9"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToDog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Movement"",
            ""id"": ""14671110-03d1-42fa-b833-3310640caf7e"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""35776884-72dc-4023-9a8c-832ff251fc17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""b936e204-678d-4ed6-8904-70f5fd4dbdc5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""698e8fe3-68b7-4c49-85d6-87bf7ce81ae9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""429474d4-7874-42e8-bea1-1da384bf49ef"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""65d2ea6d-4419-4645-a2b8-b7fc11867fb4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ae84c183-53f6-435b-bf08-ed5f10053a18"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Dog
        m_Dog = asset.FindActionMap("Dog", throwIfNotFound: true);
        m_Dog_Bark = m_Dog.FindAction("Bark", throwIfNotFound: true);
        m_Dog_ToWolf = m_Dog.FindAction("ToWolf", throwIfNotFound: true);
        // Wolf
        m_Wolf = asset.FindActionMap("Wolf", throwIfNotFound: true);
        m_Wolf_Howl = m_Wolf.FindAction("Howl", throwIfNotFound: true);
        m_Wolf_ToDog = m_Wolf.FindAction("ToDog", throwIfNotFound: true);
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Movement = m_Movement.FindAction("Movement", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Dog
    private readonly InputActionMap m_Dog;
    private IDogActions m_DogActionsCallbackInterface;
    private readonly InputAction m_Dog_Bark;
    private readonly InputAction m_Dog_ToWolf;
    public struct DogActions
    {
        private @PlayerControls m_Wrapper;
        public DogActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Bark => m_Wrapper.m_Dog_Bark;
        public InputAction @ToWolf => m_Wrapper.m_Dog_ToWolf;
        public InputActionMap Get() { return m_Wrapper.m_Dog; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DogActions set) { return set.Get(); }
        public void SetCallbacks(IDogActions instance)
        {
            if (m_Wrapper.m_DogActionsCallbackInterface != null)
            {
                @Bark.started -= m_Wrapper.m_DogActionsCallbackInterface.OnBark;
                @Bark.performed -= m_Wrapper.m_DogActionsCallbackInterface.OnBark;
                @Bark.canceled -= m_Wrapper.m_DogActionsCallbackInterface.OnBark;
                @ToWolf.started -= m_Wrapper.m_DogActionsCallbackInterface.OnToWolf;
                @ToWolf.performed -= m_Wrapper.m_DogActionsCallbackInterface.OnToWolf;
                @ToWolf.canceled -= m_Wrapper.m_DogActionsCallbackInterface.OnToWolf;
            }
            m_Wrapper.m_DogActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Bark.started += instance.OnBark;
                @Bark.performed += instance.OnBark;
                @Bark.canceled += instance.OnBark;
                @ToWolf.started += instance.OnToWolf;
                @ToWolf.performed += instance.OnToWolf;
                @ToWolf.canceled += instance.OnToWolf;
            }
        }
    }
    public DogActions @Dog => new DogActions(this);

    // Wolf
    private readonly InputActionMap m_Wolf;
    private IWolfActions m_WolfActionsCallbackInterface;
    private readonly InputAction m_Wolf_Howl;
    private readonly InputAction m_Wolf_ToDog;
    public struct WolfActions
    {
        private @PlayerControls m_Wrapper;
        public WolfActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Howl => m_Wrapper.m_Wolf_Howl;
        public InputAction @ToDog => m_Wrapper.m_Wolf_ToDog;
        public InputActionMap Get() { return m_Wrapper.m_Wolf; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WolfActions set) { return set.Get(); }
        public void SetCallbacks(IWolfActions instance)
        {
            if (m_Wrapper.m_WolfActionsCallbackInterface != null)
            {
                @Howl.started -= m_Wrapper.m_WolfActionsCallbackInterface.OnHowl;
                @Howl.performed -= m_Wrapper.m_WolfActionsCallbackInterface.OnHowl;
                @Howl.canceled -= m_Wrapper.m_WolfActionsCallbackInterface.OnHowl;
                @ToDog.started -= m_Wrapper.m_WolfActionsCallbackInterface.OnToDog;
                @ToDog.performed -= m_Wrapper.m_WolfActionsCallbackInterface.OnToDog;
                @ToDog.canceled -= m_Wrapper.m_WolfActionsCallbackInterface.OnToDog;
            }
            m_Wrapper.m_WolfActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Howl.started += instance.OnHowl;
                @Howl.performed += instance.OnHowl;
                @Howl.canceled += instance.OnHowl;
                @ToDog.started += instance.OnToDog;
                @ToDog.performed += instance.OnToDog;
                @ToDog.canceled += instance.OnToDog;
            }
        }
    }
    public WolfActions @Wolf => new WolfActions(this);

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Movement;
    public struct MovementActions
    {
        private @PlayerControls m_Wrapper;
        public MovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Movement_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IDogActions
    {
        void OnBark(InputAction.CallbackContext context);
        void OnToWolf(InputAction.CallbackContext context);
    }
    public interface IWolfActions
    {
        void OnHowl(InputAction.CallbackContext context);
        void OnToDog(InputAction.CallbackContext context);
    }
    public interface IMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
}
