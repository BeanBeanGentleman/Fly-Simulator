using System;
using System.Numerics;
using Genral;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

/// <summary>
/// This is the controller script of the fly, handling HP, Energy and Flight control(also include ingesting), but not Camera Control.
/// </summary>
public partial class BaseFlyController : MonoBehaviour, FlyInput.INormalFlyActions
{

    

    
    // public InputAction MousePos;
    

    public Rigidbody thisRigidbody;

    /// <summary>
    /// The force strength for pushing the fly forward. (Backward if < 0)
    /// </summary>
    public FlyValueContainer ForwardAccel = new FlyValueContainer(0);
    /// <summary>
    /// The agility for fly to maneuver. The less value the harder to turn.
    /// </summary>
    public FlyValueContainer Agility = new FlyValueContainer(0.3f);
    /// <summary>
    /// The air drag the fly will suffer from. 
    /// </summary>
    public FlyValueContainer AirDragVal = new FlyValueContainer(3);
    /// <summary>
    /// The speed of ingestion per second.
    /// </summary>
    public FlyValueContainer IngestSpeed = new FlyValueContainer(0.3f);
    /// <summary>
    /// The noise multiplier toward the fly's buzz. Also affect the effective range of the noise.
    /// </summary>
    public FlyValueContainer NoiseLevel = new FlyValueContainer(1f);
    
    /// <summary>
    /// The modifer for when W is pressed or the right joystick pushed forward.
    /// </summary>
    public Modifier ForwardMoreAccel = new Modifier(false, 2, "0");
    /// <summary>
    /// The modifer for when S is pressed or the right joystick pushed backward.
    /// </summary>
    public Modifier BackwardAccel = new Modifier(false, -2, "0");
    /// <summary>
    /// The modifer for when S is pressed or the right joystick pushed backward. For Air Drag.
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
    public float ArtificialGravity = 0.98f;
    
    public float RollingSpeed = 0;
    public float YawingSpeed = 0;
    public float PitchingSpeed = 0;

    private float RollMultiplier = 0.05f;
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
    
    private void Start()
    {
        myGuid = Guid.NewGuid();
        ForwardAccel.SetNoBonusModifier(myGuid);
        Agility.SetNoBonusModifier(myGuid);
        AirDragVal.SetNoBonusModifier(myGuid);
        IngestSpeed.SetNoBonusModifier(myGuid);
        
        
    }

    protected void FixedUpdate()
    {
        thisRigidbody.drag = AirDragVal.FinalVal();
        thisRigidbody.AddForce(ForwardAccel.FinalVal() * this.transform.forward);
        Vector2 MouseActualPos = Mouse.current.position.ReadValue();
        MouseActualPos = Camera.main.ScreenToViewportPoint(MouseActualPos) - (Vector3.one * 0.5f);

        float Yaw = Mathf.Clamp(MouseActualPos.x + YawingSpeed, -1, 1);
        Yaw = Mathf.Abs(Yaw) < DeadZoneYaw ? 0 : Yaw;

        float Roll = RollingSpeed;

        float Pitch = Mathf.Clamp(MouseActualPos.y + PitchingSpeed, -1, 1);
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
        
        Buzz.pitch = NoiseLevel.FinalVal() * (ForwardAccel.FinalVal() / ForwardMoreAccel.Value);
        Buzz.volume = NoiseLevel.FinalVal() * Buzz.pitch;

    }

    
    private void Update()
    {
        if (Accelerate%3==0) ForwardAccel.SetModifier(myGuid, ForwardMoreAccel);



        if (AirBrake % 3 == 0)
        {
            AirDragVal.SetModifier(myGuid, AirbrakeDragBonus);
            ForwardAccel.SetModifier(myGuid, BackwardAccel);
        }
        else
        {
            AirDragVal.SetNoBonusModifier(myGuid);
        }
        
        if((AirBrake % 3 != 0) && (Accelerate % 3 != 0))ForwardAccel.SetNoBonusModifier(myGuid);

        if (RollLeft%3==0)
        {
            RollingSpeed = 1;
        }
        else if (RollRight % 3 == 0)
        {
            RollingSpeed = -1;
        }
        else
            RollingSpeed = 0;
        
        if (YawLeft%3==0)
        {
            YawingSpeed = -1;
        }
        else if (YawRight%3==0)
        {
            YawingSpeed = 1;
        }
        else
            YawingSpeed = 0;

        var InjestPressed = Ingest % 3 == 0;
        this.Ingesting = InjestPressed;
        IngestSound.volume = InjestPressed?1:0;

    }
    
    
    void CancelAccelerate(InputAction.CallbackContext ctx){
        ForwardAccel.SetNoBonusModifier(myGuid);
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