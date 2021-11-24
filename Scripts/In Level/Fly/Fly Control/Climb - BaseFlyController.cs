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


    public float RayLength = 1;


    
    public bool DrawDebug = false;
    
    int Climb()
    {
        float UpDown = _takeOff ? 1 : (_landDown ? -1 : 0);
        Vector3 AccelDirection = new Vector3(_climbLeftRight, UpDown, _climbForeBack);
        CurrentMovingDirection = AccelDirection;
        AccelStrength.Value = Mathf.Clamp01(AccelDirection.magnitude) * AccelStrengthMax;
        movementAccel.SetModifier(myGuid, AccelStrength);
        if (_takeOff)
        {
            IsClimbing = false;
        }

        if (_manualSwitchToggle) AutoAlignEnabled = !AutoAlignEnabled;
        var injestPressed = _ingest;
        this.Ingesting = injestPressed;
        //IngestSound.volume = injestPressed ? 1 : 0;
        return 0;
    }

    int ClimbAction()
    {
        //AirDragVal.SetModifier(myGuid, OnClimbingExtraDrag);
        thisRigidbody.drag = 10;
        
        Vector2 KnownAlignment = _useFreeCam ? Vector2.zero : _alignment;
        float Yaw = Mathf.Clamp(KnownAlignment.x, -1, 1);
        Yaw = Mathf.Abs(Yaw) < DeadZoneYaw ? 0 : Yaw;

        float Pitch = Mathf.Clamp(KnownAlignment.y, -1, 1);
        Pitch = Mathf.Abs(Pitch) < DeadZonePitch ? 0 : Pitch;

        thisRigidbody.AddRelativeTorque(
            Agility.FinalVal() * Pitch * PitchMultiplier,
            Agility.FinalVal() * Yaw * YawMultiplier,
            RollingSpeed * RollMultiplier);
        thisRigidbody.angularVelocity *= 0.2f;
        RollingSpeed = 0;
        YawingSpeed = 0;
        PitchingSpeed = 0;

        //Buzz.pitch = 0;
        //Buzz.volume = 0;

        int flipped = 1;
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
            Vector3 avg = this.transform.up * -1;
            foreach (var hit in Physics.RaycastAll(thisRigidbody.transform.position,
                this.transform.up * -1,
                RayLength * 10))
            {
                if (hit.collider.CompareTag("Climbable"))
                {
                    
                        nextRot = Quaternion.LookRotation(Vector3.Cross(climbnormal,
                            Vector3.Cross(thisRigidbody.transform.forward,
                                climbnormal)),
                        climbnormal);
                    
                    
                    DownHasHit = true;

                    /*if(nextRot == rotTrack[3] && rotTrack[2] == rotTrack[4]){
                        nextRot = rotTrack[4];
                    }
                    else if(nextRot == rotTrack[2] && rotTrack[0] == rotTrack[3] && rotTrack[1] == rotTrack[4]){
                        nextRot = rotTrack[4];
                    }
                    else{
                        rotTrack[0] = rotTrack[1];
                        rotTrack[1] = rotTrack[2];
                        rotTrack[2] = rotTrack[3];
                        rotTrack[3] = rotTrack[4];
                        rotTrack[4] = nextRot;
                    }*/
                    break;
                }
            }
            List<RaycastHit> regularSphereScan = RegularSphereScan(this.transform.position, 15, 15, RayLength * (_landDown ? 5 : 1));
            List<float> normalsX = new List<float>();
            List<float> normalsY = new List<float>();
            List<float> normalsZ = new List<float>();
            if (DownHasHit){
                if (timeElapsed < lerpDuration *4){
                    this.transform.rotation = Quaternion.Lerp(thisRigidbody.rotation, nextRot, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                }
                else 
                {
                    this.transform.rotation = nextRot;
                }
                //this.transform.rotation = Quaternion.Lerp(thisRigidbody.rotation, nextRot, t);
        
                //this.GetComponent<Collider>().material.dynamicFriction = 0;
                //this.GetComponent<Collider>().material.staticFriction = 0;
        
                //thisRigidbody.freezeRotation = true;
                this.transform.Translate (CurrentMovingDirection * Time.deltaTime * 2);
            }
            //thisRigidbody.AddRelativeForce(movementAccel.FinalVal() * CurrentMovingDirection);
            if (!DownHasHit)
            {
                IsClimbing = false;
                foreach (var hit in regularSphereScan)
                {
                    normalsX.Add(hit.normal.x);
                    normalsY.Add(hit.normal.y);
                    normalsZ.Add(hit.normal.z);
                    ClimbCounter.MaxmizeTemp();
                }

                avg = new Vector3(normalsX.Sum(), normalsY.Sum(), normalsZ.Sum()) / normalsX.Count;
                if (normalsX.Count > 0)
                {
                    nextRot = Quaternion.LookRotation(Vector3.Cross(avg, Vector3.Cross(thisRigidbody.transform.forward, avg)) * Mathf.Sign(Vector3.Dot(avg, 
                    this.transform.up)), avg);
                }
            }

            //thisRigidbody.AddForce(avg.normalized * ArtificialGravity * -2);
            if (DrawDebug)
            {
                // DebugShowingLines(lr, regularSphereScan);
            }

            if (_manualSwitchTargetL)
            {
                DrawDebug = !DrawDebug;
            }
        }
        
        return 0;
    }

    List<RaycastHit> RegularSphereScan(Vector3 StartPoint, float HorizontalDegreePrecision, float VerticalDegreePrecision, float Distance)
    {
        List<RaycastHit> HitPoints = new List<RaycastHit>();
        RaycastHit hito;
        for (float Vi = 0; Vi < 360; Vi += VerticalDegreePrecision)
        {
            for (float Hi = 0; Hi < 360; Hi += HorizontalDegreePrecision)
            {
                float newDist = Distance * Vector3.Angle(EulerToDirection(Hi, Vi), -thisRigidbody.velocity.normalized) / 60;
                // For Limiting the ray cast direction
                // if (Vector3.Angle(EulerToDirection(Hi, Vi), -this.transform.up) > 76)
                // {
                //     continue;
                // }
                Ray rayray = new Ray(StartPoint, EulerToDirection(Hi, Vi));
                RaycastHit[] RHs = Physics.RaycastAll(rayray, newDist);
                foreach (RaycastHit RH in RHs)
                {
                    //Debug.Log(RH.collider.gameObject.name);
                    if (RH.collider.CompareTag("Climbable"))
                    {
                        HitPoints.Add(RH);
                        break;
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
            if(climbDetector()){
                IsClimbing = true;
            }
            //ClimbCounter.MaxmizeTemp();
        }
    }

    /*private void OnCollisionExit(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Climbable"))
        {
            print("exit");
            //thisRigidbody.freezeRotation = false;
            IsClimbing = false;
        }
    }*/

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