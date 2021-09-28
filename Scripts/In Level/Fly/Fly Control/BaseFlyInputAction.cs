// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/In Level/Fly/Fly Control/BaseFlyInputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @BaseFlyInputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @BaseFlyInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BaseFlyInputAction"",
    ""maps"": [
        {
            ""name"": ""FlyControl"",
            ""id"": ""943a402f-c70f-464c-837b-eb8a025cfbb8"",
            ""actions"": [
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""8ba6874d-f865-49a7-b6c5-bc68526ef648"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""AirBrake"",
                    ""type"": ""Button"",
                    ""id"": ""65fa8cb9-1f5d-4d53-b03c-958a87c46dec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""RollLeft"",
                    ""type"": ""Button"",
                    ""id"": ""78476010-6735-438a-9a67-8a8d7c25fcce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""RollRight"",
                    ""type"": ""Button"",
                    ""id"": ""e7eb457e-5640-47ee-84af-6f016c70d1b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""YawLeft"",
                    ""type"": ""Button"",
                    ""id"": ""f212a0b4-bcc9-42e3-91f6-b3d3f2ff1e2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""YawRight"",
                    ""type"": ""Button"",
                    ""id"": ""0174e467-90ef-49b9-93d9-eb69c10dab17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""09c0e09b-cab9-4793-96a0-8e393dffcb66"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67205c49-0cab-4c55-bcac-892e9e592b9d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AirBrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f7576f9-1fa8-4f46-9920-9673a4cfeff5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ec1d270-7373-40a1-a4c9-07d853fda27a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c59fc378-9123-4319-b9f1-527426a66d99"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YawLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b82e6a5a-8501-46f1-8e6a-b69a8c261605"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YawRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""ControlScheme1"",
            ""bindingGroup"": ""ControlScheme1"",
            ""devices"": []
        }
    ]
}");
        // FlyControl
        m_FlyControl = asset.FindActionMap("FlyControl", throwIfNotFound: true);
        m_FlyControl_Accelerate = m_FlyControl.FindAction("Accelerate", throwIfNotFound: true);
        m_FlyControl_AirBrake = m_FlyControl.FindAction("AirBrake", throwIfNotFound: true);
        m_FlyControl_RollLeft = m_FlyControl.FindAction("RollLeft", throwIfNotFound: true);
        m_FlyControl_RollRight = m_FlyControl.FindAction("RollRight", throwIfNotFound: true);
        m_FlyControl_YawLeft = m_FlyControl.FindAction("YawLeft", throwIfNotFound: true);
        m_FlyControl_YawRight = m_FlyControl.FindAction("YawRight", throwIfNotFound: true);
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

    // FlyControl
    private readonly InputActionMap m_FlyControl;
    private IFlyControlActions m_FlyControlActionsCallbackInterface;
    private readonly InputAction m_FlyControl_Accelerate;
    private readonly InputAction m_FlyControl_AirBrake;
    private readonly InputAction m_FlyControl_RollLeft;
    private readonly InputAction m_FlyControl_RollRight;
    private readonly InputAction m_FlyControl_YawLeft;
    private readonly InputAction m_FlyControl_YawRight;
    public struct FlyControlActions
    {
        private @BaseFlyInputAction m_Wrapper;
        public FlyControlActions(@BaseFlyInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerate => m_Wrapper.m_FlyControl_Accelerate;
        public InputAction @AirBrake => m_Wrapper.m_FlyControl_AirBrake;
        public InputAction @RollLeft => m_Wrapper.m_FlyControl_RollLeft;
        public InputAction @RollRight => m_Wrapper.m_FlyControl_RollRight;
        public InputAction @YawLeft => m_Wrapper.m_FlyControl_YawLeft;
        public InputAction @YawRight => m_Wrapper.m_FlyControl_YawRight;
        public InputActionMap Get() { return m_Wrapper.m_FlyControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FlyControlActions set) { return set.Get(); }
        public void SetCallbacks(IFlyControlActions instance)
        {
            if (m_Wrapper.m_FlyControlActionsCallbackInterface != null)
            {
                @Accelerate.started -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnAccelerate;
                @AirBrake.started -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnAirBrake;
                @AirBrake.performed -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnAirBrake;
                @AirBrake.canceled -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnAirBrake;
                @RollLeft.started -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnRollLeft;
                @RollLeft.performed -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnRollLeft;
                @RollLeft.canceled -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnRollLeft;
                @RollRight.started -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnRollRight;
                @RollRight.performed -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnRollRight;
                @RollRight.canceled -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnRollRight;
                @YawLeft.started -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnYawLeft;
                @YawLeft.performed -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnYawLeft;
                @YawLeft.canceled -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnYawLeft;
                @YawRight.started -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnYawRight;
                @YawRight.performed -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnYawRight;
                @YawRight.canceled -= m_Wrapper.m_FlyControlActionsCallbackInterface.OnYawRight;
            }
            m_Wrapper.m_FlyControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
                @AirBrake.started += instance.OnAirBrake;
                @AirBrake.performed += instance.OnAirBrake;
                @AirBrake.canceled += instance.OnAirBrake;
                @RollLeft.started += instance.OnRollLeft;
                @RollLeft.performed += instance.OnRollLeft;
                @RollLeft.canceled += instance.OnRollLeft;
                @RollRight.started += instance.OnRollRight;
                @RollRight.performed += instance.OnRollRight;
                @RollRight.canceled += instance.OnRollRight;
                @YawLeft.started += instance.OnYawLeft;
                @YawLeft.performed += instance.OnYawLeft;
                @YawLeft.canceled += instance.OnYawLeft;
                @YawRight.started += instance.OnYawRight;
                @YawRight.performed += instance.OnYawRight;
                @YawRight.canceled += instance.OnYawRight;
            }
        }
    }
    public FlyControlActions @FlyControl => new FlyControlActions(this);
    private int m_ControlScheme1SchemeIndex = -1;
    public InputControlScheme ControlScheme1Scheme
    {
        get
        {
            if (m_ControlScheme1SchemeIndex == -1) m_ControlScheme1SchemeIndex = asset.FindControlSchemeIndex("ControlScheme1");
            return asset.controlSchemes[m_ControlScheme1SchemeIndex];
        }
    }
    public interface IFlyControlActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnAirBrake(InputAction.CallbackContext context);
        void OnRollLeft(InputAction.CallbackContext context);
        void OnRollRight(InputAction.CallbackContext context);
        void OnYawLeft(InputAction.CallbackContext context);
        void OnYawRight(InputAction.CallbackContext context);
    }
}
