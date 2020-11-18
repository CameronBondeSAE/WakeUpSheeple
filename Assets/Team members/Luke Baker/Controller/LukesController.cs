// GENERATED AUTOMATICALLY FROM 'Assets/Team members/Luke Baker/Controller/LukesController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @LukesController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @LukesController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""LukesController"",
    ""maps"": [
        {
            ""name"": ""In Game"",
            ""id"": ""4b187fe7-b827-4efb-960a-d591435028ab"",
            ""actions"": [
                {
                    ""name"": ""Stop ping animation"",
                    ""type"": ""Button"",
                    ""id"": ""bd433183-622f-450b-874b-fcda54d0e419"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Launch cube"",
                    ""type"": ""Button"",
                    ""id"": ""6e2d314f-e73a-440c-a8cf-c7fa11e0624e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e6a6fa9a-bd80-48db-ae78-0733022dcbbf"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stop ping animation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca4a0568-5ce4-425e-a362-56cb04cae026"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Launch cube"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // In Game
        m_InGame = asset.FindActionMap("In Game", throwIfNotFound: true);
        m_InGame_Stoppinganimation = m_InGame.FindAction("Stop ping animation", throwIfNotFound: true);
        m_InGame_Launchcube = m_InGame.FindAction("Launch cube", throwIfNotFound: true);
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

    // In Game
    private readonly InputActionMap m_InGame;
    private IInGameActions m_InGameActionsCallbackInterface;
    private readonly InputAction m_InGame_Stoppinganimation;
    private readonly InputAction m_InGame_Launchcube;
    public struct InGameActions
    {
        private @LukesController m_Wrapper;
        public InGameActions(@LukesController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Stoppinganimation => m_Wrapper.m_InGame_Stoppinganimation;
        public InputAction @Launchcube => m_Wrapper.m_InGame_Launchcube;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void SetCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterface != null)
            {
                @Stoppinganimation.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnStoppinganimation;
                @Stoppinganimation.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnStoppinganimation;
                @Stoppinganimation.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnStoppinganimation;
                @Launchcube.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnLaunchcube;
                @Launchcube.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnLaunchcube;
                @Launchcube.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnLaunchcube;
            }
            m_Wrapper.m_InGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Stoppinganimation.started += instance.OnStoppinganimation;
                @Stoppinganimation.performed += instance.OnStoppinganimation;
                @Stoppinganimation.canceled += instance.OnStoppinganimation;
                @Launchcube.started += instance.OnLaunchcube;
                @Launchcube.performed += instance.OnLaunchcube;
                @Launchcube.canceled += instance.OnLaunchcube;
            }
        }
    }
    public InGameActions @InGame => new InGameActions(this);
    public interface IInGameActions
    {
        void OnStoppinganimation(InputAction.CallbackContext context);
        void OnLaunchcube(InputAction.CallbackContext context);
    }
}
