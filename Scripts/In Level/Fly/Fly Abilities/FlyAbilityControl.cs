// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/In Level/Fly/Fly Abilities/FlyAbilityControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FlyAbilityControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FlyAbilityControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FlyAbilityControl"",
    ""maps"": [
        {
            ""name"": ""ManeuverabilityAbility"",
            ""id"": ""fc75bceb-0e3b-4d4b-a4be-c1f14bc5c576"",
            ""actions"": [
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""d98ca7dd-71ff-4669-834d-8583b2271fc5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""047292d3-c4a5-4e7c-812b-33a45ede1318"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""AbilityControlScheme"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c8f9b13-928d-482b-928e-c518c66c17c2"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SurviabilityAbility"",
            ""id"": ""586e6c2e-0108-4511-abea-0ef95fc194d8"",
            ""actions"": [
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""65c55826-4f6a-40a9-9c6b-33c2765e09cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""70f4545d-6c02-4382-8f14-e2f8f6241138"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""AbilityControlScheme"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da5d6be1-45c6-4e88-8839-b78fa26c79ba"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UltimateAbility"",
            ""id"": ""4e66072f-ddd2-499b-b585-9198530cc971"",
            ""actions"": [
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""3c5c533a-fae4-455b-b550-3fd09fc383fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7bef6218-963b-4667-b307-a9c439daec20"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""AbilityControlScheme"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0702a32-f968-4956-8e13-e97921ce9bd1"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""AbilityControlScheme"",
            ""bindingGroup"": ""AbilityControlScheme"",
            ""devices"": []
        }
    ]
}");
        // ManeuverabilityAbility
        m_ManeuverabilityAbility = asset.FindActionMap("ManeuverabilityAbility", throwIfNotFound: true);
        m_ManeuverabilityAbility_Use = m_ManeuverabilityAbility.FindAction("Use", throwIfNotFound: true);
        // SurviabilityAbility
        m_SurviabilityAbility = asset.FindActionMap("SurviabilityAbility", throwIfNotFound: true);
        m_SurviabilityAbility_Use = m_SurviabilityAbility.FindAction("Use", throwIfNotFound: true);
        // UltimateAbility
        m_UltimateAbility = asset.FindActionMap("UltimateAbility", throwIfNotFound: true);
        m_UltimateAbility_Use = m_UltimateAbility.FindAction("Use", throwIfNotFound: true);
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

    // ManeuverabilityAbility
    private readonly InputActionMap m_ManeuverabilityAbility;
    private IManeuverabilityAbilityActions m_ManeuverabilityAbilityActionsCallbackInterface;
    private readonly InputAction m_ManeuverabilityAbility_Use;
    public struct ManeuverabilityAbilityActions
    {
        private @FlyAbilityControl m_Wrapper;
        public ManeuverabilityAbilityActions(@FlyAbilityControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Use => m_Wrapper.m_ManeuverabilityAbility_Use;
        public InputActionMap Get() { return m_Wrapper.m_ManeuverabilityAbility; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ManeuverabilityAbilityActions set) { return set.Get(); }
        public void SetCallbacks(IManeuverabilityAbilityActions instance)
        {
            if (m_Wrapper.m_ManeuverabilityAbilityActionsCallbackInterface != null)
            {
                @Use.started -= m_Wrapper.m_ManeuverabilityAbilityActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_ManeuverabilityAbilityActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_ManeuverabilityAbilityActionsCallbackInterface.OnUse;
            }
            m_Wrapper.m_ManeuverabilityAbilityActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
            }
        }
    }
    public ManeuverabilityAbilityActions @ManeuverabilityAbility => new ManeuverabilityAbilityActions(this);

    // SurviabilityAbility
    private readonly InputActionMap m_SurviabilityAbility;
    private ISurviabilityAbilityActions m_SurviabilityAbilityActionsCallbackInterface;
    private readonly InputAction m_SurviabilityAbility_Use;
    public struct SurviabilityAbilityActions
    {
        private @FlyAbilityControl m_Wrapper;
        public SurviabilityAbilityActions(@FlyAbilityControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Use => m_Wrapper.m_SurviabilityAbility_Use;
        public InputActionMap Get() { return m_Wrapper.m_SurviabilityAbility; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SurviabilityAbilityActions set) { return set.Get(); }
        public void SetCallbacks(ISurviabilityAbilityActions instance)
        {
            if (m_Wrapper.m_SurviabilityAbilityActionsCallbackInterface != null)
            {
                @Use.started -= m_Wrapper.m_SurviabilityAbilityActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_SurviabilityAbilityActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_SurviabilityAbilityActionsCallbackInterface.OnUse;
            }
            m_Wrapper.m_SurviabilityAbilityActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
            }
        }
    }
    public SurviabilityAbilityActions @SurviabilityAbility => new SurviabilityAbilityActions(this);

    // UltimateAbility
    private readonly InputActionMap m_UltimateAbility;
    private IUltimateAbilityActions m_UltimateAbilityActionsCallbackInterface;
    private readonly InputAction m_UltimateAbility_Use;
    public struct UltimateAbilityActions
    {
        private @FlyAbilityControl m_Wrapper;
        public UltimateAbilityActions(@FlyAbilityControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Use => m_Wrapper.m_UltimateAbility_Use;
        public InputActionMap Get() { return m_Wrapper.m_UltimateAbility; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UltimateAbilityActions set) { return set.Get(); }
        public void SetCallbacks(IUltimateAbilityActions instance)
        {
            if (m_Wrapper.m_UltimateAbilityActionsCallbackInterface != null)
            {
                @Use.started -= m_Wrapper.m_UltimateAbilityActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_UltimateAbilityActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_UltimateAbilityActionsCallbackInterface.OnUse;
            }
            m_Wrapper.m_UltimateAbilityActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
            }
        }
    }
    public UltimateAbilityActions @UltimateAbility => new UltimateAbilityActions(this);
    private int m_AbilityControlSchemeSchemeIndex = -1;
    public InputControlScheme AbilityControlSchemeScheme
    {
        get
        {
            if (m_AbilityControlSchemeSchemeIndex == -1) m_AbilityControlSchemeSchemeIndex = asset.FindControlSchemeIndex("AbilityControlScheme");
            return asset.controlSchemes[m_AbilityControlSchemeSchemeIndex];
        }
    }
    public interface IManeuverabilityAbilityActions
    {
        void OnUse(InputAction.CallbackContext context);
    }
    public interface ISurviabilityAbilityActions
    {
        void OnUse(InputAction.CallbackContext context);
    }
    public interface IUltimateAbilityActions
    {
        void OnUse(InputAction.CallbackContext context);
    }
}
