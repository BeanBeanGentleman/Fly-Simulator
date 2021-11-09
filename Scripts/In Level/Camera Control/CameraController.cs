using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    // The object that the camera will follow on
    public GameObject FollowUp;
    
    /// <summary>
    /// Lerp Value on Position
    /// </summary>
    public float Multipler = 0.2f;
    /// <summary>
    /// Lerp Value on Rotation
    /// </summary>
    public float MultiplerAngle = 0.2f;
    /// <summary>
    /// Lerp Value when using Freecam. Freecam is deprecated.
    /// </summary>
    [Obsolete]
    public float MultiplerFreeCam = 0.05f;

    /// <summary>
    /// GUI Indication 
    /// </summary>
    public RectTransform TheRing;

    /// <summary>
    /// Turn on Freecam Mode. This is obsolete as freecam is now implemented on Fly Controller.
    /// </summary>
    [Obsolete]
    public bool Freecam = false;
    public Vector3 CamLookingEulerOffset = Vector3.zero;
    private Vector3 LockDownLookingDirection = Vector3.zero;
    
    
    // Update is called once per frame
    private void Update()
    {
        if(!Freecam)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, FollowUp.transform.rotation, MultiplerAngle);
            LockDownLookingDirection = transform.localEulerAngles;
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(LockDownLookingDirection + CamLookingEulerOffset), MultiplerFreeCam);
        }
        transform.position = Vector3.Lerp(transform.position, FollowUp.transform.position, Multipler);
        TheRing.position = new Vector3(CamLookingEulerOffset.y, -CamLookingEulerOffset.x, 5) + Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
    }
    
}