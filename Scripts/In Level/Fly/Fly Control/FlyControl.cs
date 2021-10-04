// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/In Level/Fly/Fly Control/FlyControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FlyControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FlyControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FlyControl"",
    ""maps"": [
        {
            ""name"": ""Flight"",
            ""id"": ""7a8441d7-0e35-4e46-9940-5c22a756183d"",
            ""actions"": [
                {
                    ""name"": ""Ingest"",
                    ""type"": ""Button"",
                    ""id"": ""fa88a472-5740-4811-af78-336b5b606926"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FlightFB"",
                    ""type"": ""Value"",
                    ""id"": ""1a931098-c4f5-468f-a351-c7f31cf02f93"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FlightLR"",
                    ""type"": ""Value"",
                    ""id"": ""098db4f6-6c7c-4403-88ad-0eb456af9d6e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Alignment"",
                    ""type"": ""Value"",
                    ""id"": ""b92e519a-229c-4b35-a300-a040fdc259ad"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Takeoff"",
                    ""type"": ""Button"",
                    ""id"": ""e686560d-7bda-4579-8166-c81f658c5b79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LandDown"",
                    ""type"": ""Button"",
                    ""id"": ""e945f613-eab4-47f6-afa2-02da6f319352"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ManualSelectSwitchL"",
                    ""type"": ""Button"",
                    ""id"": ""edac13e9-7555-44c4-a77d-3cabc617f72d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ManualSelectSwitchR"",
                    ""type"": ""Button"",
                    ""id"": ""41cdbe24-bf4e-4054-9966-74d1a12e9708"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ManualSelectSwitch"",
                    ""type"": ""Button"",
                    ""id"": ""6be0885c-55fb-4fe8-bdbd-580cac648d60"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseFreeCam"",
                    ""type"": ""Button"",
                    ""id"": ""ab5357a4-b840-4130-8647-777b6433e172"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AirBreak"",
                    ""type"": ""Button"",
                    ""id"": ""23b59cd4-ebdf-4450-a44a-353e4beb9d15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f45e2f27-ed98-4a0c-a8b7-90633aded10d"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""Ingest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6163bd4-858b-4056-9424-f4502020852b"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""FlightFB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42aa483c-15ba-4d2a-94ad-19fec4b42b59"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""FlightLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffbdd050-7918-48da-8d75-06a30507a843"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""Alignment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fa2cda4-1346-45fb-9f93-bbd0e89263d0"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""Takeoff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d1eb038-8c13-4662-abc1-ac16cf002f66"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""LandDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""398508d1-046b-4d42-80aa-df3dbf9bbb93"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""ManualSelectSwitchL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e5b4ffd-a8cd-49c1-ad90-ce37a4d83a57"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""ManualSelectSwitchR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d81bc1c-7b67-44e0-86ba-58611aa05ed9"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""UseFreeCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcb61ee7-c288-421c-9712-a3dc3fb24632"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""ManualSelectSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f456fb5-6fe1-4e82-9fd9-9e5b0aa83480"",
                    ""path"": ""<XInputController>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""AirBreak"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Climb"",
            ""id"": ""5172d893-1338-45d0-844b-bfa94c2f0ec0"",
            ""actions"": [
                {
                    ""name"": ""Ingest"",
                    ""type"": ""Button"",
                    ""id"": ""298e98fe-814c-445c-91cb-e4933a389f2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""View"",
                    ""type"": ""Value"",
                    ""id"": ""e1171ca3-be35-424c-b8f1-f53437b34737"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ClimbLR"",
                    ""type"": ""Value"",
                    ""id"": ""3570c9f9-1736-4951-8531-d74b16e4048d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ClimbFB"",
                    ""type"": ""Value"",
                    ""id"": ""539ad5b4-61ba-4685-ad9e-a7e026a47b2f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TakeOff"",
                    ""type"": ""Button"",
                    ""id"": ""0d3d2464-0612-443f-9d0a-843c648dffaf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LandDown"",
                    ""type"": ""Button"",
                    ""id"": ""1003a479-8991-44b4-9ee9-2853e2816c10"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseFreeCam"",
                    ""type"": ""Button"",
                    ""id"": ""7f3ace1d-70ab-4869-9a5b-5e2deb631c10"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ManualSelectSwitch"",
                    ""type"": ""Button"",
                    ""id"": ""996c7d84-f2b3-40c7-ba61-3dfc7bf2f88a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""68e8157b-a13b-4270-9e1d-c6833914f9ab"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""Ingest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37b23cfb-46af-4d3d-bbd0-9d9fcdf89d88"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""View"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5cdde67-086d-41c0-a10a-204cd006cd46"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""ClimbLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a11b7ab-1110-4150-b3e8-2fd12ee758c4"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""ClimbFB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35dacbfa-a1bf-4a24-a7f9-91c5cee04e7b"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""TakeOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bfeb046-16b5-4c7d-93d4-cbadcab01bb7"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""LandDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aec63289-df9a-4aef-a8d8-7dcd838e55b7"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""ManualSelectSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07d0a86d-7133-4af4-9c77-d2afd2a0a9b8"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllerSchemeMouseLike"",
                    ""action"": ""UseFreeCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""ControllerSchemeMouseLike"",
            ""bindingGroup"": ""ControllerSchemeMouseLike"",
            ""devices"": []
        }
    ]
}");
        // Flight
        m_Flight = asset.FindActionMap("Flight", throwIfNotFound: true);
        m_Flight_Ingest = m_Flight.FindAction("Ingest", throwIfNotFound: true);
        m_Flight_FlightFB = m_Flight.FindAction("FlightFB", throwIfNotFound: true);
        m_Flight_FlightLR = m_Flight.FindAction("FlightLR", throwIfNotFound: true);
        m_Flight_Alignment = m_Flight.FindAction("Alignment", throwIfNotFound: true);
        m_Flight_Takeoff = m_Flight.FindAction("Takeoff", throwIfNotFound: true);
        m_Flight_LandDown = m_Flight.FindAction("LandDown", throwIfNotFound: true);
        m_Flight_ManualSelectSwitchL = m_Flight.FindAction("ManualSelectSwitchL", throwIfNotFound: true);
        m_Flight_ManualSelectSwitchR = m_Flight.FindAction("ManualSelectSwitchR", throwIfNotFound: true);
        m_Flight_ManualSelectSwitch = m_Flight.FindAction("ManualSelectSwitch", throwIfNotFound: true);
        m_Flight_UseFreeCam = m_Flight.FindAction("UseFreeCam", throwIfNotFound: true);
        m_Flight_AirBreak = m_Flight.FindAction("AirBreak", throwIfNotFound: true);
        // Climb
        m_Climb = asset.FindActionMap("Climb", throwIfNotFound: true);
        m_Climb_Ingest = m_Climb.FindAction("Ingest", throwIfNotFound: true);
        m_Climb_View = m_Climb.FindAction("View", throwIfNotFound: true);
        m_Climb_ClimbLR = m_Climb.FindAction("ClimbLR", throwIfNotFound: true);
        m_Climb_ClimbFB = m_Climb.FindAction("ClimbFB", throwIfNotFound: true);
        m_Climb_TakeOff = m_Climb.FindAction("TakeOff", throwIfNotFound: true);
        m_Climb_LandDown = m_Climb.FindAction("LandDown", throwIfNotFound: true);
        m_Climb_UseFreeCam = m_Climb.FindAction("UseFreeCam", throwIfNotFound: true);
        m_Climb_ManualSelectSwitch = m_Climb.FindAction("ManualSelectSwitch", throwIfNotFound: true);
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

    // Flight
    private readonly InputActionMap m_Flight;
    private IFlightActions m_FlightActionsCallbackInterface;
    private readonly InputAction m_Flight_Ingest;
    private readonly InputAction m_Flight_FlightFB;
    private readonly InputAction m_Flight_FlightLR;
    private readonly InputAction m_Flight_Alignment;
    private readonly InputAction m_Flight_Takeoff;
    private readonly InputAction m_Flight_LandDown;
    private readonly InputAction m_Flight_ManualSelectSwitchL;
    private readonly InputAction m_Flight_ManualSelectSwitchR;
    private readonly InputAction m_Flight_ManualSelectSwitch;
    private readonly InputAction m_Flight_UseFreeCam;
    private readonly InputAction m_Flight_AirBreak;
    public struct FlightActions
    {
        private @FlyControl m_Wrapper;
        public FlightActions(@FlyControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Ingest => m_Wrapper.m_Flight_Ingest;
        public InputAction @FlightFB => m_Wrapper.m_Flight_FlightFB;
        public InputAction @FlightLR => m_Wrapper.m_Flight_FlightLR;
        public InputAction @Alignment => m_Wrapper.m_Flight_Alignment;
        public InputAction @Takeoff => m_Wrapper.m_Flight_Takeoff;
        public InputAction @LandDown => m_Wrapper.m_Flight_LandDown;
        public InputAction @ManualSelectSwitchL => m_Wrapper.m_Flight_ManualSelectSwitchL;
        public InputAction @ManualSelectSwitchR => m_Wrapper.m_Flight_ManualSelectSwitchR;
        public InputAction @ManualSelectSwitch => m_Wrapper.m_Flight_ManualSelectSwitch;
        public InputAction @UseFreeCam => m_Wrapper.m_Flight_UseFreeCam;
        public InputAction @AirBreak => m_Wrapper.m_Flight_AirBreak;
        public InputActionMap Get() { return m_Wrapper.m_Flight; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FlightActions set) { return set.Get(); }
        public void SetCallbacks(IFlightActions instance)
        {
            if (m_Wrapper.m_FlightActionsCallbackInterface != null)
            {
                @Ingest.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnIngest;
                @Ingest.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnIngest;
                @Ingest.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnIngest;
                @FlightFB.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnFlightFB;
                @FlightFB.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnFlightFB;
                @FlightFB.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnFlightFB;
                @FlightLR.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnFlightLR;
                @FlightLR.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnFlightLR;
                @FlightLR.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnFlightLR;
                @Alignment.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnAlignment;
                @Alignment.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnAlignment;
                @Alignment.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnAlignment;
                @Takeoff.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnTakeoff;
                @Takeoff.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnTakeoff;
                @Takeoff.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnTakeoff;
                @LandDown.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnLandDown;
                @LandDown.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnLandDown;
                @LandDown.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnLandDown;
                @ManualSelectSwitchL.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnManualSelectSwitchL;
                @ManualSelectSwitchL.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnManualSelectSwitchL;
                @ManualSelectSwitchL.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnManualSelectSwitchL;
                @ManualSelectSwitchR.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnManualSelectSwitchR;
                @ManualSelectSwitchR.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnManualSelectSwitchR;
                @ManualSelectSwitchR.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnManualSelectSwitchR;
                @ManualSelectSwitch.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnManualSelectSwitch;
                @ManualSelectSwitch.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnManualSelectSwitch;
                @ManualSelectSwitch.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnManualSelectSwitch;
                @UseFreeCam.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnUseFreeCam;
                @UseFreeCam.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnUseFreeCam;
                @UseFreeCam.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnUseFreeCam;
                @AirBreak.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnAirBreak;
                @AirBreak.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnAirBreak;
                @AirBreak.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnAirBreak;
            }
            m_Wrapper.m_FlightActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Ingest.started += instance.OnIngest;
                @Ingest.performed += instance.OnIngest;
                @Ingest.canceled += instance.OnIngest;
                @FlightFB.started += instance.OnFlightFB;
                @FlightFB.performed += instance.OnFlightFB;
                @FlightFB.canceled += instance.OnFlightFB;
                @FlightLR.started += instance.OnFlightLR;
                @FlightLR.performed += instance.OnFlightLR;
                @FlightLR.canceled += instance.OnFlightLR;
                @Alignment.started += instance.OnAlignment;
                @Alignment.performed += instance.OnAlignment;
                @Alignment.canceled += instance.OnAlignment;
                @Takeoff.started += instance.OnTakeoff;
                @Takeoff.performed += instance.OnTakeoff;
                @Takeoff.canceled += instance.OnTakeoff;
                @LandDown.started += instance.OnLandDown;
                @LandDown.performed += instance.OnLandDown;
                @LandDown.canceled += instance.OnLandDown;
                @ManualSelectSwitchL.started += instance.OnManualSelectSwitchL;
                @ManualSelectSwitchL.performed += instance.OnManualSelectSwitchL;
                @ManualSelectSwitchL.canceled += instance.OnManualSelectSwitchL;
                @ManualSelectSwitchR.started += instance.OnManualSelectSwitchR;
                @ManualSelectSwitchR.performed += instance.OnManualSelectSwitchR;
                @ManualSelectSwitchR.canceled += instance.OnManualSelectSwitchR;
                @ManualSelectSwitch.started += instance.OnManualSelectSwitch;
                @ManualSelectSwitch.performed += instance.OnManualSelectSwitch;
                @ManualSelectSwitch.canceled += instance.OnManualSelectSwitch;
                @UseFreeCam.started += instance.OnUseFreeCam;
                @UseFreeCam.performed += instance.OnUseFreeCam;
                @UseFreeCam.canceled += instance.OnUseFreeCam;
                @AirBreak.started += instance.OnAirBreak;
                @AirBreak.performed += instance.OnAirBreak;
                @AirBreak.canceled += instance.OnAirBreak;
            }
        }
    }
    public FlightActions @Flight => new FlightActions(this);

    // Climb
    private readonly InputActionMap m_Climb;
    private IClimbActions m_ClimbActionsCallbackInterface;
    private readonly InputAction m_Climb_Ingest;
    private readonly InputAction m_Climb_View;
    private readonly InputAction m_Climb_ClimbLR;
    private readonly InputAction m_Climb_ClimbFB;
    private readonly InputAction m_Climb_TakeOff;
    private readonly InputAction m_Climb_LandDown;
    private readonly InputAction m_Climb_UseFreeCam;
    private readonly InputAction m_Climb_ManualSelectSwitch;
    public struct ClimbActions
    {
        private @FlyControl m_Wrapper;
        public ClimbActions(@FlyControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Ingest => m_Wrapper.m_Climb_Ingest;
        public InputAction @View => m_Wrapper.m_Climb_View;
        public InputAction @ClimbLR => m_Wrapper.m_Climb_ClimbLR;
        public InputAction @ClimbFB => m_Wrapper.m_Climb_ClimbFB;
        public InputAction @TakeOff => m_Wrapper.m_Climb_TakeOff;
        public InputAction @LandDown => m_Wrapper.m_Climb_LandDown;
        public InputAction @UseFreeCam => m_Wrapper.m_Climb_UseFreeCam;
        public InputAction @ManualSelectSwitch => m_Wrapper.m_Climb_ManualSelectSwitch;
        public InputActionMap Get() { return m_Wrapper.m_Climb; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ClimbActions set) { return set.Get(); }
        public void SetCallbacks(IClimbActions instance)
        {
            if (m_Wrapper.m_ClimbActionsCallbackInterface != null)
            {
                @Ingest.started -= m_Wrapper.m_ClimbActionsCallbackInterface.OnIngest;
                @Ingest.performed -= m_Wrapper.m_ClimbActionsCallbackInterface.OnIngest;
                @Ingest.canceled -= m_Wrapper.m_ClimbActionsCallbackInterface.OnIngest;
                @View.started -= m_Wrapper.m_ClimbActionsCallbackInterface.OnView;
                @View.performed -= m_Wrapper.m_ClimbActionsCallbackInterface.OnView;
                @View.canceled -= m_Wrapper.m_ClimbActionsCallbackInterface.OnView;
                @ClimbLR.started -= m_Wrapper.m_ClimbActionsCallbackInterface.OnClimbLR;
                @ClimbLR.performed -= m_Wrapper.m_ClimbActionsCallbackInterface.OnClimbLR;
                @ClimbLR.canceled -= m_Wrapper.m_ClimbActionsCallbackInterface.OnClimbLR;
                @ClimbFB.started -= m_Wrapper.m_ClimbActionsCallbackInterface.OnClimbFB;
                @ClimbFB.performed -= m_Wrapper.m_ClimbActionsCallbackInterface.OnClimbFB;
                @ClimbFB.canceled -= m_Wrapper.m_ClimbActionsCallbackInterface.OnClimbFB;
                @TakeOff.started -= m_Wrapper.m_ClimbActionsCallbackInterface.OnTakeOff;
                @TakeOff.performed -= m_Wrapper.m_ClimbActionsCallbackInterface.OnTakeOff;
                @TakeOff.canceled -= m_Wrapper.m_ClimbActionsCallbackInterface.OnTakeOff;
                @LandDown.started -= m_Wrapper.m_ClimbActionsCallbackInterface.OnLandDown;
                @LandDown.performed -= m_Wrapper.m_ClimbActionsCallbackInterface.OnLandDown;
                @LandDown.canceled -= m_Wrapper.m_ClimbActionsCallbackInterface.OnLandDown;
                @UseFreeCam.started -= m_Wrapper.m_ClimbActionsCallbackInterface.OnUseFreeCam;
                @UseFreeCam.performed -= m_Wrapper.m_ClimbActionsCallbackInterface.OnUseFreeCam;
                @UseFreeCam.canceled -= m_Wrapper.m_ClimbActionsCallbackInterface.OnUseFreeCam;
                @ManualSelectSwitch.started -= m_Wrapper.m_ClimbActionsCallbackInterface.OnManualSelectSwitch;
                @ManualSelectSwitch.performed -= m_Wrapper.m_ClimbActionsCallbackInterface.OnManualSelectSwitch;
                @ManualSelectSwitch.canceled -= m_Wrapper.m_ClimbActionsCallbackInterface.OnManualSelectSwitch;
            }
            m_Wrapper.m_ClimbActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Ingest.started += instance.OnIngest;
                @Ingest.performed += instance.OnIngest;
                @Ingest.canceled += instance.OnIngest;
                @View.started += instance.OnView;
                @View.performed += instance.OnView;
                @View.canceled += instance.OnView;
                @ClimbLR.started += instance.OnClimbLR;
                @ClimbLR.performed += instance.OnClimbLR;
                @ClimbLR.canceled += instance.OnClimbLR;
                @ClimbFB.started += instance.OnClimbFB;
                @ClimbFB.performed += instance.OnClimbFB;
                @ClimbFB.canceled += instance.OnClimbFB;
                @TakeOff.started += instance.OnTakeOff;
                @TakeOff.performed += instance.OnTakeOff;
                @TakeOff.canceled += instance.OnTakeOff;
                @LandDown.started += instance.OnLandDown;
                @LandDown.performed += instance.OnLandDown;
                @LandDown.canceled += instance.OnLandDown;
                @UseFreeCam.started += instance.OnUseFreeCam;
                @UseFreeCam.performed += instance.OnUseFreeCam;
                @UseFreeCam.canceled += instance.OnUseFreeCam;
                @ManualSelectSwitch.started += instance.OnManualSelectSwitch;
                @ManualSelectSwitch.performed += instance.OnManualSelectSwitch;
                @ManualSelectSwitch.canceled += instance.OnManualSelectSwitch;
            }
        }
    }
    public ClimbActions @Climb => new ClimbActions(this);
    private int m_ControllerSchemeMouseLikeSchemeIndex = -1;
    public InputControlScheme ControllerSchemeMouseLikeScheme
    {
        get
        {
            if (m_ControllerSchemeMouseLikeSchemeIndex == -1) m_ControllerSchemeMouseLikeSchemeIndex = asset.FindControlSchemeIndex("ControllerSchemeMouseLike");
            return asset.controlSchemes[m_ControllerSchemeMouseLikeSchemeIndex];
        }
    }
    public interface IFlightActions
    {
        void OnIngest(InputAction.CallbackContext context);
        void OnFlightFB(InputAction.CallbackContext context);
        void OnFlightLR(InputAction.CallbackContext context);
        void OnAlignment(InputAction.CallbackContext context);
        void OnTakeoff(InputAction.CallbackContext context);
        void OnLandDown(InputAction.CallbackContext context);
        void OnManualSelectSwitchL(InputAction.CallbackContext context);
        void OnManualSelectSwitchR(InputAction.CallbackContext context);
        void OnManualSelectSwitch(InputAction.CallbackContext context);
        void OnUseFreeCam(InputAction.CallbackContext context);
        void OnAirBreak(InputAction.CallbackContext context);
    }
    public interface IClimbActions
    {
        void OnIngest(InputAction.CallbackContext context);
        void OnView(InputAction.CallbackContext context);
        void OnClimbLR(InputAction.CallbackContext context);
        void OnClimbFB(InputAction.CallbackContext context);
        void OnTakeOff(InputAction.CallbackContext context);
        void OnLandDown(InputAction.CallbackContext context);
        void OnUseFreeCam(InputAction.CallbackContext context);
        void OnManualSelectSwitch(InputAction.CallbackContext context);
    }
}
