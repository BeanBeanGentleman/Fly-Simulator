using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Genral;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public partial class BaseFlyController
{
    public LineRenderer lr;
    public GameObject CamFollower;
    public Vector3 CamFolwOrigPos;
    public Vector3 CamFolwClimbPos;
    public Vector3 CamFolwClimbEul;
    
    int Climb()
    {
        float UpDown = _takeOff ? 1 : (_landDown ? -1 : 0);
        Vector3 AccelDirection = new Vector3(_climbLeftRight, UpDown, _climbForeBack);
        CurrentMovingDirection = AccelDirection;
        AccelStrength.Value = Mathf.Clamp01(AccelDirection.magnitude) * AccelStrengthMax;
        movementAccel.SetModifier(myGuid, AccelStrength);
        if (_manualSwitchToggle) AutoAlignEnabled = !AutoAlignEnabled;
        if (_useFreeCam)
        {
            cc.Freecam = true;
            cc.CamLookingEulerOffset = new Vector3(-_alignment.y, _alignment.x,  0) * 180;
        }
        else
        {
            cc.Freecam = false;
        }
        CamFollower.transform.localPosition = CamFolwClimbPos;
        CamFollower.transform.localEulerAngles = CamFolwClimbEul + Vector3.right * (_view.y * -30);
        var injestPressed = _ingest;
        this.Ingesting = injestPressed;
        IngestSound.volume = injestPressed?1:0;
        return 0;
    }
    
        int ClimbAction()
    {
        
        AirDragVal.SetModifier(myGuid, OnClimbingExtraDrag);
        thisRigidbody.drag = AirDragVal.FinalVal();
        
        Vector2 KnownAlignment = _useFreeCam ? Vector2.zero : _alignment;
        float Yaw = Mathf.Clamp(KnownAlignment.x, -1, 1);
        Yaw = Mathf.Abs(Yaw) < DeadZoneYaw ? 0 : Yaw;
        
        float Pitch = Mathf.Clamp(KnownAlignment.y, -1, 1);
        Pitch = Mathf.Abs(Pitch) < DeadZonePitch ? 0 : Pitch;

        thisRigidbody.AddRelativeTorque(
            0,
            Agility.FinalVal() * Yaw * YawMultiplier,
            RollingSpeed * RollMultiplier);
        thisRigidbody.angularVelocity *= 0.2f;
        RollingSpeed = 0;
        YawingSpeed = 0;
        PitchingSpeed = 0;
        
        Buzz.pitch = 0;
        Buzz.volume = 0;


        Quaternion nextRot = this.transform.rotation;
        if (_useFreeCam)
        {
            nextRot = Quaternion.LookRotation(Vector3.Cross(Vector3.up,
                    Vector3.Cross(thisRigidbody.transform.forward,
                        Vector3.up)),
                Vector3.up);
        }
        else
        {
            bool DownHasHit = false;
            foreach (var hit in Physics.RaycastAll(thisRigidbody.transform.position,
                this.transform.up * -1,
                1))
            {
                if (hit.collider.CompareTag("Climbable"))
                {
                    nextRot = Quaternion.LookRotation(Vector3.Cross(hit.normal,
                            Vector3.Cross(thisRigidbody.transform.forward,
                                hit.normal)),
                        hit.normal);
                    DownHasHit = true;
                    break;
                }
            }
            List<RaycastHit> regularSphereScan = RegularSphereScan(this.transform.position, 15, 15, 1f);
            List<float> normalsX = new List<float>();
            List<float> normalsY = new List<float>();
            List<float> normalsZ = new List<float>();
            if (!DownHasHit)
            {
                foreach (var hit in regularSphereScan)
                {
                    normalsX.Add(hit.normal.x);
                    normalsY.Add(hit.normal.y);
                    normalsZ.Add(hit.normal.z);
                    ClimbCounter.MaxmizeTemp();
                }

                Vector3 avg = new Vector3(normalsX.Sum(), normalsY.Sum(), normalsZ.Sum())/normalsX.Count;
                if (normalsX.Count > 0)
                {
                    nextRot = Quaternion.LookRotation(Vector3.Cross(avg,
                            Vector3.Cross(thisRigidbody.transform.forward,
                                avg)),
                        avg);
                    thisRigidbody.AddForce(avg.normalized * -ArtificialGravity * 3);
                }

            }

            if (_manualSwitchTargetL)
            {
                DebugShowingLines(lr, regularSphereScan);
                
            }
        }
        this.transform.rotation = Quaternion.Lerp(thisRigidbody.rotation, nextRot, 0.14f);
        
        thisRigidbody.AddRelativeForce(movementAccel.FinalVal() * CurrentMovingDirection);
        return 0;
    }
    List<RaycastHit> RegularSphereScan(Vector3 StartPoint, float HorizontalDegreePrecision, float VerticalDegreePrecision, float Distance)
    {
        List<RaycastHit> HitPoints = new List<RaycastHit>();
        RaycastHit hito;
        for (float Vi = VerticalDegreePrecision; Vi < 360; Vi += VerticalDegreePrecision)
        {
            for (float Hi = 0; Hi < 360; Hi += HorizontalDegreePrecision)
            {
                //float elevation = Hi * Mathf.Deg2Rad;
                //float heading = Vi * Mathf.Deg2Rad;
                Ray rayray = new Ray(StartPoint, EulerToDirection(Hi, Vi));
                RaycastHit[] RHs = Physics.RaycastAll(rayray, Distance);
                foreach (RaycastHit RH in RHs)
                {
                    //Debug.Log(RH.collider.gameObject.name);
                    if (RH.collider.CompareTag("Climbable"))
                    {
                        HitPoints.Add(RH);
                        break;
                        //Gizmos.DrawRay(rayray);
                    }
                }
            }
        }
        return HitPoints;
    }
    
    public Vector3 EulerToDirection(float Elevation, float Heading)
    {
        float elevation = Elevation * Mathf.Deg2Rad;
        float heading = Heading * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(elevation) * Mathf.Sin(heading), Mathf.Sin(elevation), Mathf.Cos(elevation) * Mathf.Cos(heading));
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Climbable"))
        {
            ClimbCounter.MaxmizeTemp();
            IsClimbing = true;
        }
    }
    
    void DebugShowingLines(LineRenderer LR, List<RaycastHit> hits)
    {
        LR.SetVertexCount(hits.Count * 2 + 1);
        int i = 0;
        foreach (RaycastHit cp in hits)
        {
            LR.SetPosition(i, this.transform.position);
            ++i;
            LR.SetPosition(i, cp.point);
            ++i;
        }
    }
}