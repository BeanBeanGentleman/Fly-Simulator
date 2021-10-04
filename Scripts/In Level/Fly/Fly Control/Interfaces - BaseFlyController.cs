using System;
using System.Numerics;
using Genral;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public partial class BaseFlyController : MonoBehaviour, FlyControl.IFlightActions, FlyControl.IClimbActions
{
    private FlyControl _FlyControlActions;

    private float _foreBack = 0;
    private float _leftRight = 0;
    private Vector2 _alignment = new Vector2();

    private bool _takeOff;
    private bool _landDown;
    private bool _manualSwitchTargetL;
    private bool _manualSwitchTargetR;
    private bool _manualSwitchToggle;
    private bool _useFreeCam;
    private bool _ingest = false;
    private bool _airBreak = false;
    
    private float _climbForeBack = 0;
    private float _climbLeftRight = 0;
    private Vector2 _view = new Vector2();
    
    
    
    public void Awake()
    {
        _FlyControlActions = new FlyControl();
        _FlyControlActions.Flight.SetCallbacks(this);
        _FlyControlActions.Climb.SetCallbacks(this);
    }
    
    public void OnEnable()
    {
        _FlyControlActions.Flight.Enable();
        _FlyControlActions.Climb.Enable();
    }

    public void OnDisable()
    {
        _FlyControlActions.Flight.Disable();
        _FlyControlActions.Climb.Disable();
    }

    void FlyControl.IFlightActions.OnIngest(InputAction.CallbackContext context)
    {
        _ingest = context.phase == InputActionPhase.Performed;
    }

    public virtual void OnView(InputAction.CallbackContext context)
    {
        _view = context.ReadValue<Vector2>();
    }

    public virtual void OnClimbLR(InputAction.CallbackContext context)
    {
        _climbLeftRight = context.ReadValue<float>();
    }

    public virtual void OnClimbFB(InputAction.CallbackContext context)
    {
        _climbForeBack = context.ReadValue<float>();
    }

    public virtual void OnTakeOff(InputAction.CallbackContext context)
    {
        _takeOff = context.phase == InputActionPhase.Performed;
    }

    void FlyControl.IClimbActions.OnLandDown(InputAction.CallbackContext context)
    {
        _landDown = context.phase == InputActionPhase.Performed;
    }

    void FlyControl.IClimbActions.OnUseFreeCam(InputAction.CallbackContext context)
    {
        _useFreeCam = context.phase == InputActionPhase.Performed;
    }

    public void OnAirBreak(InputAction.CallbackContext context)
    {
        _airBreak = context.phase == InputActionPhase.Performed;
    }

    void FlyControl.IClimbActions.OnManualSelectSwitch(InputAction.CallbackContext context)
    {
        _manualSwitchToggle = context.phase == InputActionPhase.Started;
    }

    public virtual void OnFlightFB(InputAction.CallbackContext context)
    {
        _foreBack = context.ReadValue<float>();
    }

    public virtual void OnFlightLR(InputAction.CallbackContext context)
    {
        _leftRight = context.ReadValue<float>();
    }

    public virtual void OnAlignment(InputAction.CallbackContext context)
    {
        _alignment = context.ReadValue<Vector2>();
    }

    public virtual void OnTakeoff(InputAction.CallbackContext context)
    {
        _takeOff = context.phase == InputActionPhase.Performed;
    }

    void FlyControl.IClimbActions.OnIngest(InputAction.CallbackContext context)
    {
        _ingest = context.phase == InputActionPhase.Performed;
    }

    void FlyControl.IFlightActions.OnLandDown(InputAction.CallbackContext context)
    {
        _landDown = context.phase == InputActionPhase.Performed;
    }

    public virtual void OnManualSelectSwitchL(InputAction.CallbackContext context)
    {
        _manualSwitchTargetL = context.phase == InputActionPhase.Performed;
    }

    public virtual void OnManualSelectSwitchR(InputAction.CallbackContext context)
    {
        _manualSwitchTargetR = context.phase == InputActionPhase.Performed;
    }

    void FlyControl.IFlightActions.OnManualSelectSwitch(InputAction.CallbackContext context)
    {
        _manualSwitchToggle = context.phase == InputActionPhase.Started;
    }

    void FlyControl.IFlightActions.OnUseFreeCam(InputAction.CallbackContext context)
    {
        _useFreeCam = context.phase == InputActionPhase.Performed;
    }
}