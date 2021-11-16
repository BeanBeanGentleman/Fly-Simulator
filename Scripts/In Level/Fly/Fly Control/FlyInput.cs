// GENERATED AUTOMATICALLY FROM 'Assets/Fly-Simulator/Scripts/In Level/Fly/Fly Control/FlyInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FlyInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FlyInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FlyInput"",
    ""maps"": [
        {
            ""name"": ""NormalFly"",
            ""id"": ""f35869c3-d90d-4688-ac06-ffb86ffc010f"",
            ""actions"": [
                {
                    ""name"": ""YawRight"",
                    ""type"": ""Button"",
                    ""id"": ""cc88818b-fd40-43da-90fc-82c6ac377629"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""YawLeft"",
                    ""type"": ""Button"",
                    ""id"": ""19ffc55c-1b2d-4d25-8077-e891ec057dc3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RollRight"",
                    ""type"": ""Button"",
                    ""id"": ""ce0809f3-0c5d-4be0-b256-dd132f585302"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RollLeft"",
                    ""type"": ""Button"",
                    ""id"": ""352f96bd-46c4-4e51-b610-7bb94ba8378b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AirBrake"",
                    ""type"": ""Button"",
                    ""id"": ""33b90efd-37f9-4fd4-b309-2bd9e1772746"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""35e71adb-5018-413f-bc1c-9a86f2a2960d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ingest"",
                    ""type"": ""Button"",
                    ""id"": ""7787d6f5-c482-4394-8478-f3085f48b36e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""794ede7e-ffd1-48af-b234-b9ee8d122bb9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControlSchemeFly"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2563dd61-ac35-4a2f-9256-ad4d83aa667c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControlSchemeFly"",
                    ""action"": ""AirBrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""517a02f7-6dce-4491-8cb4-f94ea0a740f4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControlSchemeFly"",
                    ""action"": ""RollLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a45f0dc-6135-4862-9bc6-701f1b00c9ba"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControlSchemeFly"",
                    ""action"": ""RollRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b27ace0f-975d-4421-a68e-19227c7f1f3b"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControlSchemeFly"",
                    ""action"": ""YawLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a26a2916-6d7d-43e7-aa33-bcea644c9ad8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControlSchemeFly"",
                    ""action"": ""YawRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8aa83928-ea87-4fde-afe4-4d2bee6cd99e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControlSchemeFly"",
                    ""action"": ""Ingest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""ControlSchemeFly"",
            ""bindingGroup"": ""ControlSchemeFly"",
            ""devices"": []
        }
    ]
}");
        // NormalFly
        m_NormalFly = asset.FindActionMap("NormalFly", throwIfNotFound: true);
        m_NormalFly_YawRight = m_NormalFly.FindAction("YawRight", throwIfNotFound: true);
        m_NormalFly_YawLeft = m_NormalFly.FindAction("YawLeft", throwIfNotFound: true);
        m_NormalFly_RollRight = m_NormalFly.FindAction("RollRight", throwIfNotFound: true);
        m_NormalFly_RollLeft = m_NormalFly.FindAction("RollLeft", throwIfNotFound: true);
        m_NormalFly_AirBrake = m_NormalFly.FindAction("AirBrake", throwIfNotFound: true);
        m_NormalFly_Accelerate = m_NormalFly.FindAction("Accelerate", throwIfNotFound: true);
        m_NormalFly_Ingest = m_NormalFly.FindAction("Ingest", throwIfNotFound: true);
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

    // NormalFly
    private readonly InputActionMap m_NormalFly;
    private INormalFlyActions m_NormalFlyActionsCallbackInterface;
    private readonly InputAction m_NormalFly_YawRight;
    private readonly InputAction m_NormalFly_YawLeft;
    private readonly InputAction m_NormalFly_RollRight;
    private readonly InputAction m_NormalFly_RollLeft;
    private readonly InputAction m_NormalFly_AirBrake;
    private readonly InputAction m_NormalFly_Accelerate;
    private readonly InputAction m_NormalFly_Ingest;
    public struct NormalFlyActions
    {
        private @FlyInput m_Wrapper;
        public NormalFlyActions(@FlyInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @YawRight => m_Wrapper.m_NormalFly_YawRight;
        public InputAction @YawLeft => m_Wrapper.m_NormalFly_YawLeft;
        public InputAction @RollRight => m_Wrapper.m_NormalFly_RollRight;
        public InputAction @RollLeft => m_Wrapper.m_NormalFly_RollLeft;
        public InputAction @AirBrake => m_Wrapper.m_NormalFly_AirBrake;
        public InputAction @Accelerate => m_Wrapper.m_NormalFly_Accelerate;
        public InputAction @Ingest => m_Wrapper.m_NormalFly_Ingest;
        public InputActionMap Get() { return m_Wrapper.m_NormalFly; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NormalFlyActions set) { return set.Get(); }
        public void SetCallbacks(INormalFlyActions instance)
        {
            if (m_Wrapper.m_NormalFlyActionsCallbackInterface != null)
            {
                @YawRight.started -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnYawRight;
                @YawRight.performed -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnYawRight;
                @YawRight.canceled -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnYawRight;
                @YawLeft.started -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnYawLeft;
                @YawLeft.performed -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnYawLeft;
                @YawLeft.canceled -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnYawLeft;
                @RollRight.started -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnRollRight;
                @RollRight.performed -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnRollRight;
                @RollRight.canceled -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnRollRight;
                @RollLeft.started -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnRollLeft;
                @RollLeft.performed -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnRollLeft;
                @RollLeft.canceled -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnRollLeft;
                @AirBrake.started -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnAirBrake;
                @AirBrake.performed -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnAirBrake;
                @AirBrake.canceled -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnAirBrake;
                @Accelerate.started -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnAccelerate;
                @Ingest.started -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnIngest;
                @Ingest.performed -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnIngest;
                @Ingest.canceled -= m_Wrapper.m_NormalFlyActionsCallbackInterface.OnIngest;
            }
            m_Wrapper.m_NormalFlyActionsCallbackInterface = instance;
            if (instance != null)
            {
                @YawRight.started += instance.OnYawRight;
                @YawRight.performed += instance.OnYawRight;
                @YawRight.canceled += instance.OnYawRight;
                @YawLeft.started += instance.OnYawLeft;
                @YawLeft.performed += instance.OnYawLeft;
                @YawLeft.canceled += instance.OnYawLeft;
                @RollRight.started += instance.OnRollRight;
                @RollRight.performed += instance.OnRollRight;
                @RollRight.canceled += instance.OnRollRight;
                @RollLeft.started += instance.OnRollLeft;
                @RollLeft.performed += instance.OnRollLeft;
                @RollLeft.canceled += instance.OnRollLeft;
                @AirBrake.started += instance.OnAirBrake;
                @AirBrake.performed += instance.OnAirBrake;
                @AirBrake.canceled += instance.OnAirBrake;
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
                @Ingest.started += instance.OnIngest;
                @Ingest.performed += instance.OnIngest;
                @Ingest.canceled += instance.OnIngest;
            }
        }
    }
    public NormalFlyActions @NormalFly => new NormalFlyActions(this);
    private int m_ControlSchemeFlySchemeIndex = -1;
    public InputControlScheme ControlSchemeFlyScheme
    {
        get
        {
            if (m_ControlSchemeFlySchemeIndex == -1) m_ControlSchemeFlySchemeIndex = asset.FindControlSchemeIndex("ControlSchemeFly");
            return asset.controlSchemes[m_ControlSchemeFlySchemeIndex];
        }
    }
    public interface INormalFlyActions
    {
        void OnYawRight(InputAction.CallbackContext context);
        void OnYawLeft(InputAction.CallbackContext context);
        void OnRollRight(InputAction.CallbackContext context);
        void OnRollLeft(InputAction.CallbackContext context);
        void OnAirBrake(InputAction.CallbackContext context);
        void OnAccelerate(InputAction.CallbackContext context);
        void OnIngest(InputAction.CallbackContext context);
    }
}
