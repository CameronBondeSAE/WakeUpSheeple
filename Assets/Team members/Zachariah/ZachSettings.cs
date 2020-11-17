// GENERATED AUTOMATICALLY FROM 'Assets/Team members/Zachariah/ZachSettings.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ZachSettings : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ZachSettings()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ZachSettings"",
    ""maps"": [
        {
            ""name"": ""Zach"",
            ""id"": ""20cf3e3c-c3e4-4b94-9c52-ac49769db79a"",
            ""actions"": [
                {
                    ""name"": ""WASD"",
                    ""type"": ""Value"",
                    ""id"": ""4fef1455-592d-492f-8efb-b8669ed0ff13"",
                    ""expectedControlType"": ""Key"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""715ddcf3-bbea-4fb8-814a-7a5c649ecb02"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""99ec5e0f-c88b-4ebf-857b-5968413bfb98"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""896d194e-6b68-49b0-bba0-25438a37ddee"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0d8cc6b5-e957-408f-b21e-ba22fbfcfc1f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9fbd8112-47d7-4842-a89a-63c73b9c6575"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Zach
        m_Zach = asset.FindActionMap("Zach", throwIfNotFound: true);
        m_Zach_WASD = m_Zach.FindAction("WASD", throwIfNotFound: true);
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

    // Zach
    private readonly InputActionMap m_Zach;
    private IZachActions m_ZachActionsCallbackInterface;
    private readonly InputAction m_Zach_WASD;
    public struct ZachActions
    {
        private @ZachSettings m_Wrapper;
        public ZachActions(@ZachSettings wrapper) { m_Wrapper = wrapper; }
        public InputAction @WASD => m_Wrapper.m_Zach_WASD;
        public InputActionMap Get() { return m_Wrapper.m_Zach; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ZachActions set) { return set.Get(); }
        public void SetCallbacks(IZachActions instance)
        {
            if (m_Wrapper.m_ZachActionsCallbackInterface != null)
            {
                @WASD.started -= m_Wrapper.m_ZachActionsCallbackInterface.OnWASD;
                @WASD.performed -= m_Wrapper.m_ZachActionsCallbackInterface.OnWASD;
                @WASD.canceled -= m_Wrapper.m_ZachActionsCallbackInterface.OnWASD;
            }
            m_Wrapper.m_ZachActionsCallbackInterface = instance;
            if (instance != null)
            {
                @WASD.started += instance.OnWASD;
                @WASD.performed += instance.OnWASD;
                @WASD.canceled += instance.OnWASD;
            }
        }
    }
    public ZachActions @Zach => new ZachActions(this);
    public interface IZachActions
    {
        void OnWASD(InputAction.CallbackContext context);
    }
}
