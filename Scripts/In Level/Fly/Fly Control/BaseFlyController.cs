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
    // public InputAction Ingest;
    public int Accelerate = 1;
    public int AirBrake = 1;
    public int RollLeft = 1;
    public int RollRight = 1;
    public int YawLeft = 1;
    public int YawRight = 1;
    

    
    // public InputAction MousePos;
    

    public Rigidbody thisRigidbody;


    public FlyValueContainer ForwardAccel = new FlyValueContainer(2);
    public FlyValueContainer Agility = new FlyValueContainer(0.3f);
    public FlyValueContainer AirDragVal = new FlyValueContainer(3);
    public FlyValueContainer IngestSpeed = new FlyValueContainer(0.3f);

    public Modifier ForwardMoreAccel = new Modifier(false, 2, "0");
    public Modifier AirbrakeDragBonus = new Modifier(false, 15, "0");

    public AudioSource Buzz;
    public AudioSource IngestSound;
    public GameObject Looking;

    public float ArtificialGravity = 0.98f;

    public float RollingSpeed = 0;
    public float YawingSpeed = 0;
    public float PitchingSpeed = 0;

    private float RollMultiplier = 0.2f;
    private float YawMultiplier = 2f;
    private float PitchMultiplier = 2f;

    public float DeadZoneYaw = 0.2f;
    public float DeadZonePitch = 0.2f;
    
    private readonly GUID myGuid = new GUID();
    private void Start()
    {
        ForwardAccel.SetNoBonusModifier(myGuid);
        Agility.SetNoBonusModifier(myGuid);
        AirDragVal.SetNoBonusModifier(myGuid);
        IngestSpeed.SetNoBonusModifier(myGuid);
        
        // Ingest = FlyInputActions.BaseFly.Ingest;
        // Ingest.Enable(); 
        // Accelerate = FlyInputActions.NormalFly.Accelerate;
        // Accelerate.Enable(); 
        // Accelerate.performed += PerformAccelerate;
        // Accelerate.canceled += CancelAccelerate;
        //
        // AirBrake = FlyInputActions.NormalFly.AirBrake;
        // AirBrake.Enable(); 
        // AirBrake.performed += PerformAirBrake;
        // AirBrake.canceled += CancelAirBrake;
        //
        // RollLeft = FlyInputActions.NormalFly.RollLeft;
        // RollLeft.Enable(); 
        // RollLeft.performed += PerformRollLeft;
        // // RollLeft.canceled += CancelRollLeft;
        //
        // RollRight = FlyInputActions.NormalFly.RollRight;
        // RollRight.Enable(); 
        // RollRight.performed += PerformRollRight;
        // // RollRight.canceled += CancelRollRight;
        //
        // YawLeft = FlyInputActions.NormalFly.YawLeft;
        // YawLeft.Enable(); 
        // YawLeft.performed += PerformYawLeft;
        // // YawLeft.canceled += CancelYawLeft;
        //
        // YawRight = FlyInputActions.NormalFly.YawRight;
        // YawRight.Enable(); 
        // YawRight.performed += PerformYawRight;
        // YawRight.canceled += CancelYawRight;
        
    }

    protected void FixedUpdate()
    {



        // if (Input.GetKey(RollLeft))
        //     this.transform.eulerAngles += Vector3.forward * Agility;
        // else if (Input.GetKey(RollRight))
        //     this.transform.eulerAngles -= Vector3.forward * Agility;
        // else
        //     this.transform.eulerAngles -= Vector3.forward * this.transform.eulerAngles.z * Agility;
        //
        //
        // if (Ingest.ReadValue<float>() > 0.7f ) InjestSomething();
        // else
        //     IngestSound.volume = 0;

        // if (AirBrake.ReadValue<float>() < 0.7f)
        // {
        //
        //     // thisRigidbody.drag = 1;
        //     // thisRigidbody.angularDrag = 0.7f;
        //     // thisRigidbody.useGravity = false;
        // }
        // else
        // {
        //     // thisRigidbody.useGravity = true;
        //     // thisRigidbody.drag = 999;
        //     // thisRigidbody.angularDrag = 999;
        // }
        // Vector3 MousePos = Camera.main.ScreenToViewportPoint(
        //     new Vector3(
        //     
        //     Input.mousePosition.x,
        //     Input.mousePosition.y,
        //     1500)) - (Vector3.one * 0.5f);
        
        thisRigidbody.drag = AirDragVal.FinalVal();
        thisRigidbody.AddForce(ForwardAccel.FinalVal() * this.transform.forward);
        Vector2 MouseActualPos = Mouse.current.position.ReadValue();
        MouseActualPos = Camera.main.ScreenToViewportPoint(MouseActualPos) - (Vector3.one * 0.5f);

        float Yaw = Mathf.Clamp(MouseActualPos.x + YawingSpeed, -1, 1);
        Yaw = Mathf.Abs(Yaw) < DeadZoneYaw ? 0 : Yaw;
        Yaw *= YawMultiplier;

        float Roll = RollingSpeed;
        Roll *= RollMultiplier;
            
        float Pitch = Mathf.Clamp(MouseActualPos.y + PitchingSpeed, -1, 1);
        Pitch = Mathf.Abs(Pitch) < DeadZonePitch ? 0 : Pitch;
        Pitch *= PitchMultiplier;
        
        thisRigidbody.AddRelativeTorque(Agility.FinalVal() * Pitch * -0.1f, Agility.FinalVal() * Yaw * 0.1f, RollingSpeed) ;
        thisRigidbody.angularVelocity *= 0.2f;
        RollingSpeed = 0;
        YawingSpeed = 0;
        PitchingSpeed = 0;
        
   
        Buzz.pitch = ForwardAccel.FinalVal() / ForwardAccel.BaseVal;
        Buzz.volume = Buzz.pitch;

    }

    
    private void Update()
    {
        if (Accelerate%3==0) ForwardAccel.SetModifier(myGuid, ForwardMoreAccel);
        else ForwardAccel.SetNoBonusModifier(myGuid);
        
        if (AirBrake%3==0) AirDragVal.SetModifier(myGuid, AirbrakeDragBonus);
        else AirDragVal.SetNoBonusModifier(myGuid);

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
        
    }

    // private void LateUpdate()
    // {
    //     if (thisRigidbody.velocity.sqrMagnitude > 1)
    //         transform.LookAt(Vector3.Lerp(transform.position + transform.forward * 1500,
    //             Camera.main.ScreenToWorldPoint(new Vector3(
    //                 Input.mousePosition.x,
    //                 Input.mousePosition.y,
    //                 1500)),
    //             Agility));
    // }
    
    





    protected void InjestSomething()
    {
        h.l("Ingesting");
        IngestSound.volume = 1;
    }
    
    
    void CancelAccelerate(InputAction.CallbackContext ctx){
        ForwardAccel.SetNoBonusModifier(myGuid);
    }
    void CancelAirBrake(InputAction.CallbackContext ctx){
        AirDragVal.SetNoBonusModifier(myGuid);
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