// GENERATED AUTOMATICALLY FROM 'Assets/Team members/Cam/Cams Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CamsControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CamsControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Cams Controls"",
    ""maps"": [
        {
            ""name"": ""In Game"",
            ""id"": ""094944d6-15e3-4ab9-b276-7472bb623108"",
            ""actions"": [
                {
                    ""name"": ""Bark"",
                    ""type"": ""Button"",
                    ""id"": ""32ba3c9d-4bad-40a8-b71d-3acf3ecf3cd0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""6187aad4-c6a9-4629-a544-1c1c5d5648c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Howl"",
                    ""type"": ""Button"",
                    ""id"": ""f152fda8-9cd6-4a90-8ff5-499e8f4ccab6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""78c1bf18-d870-48b2-92a1-659f9767c0dd"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bark"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1714f9b2-d967-489f-8e5e-7bce84b448bd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bark"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b83fb06-cb52-40f2-b994-c78bedbc4e2c"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52e62f67-663b-459b-9740-afaf94640113"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Howl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""In Menu"",
            ""id"": ""c2e5c2e2-962c-48df-a5a5-b67af1234831"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""4f415a92-098e-43fa-bae7-684e849f036b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""474af09e-9afe-4805-bd7f-ce1377cc85bd"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37164360-72ad-43e0-bde2-78e5410bc2d7"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Game Over"",
            ""id"": ""e0b8abae-3d0e-4d95-a52d-50f3e459ad35"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""5214f8c7-62e2-4b8d-98e3-4ed5891af6e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f19f4a9a-7591-4894-a880-66a9fa2b33ec"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
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
        m_InGame_Bark = m_InGame.FindAction("Bark", throwIfNotFound: true);
        m_InGame_Move = m_InGame.FindAction("Move", throwIfNotFound: true);
        m_InGame_Howl = m_InGame.FindAction("Howl", throwIfNotFound: true);
        // In Menu
        m_InMenu = asset.FindActionMap("In Menu", throwIfNotFound: true);
        m_InMenu_Select = m_InMenu.FindAction("Select", throwIfNotFound: true);
        // Game Over
        m_GameOver = asset.FindActionMap("Game Over", throwIfNotFound: true);
        m_GameOver_Newaction = m_GameOver.FindAction("New action", throwIfNotFound: true);
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
    private readonly InputAction m_InGame_Bark;
    private readonly InputAction m_InGame_Move;
    private readonly InputAction m_InGame_Howl;
    public struct InGameActions
    {
        private @CamsControls m_Wrapper;
        public InGameActions(@CamsControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Bark => m_Wrapper.m_InGame_Bark;
        public InputAction @Move => m_Wrapper.m_InGame_Move;
        public InputAction @Howl => m_Wrapper.m_InGame_Howl;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void SetCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterface != null)
            {
                @Bark.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnBark;
                @Bark.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnBark;
                @Bark.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnBark;
                @Move.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @Howl.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnHowl;
                @Howl.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnHowl;
                @Howl.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnHowl;
            }
            m_Wrapper.m_InGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Bark.started += instance.OnBark;
                @Bark.performed += instance.OnBark;
                @Bark.canceled += instance.OnBark;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Howl.started += instance.OnHowl;
                @Howl.performed += instance.OnHowl;
                @Howl.canceled += instance.OnHowl;
            }
        }
    }
    public InGameActions @InGame => new InGameActions(this);

    // In Menu
    private readonly InputActionMap m_InMenu;
    private IInMenuActions m_InMenuActionsCallbackInterface;
    private readonly InputAction m_InMenu_Select;
    public struct InMenuActions
    {
        private @CamsControls m_Wrapper;
        public InMenuActions(@CamsControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_InMenu_Select;
        public InputActionMap Get() { return m_Wrapper.m_InMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InMenuActions set) { return set.Get(); }
        public void SetCallbacks(IInMenuActions instance)
        {
            if (m_Wrapper.m_InMenuActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_InMenuActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_InMenuActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_InMenuActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_InMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public InMenuActions @InMenu => new InMenuActions(this);

    // Game Over
    private readonly InputActionMap m_GameOver;
    private IGameOverActions m_GameOverActionsCallbackInterface;
    private readonly InputAction m_GameOver_Newaction;
    public struct GameOverActions
    {
        private @CamsControls m_Wrapper;
        public GameOverActions(@CamsControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_GameOver_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_GameOver; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameOverActions set) { return set.Get(); }
        public void SetCallbacks(IGameOverActions instance)
        {
            if (m_Wrapper.m_GameOverActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_GameOverActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_GameOverActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_GameOverActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_GameOverActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public GameOverActions @GameOver => new GameOverActions(this);
    public interface IInGameActions
    {
        void OnBark(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnHowl(InputAction.CallbackContext context);
    }
    public interface IInMenuActions
    {
        void OnSelect(InputAction.CallbackContext context);
    }
    public interface IGameOverActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
