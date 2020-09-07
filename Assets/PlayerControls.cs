// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

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
            ""name"": ""Player"",
            ""id"": ""fb70d9d5-3b07-4c82-af31-ec6aaac8d239"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6c72a316-e31c-4378-920a-9273672c9eee"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateTorusRight"",
                    ""type"": ""Value"",
                    ""id"": ""d3e746a5-77e3-4f7c-a386-8ebf13ad00be"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateTorusLeft"",
                    ""type"": ""Value"",
                    ""id"": ""155ff172-7231-4053-9d74-cf9dee7de8c1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""2a3b035b-688e-4caf-94f8-426c19c62fd9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Wave"",
                    ""type"": ""Button"",
                    ""id"": ""2a9a9dac-8804-48f5-bf90-e7acc20002db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpeedUp"",
                    ""type"": ""Button"",
                    ""id"": ""c6986cb2-e637-4a8a-974e-563dd2a6d417"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""19ed71ee-7d0b-46ac-bb16-3ed428fbcbae"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b700240-839d-4a13-a65a-037e8a9ca640"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateTorusRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89fbe881-5bb6-4112-bafb-31e183a51a5d"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateTorusLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91fea252-ef93-4df5-a281-31aef2670e33"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0317b84-0a72-4ec9-a6d6-513f2e86a991"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Wave"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3a6a616-b076-42e9-aa08-a133cc81e6bb"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpeedUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_RotateTorusRight = m_Player.FindAction("RotateTorusRight", throwIfNotFound: true);
        m_Player_RotateTorusLeft = m_Player.FindAction("RotateTorusLeft", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        m_Player_Wave = m_Player.FindAction("Wave", throwIfNotFound: true);
        m_Player_SpeedUp = m_Player.FindAction("SpeedUp", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_RotateTorusRight;
    private readonly InputAction m_Player_RotateTorusLeft;
    private readonly InputAction m_Player_Fire;
    private readonly InputAction m_Player_Wave;
    private readonly InputAction m_Player_SpeedUp;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @RotateTorusRight => m_Wrapper.m_Player_RotateTorusRight;
        public InputAction @RotateTorusLeft => m_Wrapper.m_Player_RotateTorusLeft;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @Wave => m_Wrapper.m_Player_Wave;
        public InputAction @SpeedUp => m_Wrapper.m_Player_SpeedUp;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @RotateTorusRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateTorusRight;
                @RotateTorusRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateTorusRight;
                @RotateTorusRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateTorusRight;
                @RotateTorusLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateTorusLeft;
                @RotateTorusLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateTorusLeft;
                @RotateTorusLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateTorusLeft;
                @Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Wave.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWave;
                @Wave.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWave;
                @Wave.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWave;
                @SpeedUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpeedUp;
                @SpeedUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpeedUp;
                @SpeedUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpeedUp;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @RotateTorusRight.started += instance.OnRotateTorusRight;
                @RotateTorusRight.performed += instance.OnRotateTorusRight;
                @RotateTorusRight.canceled += instance.OnRotateTorusRight;
                @RotateTorusLeft.started += instance.OnRotateTorusLeft;
                @RotateTorusLeft.performed += instance.OnRotateTorusLeft;
                @RotateTorusLeft.canceled += instance.OnRotateTorusLeft;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Wave.started += instance.OnWave;
                @Wave.performed += instance.OnWave;
                @Wave.canceled += instance.OnWave;
                @SpeedUp.started += instance.OnSpeedUp;
                @SpeedUp.performed += instance.OnSpeedUp;
                @SpeedUp.canceled += instance.OnSpeedUp;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotateTorusRight(InputAction.CallbackContext context);
        void OnRotateTorusLeft(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnWave(InputAction.CallbackContext context);
        void OnSpeedUp(InputAction.CallbackContext context);
    }
}
