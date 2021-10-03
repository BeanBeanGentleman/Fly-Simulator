using System;
using System.Numerics;
using Genral;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public partial class BaseFlyController : MonoBehaviour, FlyInput.INormalFlyActions
{
    private FlyInput _FlyInputActions;
    
    private bool Accelerate = false;
    private bool AirBrake = false;
    private bool RollLeft = false;
    private bool RollRight = false;
    private bool YawLeft = false;
    private bool YawRight = false;
    private bool Ingest = false;
    
    public void Awake()
    {
        _FlyInputActions = new FlyInput();
        _FlyInputActions.NormalFly.SetCallbacks(this);
    }
    
    public void OnEnable()
    {
        _FlyInputActions.NormalFly.Enable();
    }

    public void OnDisable()
    {
        _FlyInputActions.NormalFly.Disable();
    }
    
    public void OnAccelerate(InputAction.CallbackContext ctx){
        // ForwardAccel.SetModifier(myGuid, ForwardMoreAccel);
        Accelerate = ctx.phase == InputActionPhase.Performed;
    }

    public void OnIngest(InputAction.CallbackContext ctx)
    {
        Ingest = ctx.phase == InputActionPhase.Performed;
    }

    public void OnAirBrake(InputAction.CallbackContext ctx)
    {
        AirBrake = ctx.phase == InputActionPhase.Performed;
        // AirDragVal.SetModifier(myGuid, AirbrakeDragBonus);
    }
    public void OnRollLeft(InputAction.CallbackContext ctx)
    {
        RollLeft = ctx.phase == InputActionPhase.Performed;
        // RollingSpeed = 1;
    }
    public void OnRollRight(InputAction.CallbackContext ctx)
    {
        RollRight = ctx.phase == InputActionPhase.Performed;
        // RollingSpeed = -1;
    }
    public void OnYawLeft(InputAction.CallbackContext ctx)
    {
        YawLeft = ctx.phase == InputActionPhase.Performed;
        // YawingSpeed = 1;
    }

    public void OnYawRight(InputAction.CallbackContext ctx)
    {
        YawRight = ctx.phase == InputActionPhase.Performed;
        // YawingSpeed = -1;
    }

}