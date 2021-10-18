using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Genral;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Serialization;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

/// <summary>
/// This is the controller script of the fly, handling HP, Energy and Flight control(also include ingesting), but not Camera Control.
/// </summary>
public partial class BaseFlyController : MonoBehaviour
{
    // public InputAction MousePos;
    

    public Rigidbody thisRigidbody;
    public CameraController cc;
    /// <summary>
    /// The force strength for pushing the fly at the given direction.
    /// </summary>
    [FormerlySerializedAs("ForwardAccel")] public ValueContainer movementAccel = new ValueContainer(0);
    /// <summary>
    /// The agility for fly to maneuver. The less value the harder to turn.
    /// </summary>
    public ValueContainer Agility = new ValueContainer(0.3f);
    /// <summary>
    /// The air drag the fly will suffer from. 
    /// </summary>
    public ValueContainer AirDragVal = new ValueContainer(3);
    /// <summary>
    /// The speed of ingestion per second.
    /// </summary>
    public ValueContainer IngestSpeed = new ValueContainer(0.3f);
    /// <summary>
    /// The noise multiplier toward the fly's buzz. Also affect the effective range of the noise.
    /// </summary>
    public ValueContainer NoiseLevel = new ValueContainer(1f);
    
    /// <summary>
    /// The modifer for acceleration for left stick.
    /// </summary>
    public Modifier AccelStrength = new Modifier(false, 2, "0");
    /// <summary>
    /// The maximum modifier for acceleration for left stick.
    /// </summary>
    public float AccelStrengthMax = 2;
    /// <summary>
    /// The extra drag for when climbing on a surface. Better for 
    /// </summary>
    public Modifier OnClimbingExtraDrag = new Modifier(false, 5, "0");

    /// <summary>
    /// The modifer for when left stick is pressed. For Air Drag.
    /// </summary>
    public Modifier AirbrakeDragBonus = new Modifier(false, 15, "0");
    public AudioSource Buzz;
    public AudioSource IngestSound;
    /// <summary>
    /// The apparel of the fly
    /// </summary>
    public GameObject Looking;
    /// <summary>
    /// The arrificial gravity that will applied to the fly.
    /// </summary>
    public float ArtificialGravity = 0.3f;
    
    public float RollingSpeed = 0;
    public float YawingSpeed = 0;
    public float PitchingSpeed = 0;

    public Vector3 CurrentMovingDirection = Vector3.zero;

    private float RollMultiplier = 0;
    private float YawMultiplier = 0.2f;
    private float PitchMultiplier = 0.1f;
    
    
    /// <summary>
    /// The deadzone for controlling yaw
    /// </summary>
    public float DeadZoneYaw = 0.2f;
    /// <summary>
    /// The deadzone for controlling pitch
    /// </summary>
    public float DeadZonePitch = 0.2f;

    private Guid myGuid;

    public bool Ingesting { get; set; }

    public bool IsClimbing;
    public AutoResetCounter ClimbCounter = new AutoResetCounter(5);
    public bool AutoAlignEnabled = true;
    
    private void Start()
    {
        myGuid = Guid.NewGuid();
        movementAccel.SetNoBonusModifier(myGuid);
        Agility.SetNoBonusModifier(myGuid);
        AirDragVal.SetNoBonusModifier(myGuid);
        IngestSpeed.SetNoBonusModifier(myGuid);


    }
    protected void FixedUpdate()
    {
        _ = IsClimbing ? ClimbAction() : FlightAction();
        if (ClimbCounter.IsZeroReached(1, false)) IsClimbing = false;

    }

    int FlightAction()
    {   
        AirDragVal.SetNoBonusModifier(myGuid);
        thisRigidbody.drag = AirDragVal.FinalVal();
        thisRigidbody.AddRelativeForce(movementAccel.FinalVal() * CurrentMovingDirection);
        thisRigidbody.AddForce(Vector3.down * ArtificialGravity);
        // Vector2 MouseActualPos = Mouse.current.position.ReadValue();
        // MouseActualPos = Camera.main.ScreenToViewportPoint(MouseActualPos) - (Vector3.one * 0.5f);

        Vector2 KnownAlignment = _useFreeCam ? Vector2.zero : _alignment;
        float Yaw = Mathf.Clamp(KnownAlignment.x, -1, 1);
        Yaw = Mathf.Abs(Yaw) < DeadZoneYaw ? 0 : Yaw;
        
        float Pitch = Mathf.Clamp(KnownAlignment.y, -1, 1);
        Pitch = Mathf.Abs(Pitch) < DeadZonePitch ? 0 : Pitch;
    
        thisRigidbody.AddRelativeTorque(
            Agility.FinalVal() * Pitch * -PitchMultiplier,
            Agility.FinalVal() * Yaw * YawMultiplier,
            RollingSpeed * RollMultiplier,
            ForceMode.Force);
        thisRigidbody.angularVelocity *= 0.2f;
        RollingSpeed = 0;
        YawingSpeed = 0;
        PitchingSpeed = 0;
        
        Buzz.pitch = NoiseLevel.FinalVal() * (movementAccel.FinalVal() / AccelStrengthMax);
        Buzz.volume = NoiseLevel.FinalVal() * Buzz.pitch;

        Quaternion nextRot = this.transform.rotation;
        if (_useFreeCam)
        {
            nextRot = Quaternion.LookRotation(Vector3.Cross(Vector3.up,
                    Vector3.Cross(thisRigidbody.transform.forward,
                        Vector3.up)),
                Vector3.up);
        }
        this.transform.rotation = Quaternion.Lerp(thisRigidbody.rotation, nextRot, 0.08f);

        return 0;
    }

    private void Update()
    {
        cc.CamLookingEulerOffset = new Vector3(-_alignment.y, _alignment.x,  0) * 180;
        _ = IsClimbing ? Climb() : Flight();
        
        if(_takeOff) TakeDamage(0.1f);
    }



    int Flight()
    {
        float UpDown = _takeOff ? 1 : (_landDown ? -1 : 0);
        UpDown += Mathf.Clamp01(_alignment.y);
        Vector3 AccelDirection = new Vector3(_leftRight, UpDown, _foreBack);
        CurrentMovingDirection = AccelDirection;
        AccelStrength.Value = Mathf.Clamp01(AccelDirection.magnitude) * AccelStrengthMax;
        movementAccel.SetModifier(myGuid, AccelStrength);

        if (_airBreak)
        {
            AirDragVal.SetModifier(myGuid, AirbrakeDragBonus);
        }
        else
        {
            AirDragVal.SetNoBonusModifier(myGuid);
        }

        if (_manualSwitchToggle) AutoAlignEnabled = !AutoAlignEnabled;

        if (AutoAlignEnabled)
        {
            if (_manualSwitchTargetL)
            {
                // Target Switch
            }
            else if (_manualSwitchTargetR)
            {
                // Target Switch
            }
        }

        if (_useFreeCam)
        {
            cc.Freecam = true;
        }
        else
        {
            cc.Freecam = false;
        }

        if (_landDown)
        {
            if (RegularSphereScan(this.transform.position, 15, 15, 2f).Count > 0)
            {
                ClimbCounter.MaxmizeTemp();
                IsClimbing = true;
            }
        }
        
        
        var injestPressed = _ingest;
        this.Ingesting = injestPressed;
        IngestSound.volume = injestPressed?1:0;
        
        CamFollower.transform.localPosition = CamFolwOrigPos;
        CamFollower.transform.localEulerAngles = Vector3.zero;
        
        return 0;
    }
    
    // protected void DeprecatedFixedUpdate()
    // {
    //     thisRigidbody.drag = AirDragVal.FinalVal();
    //     thisRigidbody.AddForce(movementAccel.FinalVal() * this.transform.forward);
    //     thisRigidbody.AddForce(Vector3.down * ArtificialGravity);
    //     Vector2 MouseActualPos = Mouse.current.position.ReadValue();
    //     MouseActualPos = Camera.main.ScreenToViewportPoint(MouseActualPos) - (Vector3.one * 0.5f);
    //
    //     float Yaw = Mathf.Clamp(MouseActualPos.x + YawingSpeed, -1, 1);
    //     Yaw = Mathf.Abs(Yaw) < DeadZoneYaw ? 0 : Yaw;
    //
    //     float Roll = RollingSpeed;
    //
    //     float Pitch = Mathf.Clamp(MouseActualPos.y + PitchingSpeed, -1, 1);
    //     Pitch = Mathf.Abs(Pitch) < DeadZonePitch ? 0 : Pitch;
    //
    //     thisRigidbody.AddRelativeTorque(
    //         Agility.FinalVal() * Pitch * -PitchMultiplier,
    //         Agility.FinalVal() * Yaw * YawMultiplier,
    //         RollingSpeed * RollMultiplier,
    //         ForceMode.Force);
    //     thisRigidbody.angularVelocity *= 0.2f;
    //     RollingSpeed = 0;
    //     YawingSpeed = 0;
    //     PitchingSpeed = 0;
    //     
    //     Buzz.pitch = NoiseLevel.FinalVal() * (movementAccel.FinalVal() / AccelStrength.Value);
    //     Buzz.volume = NoiseLevel.FinalVal() * Buzz.pitch;
    //
    // }
    private void DeprecatedUpdate()
    {
        // if (Accelerate) movementAccel.SetModifier(myGuid, AccelStrength);
        //
        // if (AirBrake)
        // {
        //     AirDragVal.SetModifier(myGuid, AirbrakeDragBonus);
        //     movementAccel.SetModifier(myGuid, BackwardAccel);
        // }
        // else
        // {
        //     AirDragVal.SetNoBonusModifier(myGuid);
        // }
        //
        // if((!AirBrake) && (!Accelerate))movementAccel.SetNoBonusModifier(myGuid);
        //
        // if (RollLeft)
        // {
        //     RollingSpeed = 1;
        // }
        // else if (RollRight)
        // {
        //     RollingSpeed = -1;
        // }
        // else
        //     RollingSpeed = 0;
        //
        // if (YawLeft)
        // {
        //     YawingSpeed = -1;
        // }
        // else if (YawRight)
        // {
        //     YawingSpeed = 1;
        // }
        // else
        //     YawingSpeed = 0;
        //
        // var injestPressed = Ingest;
        // this.Ingesting = injestPressed;
        // IngestSound.volume = injestPressed?1:0;

    }
    
    
    void CancelAccelerate(InputAction.CallbackContext ctx){
        movementAccel.SetNoBonusModifier(myGuid);
    }
    void CancelAirBrake(InputAction.CallbackContext ctx){
        AirDragVal.SetNoBonusModifier(myGuid);
    }
    /// <summary>
    /// For the fly taking damage
    /// </summary>
    /// <param name="Val">The damage that the fly will take. This should be positive if the fly is losing hp.</param>
    public void TakeDamage(float Val)
    {
        var a = FindObjectOfType<HealthBar>();
        a.setValue(a.hp_bar.value - Val );
    }

    private void OnCollisionEnter(Collision other)
    {
        // if (other.gameObject.GetComponent<FoodHit>() != null)
        // {
        //     IngestSound.volume = 1;
        //     IngestSound.Play();
        // }
    }
}