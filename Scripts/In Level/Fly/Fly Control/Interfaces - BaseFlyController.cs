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
        Accelerate += 1;
    }
    public void OnAirBrake(InputAction.CallbackContext ctx)
    {
        AirBrake += 1;
        // AirDragVal.SetModifier(myGuid, AirbrakeDragBonus);
    }
    public void OnRollLeft(InputAction.CallbackContext ctx)
    {
        RollLeft += 1;
        // RollingSpeed = 1;
    }
    public void OnRollRight(InputAction.CallbackContext ctx)
    {
        RollRight += 1;
        // RollingSpeed = -1;
    }
    public void OnYawLeft(InputAction.CallbackContext ctx)
    {
        YawLeft += 1;
        // YawingSpeed = 1;
    }

    public void OnYawRight(InputAction.CallbackContext ctx)
    {
        YawRight += 1;
        // YawingSpeed = -1;
    }

}