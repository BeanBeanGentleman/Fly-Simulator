using System;
using System.Collections.Generic;
using System.Numerics;
using Genral;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public partial class BaseFlyController
{
    public LineRenderer lr;
    public GameObject CamFollower;
    public Vector3 CamFolwOrigPos;
    public Vector3 CamFolwClimbPos;
    public Vector3 CamFolwClimbEul;
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