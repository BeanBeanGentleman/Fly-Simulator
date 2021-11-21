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
    ///
    [FormerlySerializedAs("ForwardAccel")] public ValueContainer movementAccel = new ValueContainer(2);
    /// <summary>
    /// The agility for fly to maneuver. The less value the harder to turn.
    /// </summary>
    public ValueContainer Agility = new ValueContainer(0.3f);
    /// <summary>
    /// The air drag the fly will suffer from. 
    /// </summary>
    public ValueContainer AirDragVal = new ValueContainer(3);

    private float timeElapsed = 0.0f;
    private float lerpDuration = 3f;
    private Modifier[] SlowDownModifer = new Modifier[]{ new Modifier(false, 3.5f, "0"), new Modifier(false, 4f, "0"), new Modifier(false, 4.5f, "0"), new Modifier(false, 5f, "0"), new Modifier(false, 5.5f, "0")};
    public Modifier SpeedUpModifier = new Modifier(false, 20, "0");
    public Modifier normalSpeedModifier = new Modifier(false, 3, "0");
    /// <summary>
    /// The noise multiplier toward the fly's buzz. Also affect the effective range of the noise.
    /// </summary>
    public ValueContainer NoiseLevel = new ValueContainer(1f);
    
    /// <summary>
    /// The modifer for acceleration for left stick.
    /// </summary>
    public Modifier AccelStrength = new Modifier(false, 6, "0");
    /// <summary>
    /// The maximum modifier for acceleration for left stick.
    /// </summary>
    public float AccelStrengthMax = 6;
    /// <summary>
    /// The extra drag for when climbing on a surface. Better for 
    /// </summary>
    public Modifier OnClimbingExtraDrag = new Modifier(false, 1, "0");

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
    
    protected float RollingSpeed = 0;
    protected float YawingSpeed = 0;
    protected float PitchingSpeed = 0;

    public float PitchDirectionMultiplier = 1;

    public Vector3 CurrentMovingDirection = Vector3.zero;

    private float RollMultiplier = 0.02f;
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
    /// <summary>
    /// If this fly is under ingestion
    /// </summary>
    public bool Ingesting { get; set; }
    /// <summary>
    /// If this fly is in the state of climbing
    /// </summary>
    public bool IsClimbing;
    public AutoResetCounter ClimbCounter = new AutoResetCounter(5);
    /// <summary>
    /// If Auto Alignment is enabled
    /// </summary>
    public bool AutoAlignEnabled = true;
    public Quaternion[] rotTrack = new Quaternion[5];
    private void Start()
    {
        rotTrack[3] = new Quaternion(0.0f,0.0f,0.0f,0.0f);
        rotTrack[4] = new Quaternion(0.0f,0.0f,0.0f,0.0f);
        myGuid = Guid.NewGuid();
        movementAccel.SetNoBonusModifier(myGuid);
        Agility.SetNoBonusModifier(myGuid);
        AirDragVal.SetNoBonusModifier(myGuid);
        IngestSpeed.SetNoBonusModifier(myGuid);
        MaxHP = new ValueContainer(BaseFlyMaxHP);
        HPCounter = new AutoResetCounter(MaxHP.FinalVal(), true);
        TakeDamage(0f);
        ClearIngestion();
    }
    protected void FixedUpdate()
    {
        _ = IsClimbing ? ClimbAction() : FlightAction();
        if (ClimbCounter.IsZeroReached(1, false)){
            //IsClimbing = false;
        } 
        
        //IsClimbing = false;
        //FlightAction();

    }


    public void slow_down_fly(int index)
    {
        AirDragVal.SetModifier(myGuid, SlowDownModifer[index]);
    }

    public void speed_up_fly()
    {
        movementAccel.SetModifier(myGuid, SpeedUpModifier);
    }

    private bool climbDetector(){
        Vector3 avg = this.transform.up * -1;
        foreach (var hit in Physics.RaycastAll(thisRigidbody.transform.position,
            this.transform.up * -1,
            RayLength * 10))
            {
                if (hit.collider.CompareTag("Climbable"))
                {
                    return true;
                }
            }
        return false;
    }

    public void normal_fly_speed()
    {
        AirDragVal.SetModifier(myGuid, normalSpeedModifier);
    }

    int FlightAction()
    {
        AirDragVal.SetNoBonusModifier(myGuid);
        thisRigidbody.drag = AirDragVal.FinalVal();
        thisRigidbody.AddRelativeForce(movementAccel.FinalVal() * CurrentMovingDirection);
        thisRigidbody.AddForce(Vector3.down * ArtificialGravity);

        Vector2 KnownAlignment = _useFreeCam ? Vector2.zero : _alignment;
        float Yaw = Mathf.Clamp(KnownAlignment.x, -1, 1);
        Yaw = Mathf.Abs(Yaw) < DeadZoneYaw ? 0 : Yaw;
        
        float Pitch = Mathf.Clamp(KnownAlignment.y, -1, 1);
        Pitch = Mathf.Abs(Pitch) < DeadZonePitch ? 0 : Pitch;

        RollingSpeed = _rollLeft ? 1f : (_rollRight ? -1f : 0f);
    
        thisRigidbody.AddRelativeTorque(
            Agility.FinalVal() * Pitch * -PitchMultiplier,
            Agility.FinalVal() * Yaw * YawMultiplier,
            RollingSpeed * RollMultiplier,
            ForceMode.Force);
        thisRigidbody.angularVelocity *= 0.2f;
        RollingSpeed = 0;
        YawingSpeed = 0;
        PitchingSpeed = 0;

        /* Buzz.pitch = NoiseLevel.FinalVal() * (movementAccel.FinalVal() / AccelStrengthMax);
        Buzz.volume = NoiseLevel.FinalVal() * Buzz.pitch; */
        Buzz.volume = 1;
        Buzz.pitch = 1;

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
        _ = IsClimbing ? Climb() + ClimbCamControl() : Flight() + FlightCamControl();

    }



    int Flight()
    {
        float UpDown = _takeOff ? 1 : (_landDown ? -1 : 0);
        UpDown += Mathf.Clamp01(_alignment.y);
        if (_foreBack < 0)
        {
            _foreBack = 0;
        }
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
        

        if (_landDown)
        {
            if (RegularSphereScan(this.transform.position, 15, 15, RayLength).Count > 0)
            {
                ClimbCounter.MaxmizeTemp();
                IsClimbing = true;
            }
        }
        
        
        var injestPressed = _ingest;
        this.Ingesting = injestPressed;
        IngestSound.volume = injestPressed?1:0;
        
        return 0;
    }
    
    
    void CancelAccelerate(InputAction.CallbackContext ctx){
        movementAccel.SetNoBonusModifier(myGuid);
    }
    void CancelAirBrake(InputAction.CallbackContext ctx){
        AirDragVal.SetNoBonusModifier(myGuid);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Climbable")){
            if(climbDetector()){
                IsClimbing = true;
            }
            timeElapsed = 0;
        }
        //if (other.collider.gameObject.CompareTag("Climbable"))
        //{
        //    this.transform.up = this.transform.position-other.contacts[0].point;
        //}
        // if (other.gameObject.GetComponent<FoodHit>() != null)
        // {
        //     IngestSound.volume = 1;
        //     IngestSound.Play();
        // }
    }
}