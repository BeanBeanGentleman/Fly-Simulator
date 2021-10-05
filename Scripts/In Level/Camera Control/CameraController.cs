using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public GameObject FollowUp;

    public float Multipler = 0.2f;
    public float MultiplerAngle = 0.2f;

    public RectTransform TheRing;

    public bool Freecam = false;
    public Vector3 CamLookingEulerOffset = Vector3.zero;
    private Vector3 LockDownLookingDirection = Vector3.zero;
    
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        if(!Freecam)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, FollowUp.transform.rotation, MultiplerAngle);
            LockDownLookingDirection = transform.localEulerAngles;
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(LockDownLookingDirection + CamLookingEulerOffset), MultiplerAngle);
        }
        
        transform.position = Vector3.Lerp(transform.position, FollowUp.transform.position, Multipler);
    }

    private void Update()
    {
        TheRing.position = new Vector3(CamLookingEulerOffset.y, -CamLookingEulerOffset.x, 5) + Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
    }
}